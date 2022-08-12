using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimeTableUI.Contracts;
using TimeTableUI.Models.VMs;

namespace TimeTableUI.Services
{
    public class ClassRepository : BaseRepository<ClassVM>, IClassRepository
    {
        private readonly IHttpClientFactory _client;

        public ClassRepository(IHttpClientFactory client) : base(client)
        {
            _client = client;
        }

        public async void GenerateTimeTable(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _client.CreateClient();
           // client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
               // return JsonConvert.DeserializeObject<IList<T>>(content);
            }


            
        }

        public async void WriteToJson(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                // return JsonConvert.DeserializeObject<IList<T>>(content);
            }



        }
    }
}
