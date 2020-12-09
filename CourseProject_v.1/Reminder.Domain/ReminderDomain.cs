using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Reminder.Domain.EventsArgs;
using Reminder.Domain.Model;
using Reminder.Storage.Core;

namespace Reminder.Domain
{
    public class ReminderDomain : IDisposable
    {
        //Доработать конструктор!!!

        private readonly IReminderStorage _storage;
        private readonly TimeSpan _awaitingRemindersCheckPeriod;
        private readonly TimeSpan _readyReminderCheckPeriod;

        private Timer _awaitingReminderCheckTimer; //using for Method Run
        private Timer _readyReminderSendTimer;

        public event EventHandler<SendingSucceededEventArgs> SendingSucceeded;
        public event EventHandler<SendingFailedEventArgs> SendingFailed;

        public Action<SendReminderModel> SendReminder{ get; set; }

        public ReminderDomain(IReminderStorage storage) : this(storage, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1)) { }
        public ReminderDomain( IReminderStorage storage, TimeSpan awaitingRemindersCheckingPeriod, TimeSpan readyReminderCheckPeriod)
        {
            _storage = storage;
            _awaitingRemindersCheckPeriod = awaitingRemindersCheckingPeriod;
            _readyReminderCheckPeriod = readyReminderCheckPeriod;
        }

        public void AddReminder(ReminderItem reminder)
		{
            _storage.Add(reminder);
		}

        public void AddReminderModel(AddReminderModel addReminderModel)
        {
            _storage.Add(addReminderModel.ToReminderItem()); //from Model to Object
        }

        public void Run()
        {
           _awaitingReminderCheckTimer = new Timer(CheckAwaitingReminders, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
           _readyReminderSendTimer = new Timer(SendReadyToSendReminders, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
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
                    SendReminder?.Invoke(sendingModel);

                    //Remind(item); Попытка послать уведомление
                    item.Status = ReminderItemStatus.ReadyToSend;
                    
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

        public void Dispose()
        {
            _awaitingReminderCheckTimer?.Dispose();
            _readyReminderSendTimer?.Dispose();
        }
    }
}
