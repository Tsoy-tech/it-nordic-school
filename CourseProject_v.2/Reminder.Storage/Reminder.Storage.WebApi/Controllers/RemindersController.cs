using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;

namespace Reminder.Storage.WebApi.Controllers
{
    [ApiController]
    [Route("api/reminders")] 
    //[controller] - шаблон
    public class RemindersController : ControllerBase
    {
        private readonly IReminderStorage _storage;
        private readonly ILogger<RemindersController> _logger;

        public RemindersController(ILogger<RemindersController> logger, IReminderStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reminderItems = _storage.GetList(new[] 
            { ReminderItemStatus.Awaiting, 
                ReminderItemStatus.Failed, 
                ReminderItemStatus.ReadyToSend, 
                ReminderItemStatus.SuccessfullySent
            });

            var result = reminderItems.Select(ri => new ReminderItemGetModel(ri)).ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var reminderItem = _storage.Get(id);

            if (reminderItem == null)
                return NotFound();

            var model = new ReminderItemGetModel(reminderItem);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Add([FromBody]ReminderItemAddModel model)
        {
            ReminderItem reminderItem = new ReminderItem(
                model.Date,
                model.Message,
                model.AccountId,
                model.Status
            );

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _storage.Add(reminderItem);

            return CreatedAtAction(nameof(Get), new { id = reminderItem.Id}, new ReminderItemGetModel(reminderItem));
        }
    }
}
