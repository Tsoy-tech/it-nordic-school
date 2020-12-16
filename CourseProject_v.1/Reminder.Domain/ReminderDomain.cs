using System;
using System.Linq;
using System.Threading;
using Reminder.Domain.EventsArgs;
using Reminder.Domain.Model;
using Reminder.Parsing;
using Reminder.Receiver.Core;
using Reminder.Sender.Core;
using Reminder.Storage.Core;

namespace Reminder.Domain
{
    public class ReminderDomain : IDisposable
    {
        private readonly IReminderStorage _storage;
        private readonly IReminderSender _sender;
        private readonly IReminderReceiver _receiver;

        private readonly TimeSpan _awaitingRemindersCheckPeriod;
        private readonly TimeSpan _readyReminderCheckPeriod;

        private Timer _awaitingReminderCheckTimer; //using for Method Run
        private Timer _readyReminderSendTimer;

  

        public event EventHandler<ParsingFailedEventArgs> ParsingFailed;

        public event EventHandler<SendingSucceededEventArgs> SendingSucceeded;
        public event EventHandler<SendingFailedEventArgs> SendingFailed;

        public event EventHandler<AddingSucceededEventArgs> AddingSucceeded;
        public event EventHandler<AddingFailedEventArgs> AddingFailed;

        public ReminderDomain(IReminderStorage storage, IReminderReceiver receiver, IReminderSender sender) : this(storage, receiver, sender, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1)) { }
        public ReminderDomain( IReminderStorage storage, IReminderReceiver receiver, IReminderSender sender, TimeSpan awaitingRemindersCheckingPeriod, TimeSpan readyReminderCheckPeriod)
        {
            _storage = storage;
            _receiver = receiver;
            _sender = sender;
            _awaitingRemindersCheckPeriod = awaitingRemindersCheckingPeriod;
            _readyReminderCheckPeriod = readyReminderCheckPeriod;
        }

        public void Run()
        {
            _awaitingReminderCheckTimer = new Timer(CheckAwaitingReminders, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            _readyReminderSendTimer = new Timer(SendReadyToSendReminders, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            _receiver.MessageReceived += ReceiverOnMessageReceived;
            _receiver.StartReceiving();
        }

        private void CheckAwaitingReminders(object _) //Подчеркивание "_" = не используем!
        {
            var readyItems = _storage.GetList(new[] { ReminderItemStatus.Awaiting }).Where(i => i.IsTimeToSend);

            foreach (var readyItem in readyItems)
            {
                readyItem.Status = ReminderItemStatus.ReadyToSend;
                _storage.Update(readyItem);
            }
        }
        private void SendReadyToSendReminders(object _)
        {
            var readyItems = _storage.GetList(new[] { ReminderItemStatus.ReadyToSend });

            foreach (var item in readyItems)
            {
                var sendingModel = new SendReminderModel(item);

                try 
                {
                    _sender.Send(sendingModel.AccountId, sendingModel.Message);

                    item.Status = ReminderItemStatus.SuccessfullySent;
                   
                    //вызов события успеха
                    SendingSucceeded?.Invoke(this, new SendingSucceededEventArgs(sendingModel));
                }
                catch(Exception exception)
                {
                    item.Status = ReminderItemStatus.Failed;

                    //событие неудачи
                    SendingFailed?.Invoke(this, new SendingFailedEventArgs(sendingModel, exception));
                }
                
                _storage.Update(item);
            }

        }

        private void ReceiverOnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            var o = MessageParser.Parse(e.Message);
            if(o == null)
            {
                ParsingFailed?.Invoke(this, new ParsingFailedEventArgs(e.AccountID, e.Message));

                return;
            }

            var item = new ReminderItem(o.Date, o.Message, e.AccountID);

			try
			{
                _storage.Add(item);

                AddingSucceeded?.Invoke(this, new AddingSucceededEventArgs(new AddReminderModel(item)));
			}
            catch(Exception exception)
			{
                AddingFailed?.Invoke(this, new AddingFailedEventArgs(new AddReminderModel(item), exception));
			}
        }

        public void Dispose()
        {
            _awaitingReminderCheckTimer?.Dispose();
            _readyReminderSendTimer?.Dispose();
        }
    }
}
