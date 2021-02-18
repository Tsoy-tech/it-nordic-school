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
        public ReminderDomain( IReminderStorage storage, IReminderReceiver receiver, IReminderSender sender, TimeSpan awaitingRemindersCheckPeriod, TimeSpan readyReminderSendPeriod)
        {
            _storage = storage;
            _receiver = receiver;
            _sender = sender;
            _awaitingRemindersCheckPeriod = awaitingRemindersCheckPeriod;
            _readyReminderCheckPeriod = readyReminderSendPeriod;
        }

        public void Run()
        {
            _awaitingReminderCheckTimer = new Timer(CheckAwaitingReminders, null, TimeSpan.Zero, _awaitingRemindersCheckPeriod);
            _readyReminderSendTimer = new Timer(SendReadyToSendReminders, null, TimeSpan.Zero, _readyReminderCheckPeriod);

            _receiver.MessageReceived += ReceiverOnMessageReceived;
            _receiver.StartReceiving();
        }
        private void ReceiverOnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            var o = MessageParser.Parse(e.Message);
            if (o == null)
            {
                ParsingFailed?.Invoke(this, new ParsingFailedEventArgs(e.AccountID, e.Message));

                return;
            }

            var item = new ReminderItemRestricted(o.Date, o.Message, e.AccountID, ReminderItemStatus.Awaiting);

            try
            {
                Guid id = _storage.Add(item);

                AddingSucceeded?.Invoke(this, new AddingSucceededEventArgs(new AddReminderModel(item), id));
            }
            catch (Exception exception)
            {
                AddingFailed?.Invoke(this, new AddingFailedEventArgs(new AddReminderModel(item), exception));
            }
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

            foreach (var readyItem in readyItems)
            {
                var sendingModel = new SendReminderModel(readyItem);

                try 
                {
                    _sender.Send(sendingModel.AccountId, sendingModel.Message);

                    readyItem.Status = ReminderItemStatus.SuccessfullySent;
                   
                    SendingSucceeded?.Invoke(this, new SendingSucceededEventArgs(sendingModel));
                }
                catch(Exception exception)
                {
                    readyItem.Status = ReminderItemStatus.Failed;

                    SendingFailed?.Invoke(this, new SendingFailedEventArgs(sendingModel, exception));
                }
                
                _storage.Update(readyItem);
            }

        }

        public void Dispose()
        {
            _awaitingReminderCheckTimer?.Dispose();
            _readyReminderSendTimer?.Dispose();
        }
    }
}
