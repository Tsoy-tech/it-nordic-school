using System;
using System.Collections.Generic;

namespace Reminder.Storage.Core
{
    public interface IReminderStorage
    {
        void Add(ReminderItem reminderItem);

        void Update(ReminderItem reminderItem);

        ReminderItem Get(Guid id);

        List<ReminderItem> GetList(
            IEnumerable<ReminderItemStatus> statuses, 
            int count = -1, // "-1" - все 
            int startPosition = 0);
    }
}
