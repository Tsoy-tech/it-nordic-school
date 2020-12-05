using System;
using System.Collections.Generic;

namespace Reminder.Storage.Core
{
    public interface IReminderStorage
    {
        // Add
        void Add(ReminderItem reminderItem);

        // Update
        void Update(ReminderItem reminderItem);

        // Get
        ReminderItem Get(Guid id);

        // GetList
        List<ReminderItem> GetList(
            IEnumerable<ReminderItemStatus> statuses, 
            int count = -1, // "-1" - все 
            int startPosition = 0);
    }
}
