using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GaSchedule
{
    public static class CallingEndpoint
    {
        private static string _baseUrl = "https://localhost:5001/api";
        public static async void GetData()
        {
           

            Console.WriteLine("Initializing Endpoint");
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"{_baseUrl}/Data/GetData");
            response.Wait();
            if (response.IsCompleted)
            {
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var message = result.Content.ReadAsStringAsync();
                    message.Wait();
                    Console.WriteLine(message.Result);
                    Console.WriteLine("Endpoint Successful");
                    Console.WriteLine("Initializing Time Table");

                }
            }

            
           
        }
    }
}

