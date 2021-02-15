using System;
using System.Collections.Generic;
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
        private readonly ILogger<RemindersController> _logger;
        private readonly IReminderStorage _storage;

        public RemindersController(ILogger<RemindersController> logger, IReminderStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }

        [HttpGet]
        public IActionResult GetList([FromQuery(Name = "status")]
        ReminderItemStatus[] statuses = null)
        {
            _logger.LogInformation($"{nameof(GetList)} called");

            if (statuses == null || statuses.Length == 0)
                statuses = new[]
                {
                    ReminderItemStatus.Awaiting,
                    ReminderItemStatus.Failed,
                    ReminderItemStatus.ReadyToSend,
                    ReminderItemStatus.SuccessfullySent
                };

            List <ReminderItem> reminderItems = _storage.GetList(statuses);

            List <ReminderItemGetModel> result = reminderItems
                .Select(ri => new ReminderItemGetModel(ri))
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            _logger.LogInformation($"{nameof(Get)} called");
            var reminderItem = _storage.Get(id);

            if (reminderItem == null)
                return NotFound();

            var model = new ReminderItemGetModel(reminderItem);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Add([FromBody]ReminderItemAddModel model)
        {
            _logger.LogInformation($"{nameof(Add)} called");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ReminderItemRestricted reminderItemRestricted = new ReminderItemRestricted(
                model.Date,
                model.Message,
                model.AccountId,
                model.Status
            );

            Guid id = _storage.Add(reminderItemRestricted);
    
            return CreatedAtAction(nameof(Get), new { id }, new ReminderItemGetModel(reminderItemRestricted.ToReminderItem(id)));
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] ReminderItemUpdateModel model)
        {
            _logger.LogInformation($"{nameof(Update)} called");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reminderItem = _storage.Get(id);
            if (reminderItem == null)
                return NotFound();

            model.UpdateReminderItem(reminderItem);
            _storage.Update(reminderItem);

            return NoContent();
		}

    }
}
