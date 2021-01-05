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
            const string relativeUrl = "";

            var request = new HttpRequestMessage(HttpMethod.Post, _baseWebApiUrl + relativeUrl);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            var model = new ReminderItemAddModel(reminderItem);
            var content = JsonConvert.SerializeObject(model);

            request.Content = new StringContent(
                content,
                Encoding.UTF8,
                "application/Json"
                );

            HttpResponseMessage response = _httpClient.SendAsync(request).GetAwaiter().GetResult(); //принять ответ

            if(response.StatusCode != HttpStatusCode.OK)

        }

        public ReminderItem Get(Guid id)
        {
            const string relativeUrl = "";

            var request = new HttpRequestMessage(HttpMethod.Get, _baseWebApiUrl + relativeUrl);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            HttpResponseMessage response = _httpClient.SendAsync(request).GetAwaiter().GetResult(); //принять ответ

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            if (response.StatusCode != HttpStatusCode.OK) //проверить статус код
                throw CreateException(response);

            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            ReminderItemGetModel model = JsonConvert.DeserializeObject<ReminderItemGetModel>(content);

            if (model == null)
                throw new Exception("Body cannot be parsed as List<ReminderItemGetModel>");

            return model.ToReminderItem();
        }

        public List<ReminderItem> GetList(IEnumerable<ReminderItemStatus> statuses, int count = -1, int startPosition = 0)
        {
            const string relativeUrl = "";

            var request = new HttpRequestMessage(HttpMethod.Get, _baseWebApiUrl + relativeUrl);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            HttpResponseMessage response = _httpClient.SendAsync(request).GetAwaiter().GetResult(); //принять ответ

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
            throw new NotImplementedException();
        }

        private Exception CreateException(HttpResponseMessage response)
        {
            return new Exception($"Status code: {response.StatusCode}\n" +
                $"Content:\n{response.Content.ReadAsStringAsync().GetAwaiter().GetResult()}");
        }


    }
}
