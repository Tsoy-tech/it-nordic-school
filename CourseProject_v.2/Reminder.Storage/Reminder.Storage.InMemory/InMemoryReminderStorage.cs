using System;
using System.Linq;
using System.Collections.Generic;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory
{
    public class InMemoryReminderStorage : IReminderStorage
    {
        private readonly Dictionary<Guid, ReminderItem> _dictionary = new Dictionary<Guid, ReminderItem>();
        //readonly только к элементам, которые изменяются ТОЛЬКО в КОНСТРУКТОРЕ!!! Это делается для эффективного распределения памяти!
        public Guid Add(ReminderItemRestricted reminderItemResctricted)
        {
            Guid id = Guid.NewGuid();
            _dictionary.Add(id, reminderItemResctricted.ToReminderItem(id));
            return id;
        }

        public void Update(ReminderItem reminderItem)
        {
            var item = Get(reminderItem.Id);

            if (item == null)
            {
                throw new KeyNotFoundException();
            }

            item.Date = reminderItem.Date;
            item.Message = reminderItem.Message;
            item.AccountId = reminderItem.AccountId;
            item.Status = reminderItem.Status;

        }

        public ReminderItem Get(Guid id)
        {
            return _dictionary.ContainsKey(id)
                ? _dictionary[id]
                : null;
        }

        public List<ReminderItem> GetList(IEnumerable<ReminderItemStatus> statuses, int count = -1, int startPosition = 0)
        {
            var result = _dictionary.Values.Where(x => statuses.Contains(x.Status)).Skip(startPosition);

            if (count > 0)
                result.Take(count);

            return result.ToList();
        }
    }
}
