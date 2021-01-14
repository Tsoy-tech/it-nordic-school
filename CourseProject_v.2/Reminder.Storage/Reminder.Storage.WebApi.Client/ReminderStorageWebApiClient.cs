using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Reminder.Storage.WebApi.Core;
using System.Linq;
using System.Text;

namespace Reminder.Storage.WebApi.Client
{
    public class ReminderStorageWebApiClient : IReminderStorage
    {
        private readonly HttpClient _httpClient;
        //https://localhost:44354/api/reminders
        private readonly string _baseWebApiUrl;

        public ReminderStorageWebApiClient(string baseWebApiUrl)
        {
            if (baseWebApiUrl == null)
                throw new ArgumentException(nameof(baseWebApiUrl));

            _baseWebApiUrl = baseWebApiUrl.TrimEnd('/') + '/';
            _httpClient = new HttpClient();
        }

        public void Add(ReminderItem reminderItem)
        {
            HttpResponseMessage response = CallWebApi(HttpMethod.Post, string.Empty, 
                new ReminderItemAddModel(reminderItem));

            //Check Response status codes
            if (response.StatusCode != HttpStatusCode.Created)
                throw CreateException(response);

            // read and parse response Body
            // parse response Model
            // return the Result
        }

        public ReminderItem Get(Guid id)
        {
            HttpResponseMessage response = CallWebApi(HttpMethod.Get, id.ToString());

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            if (response.StatusCode != HttpStatusCode.OK) //проверить статус код
                throw CreateException(response);

            // Read response Body
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            // Parse response Model
            ReminderItemGetModel model = JsonConvert.DeserializeObject<ReminderItemGetModel>(content);

            if (model == null)
                throw new Exception("Body cannot be parsed as List<ReminderItemGetModel>");
            //Return the Result
            return model.ToReminderItem();
        }

        public List<ReminderItem> GetList(IEnumerable<ReminderItemStatus> statuses, int count = -1, int startPosition = 0)
        {
            string relativeUrl = string.Empty;
            var statusList = statuses.ToList();
            
            if(statusList.Count > 0)
			{
                relativeUrl += '?';
                foreach(var status in statusList)
				{
                    relativeUrl += "status=" + status + '&';
				}


			}


            HttpResponseMessage response = CallWebApi(HttpMethod.Get, String.Empty);

            if (response.StatusCode != HttpStatusCode.OK) //проверить статус код
                throw CreateException(response);

            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            List<ReminderItemGetModel> list = JsonConvert.DeserializeObject <List<ReminderItemGetModel>>(content);

            if (list == null)
                throw new Exception("Body cannot be parsed as List<ReminderItemGetModel>");

            return list.Select(m => m.ToReminderItem()).ToList();
        }
        public void Update(ReminderItem reminderItem)
        {
            HttpResponseMessage response = CallWebApi(HttpMethod.Put, reminderItem.Id.ToString(),
                new ReminderItemUpdateModel(reminderItem));

            //Check Response status codes
            if (response.StatusCode != HttpStatusCode.NoContent)
                throw CreateException(response);
        }

        private Exception CreateException(HttpResponseMessage response)
        {
            return new Exception($"Status code: {response.StatusCode}\n" +
                $"Content:\n{response.Content.ReadAsStringAsync().GetAwaiter().GetResult()}");
        }

        private HttpResponseMessage CallWebApi(HttpMethod httpMethod, string relativeUrl, object model = null)
		{
            //Prepare Request
            var request = new HttpRequestMessage(httpMethod, _baseWebApiUrl + relativeUrl);

            //Add Headers
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            if(model != null)
			{
                string content = JsonConvert.SerializeObject(model);
                request.Content = new StringContent(
                    content,
                    Encoding.UTF8,
                    "application/Json");
            }

            return _httpClient.SendAsync(request).GetAwaiter().GetResult();
        }

    }
}
