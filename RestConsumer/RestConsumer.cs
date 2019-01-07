using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RestConsumer
{
    public class RestConsumer
    {
        private const string URI = "https://mmo-restservicetest4.azurewebsites.net/api/meassurements";

        public RestConsumer() { }

        public void Start()
        {
            GetAll();
            GetOne();
        }

        private void GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(URI).Result;
                IList<Meassurement> cList = JsonConvert.DeserializeObject<IList<Meassurement>>(content);
                
                foreach (Meassurement obj in clist)
                {
                    Console.WriteLine(obj);
                }
            }
        }

        private void GetOne(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(URI).Result;
                Meassurement obj = JsonConvert.DeserializeObject<Meassurement>(content);
                
                Console.WriteLine(obj);
            }
        }

        private void PostOne()
        {
            Meassurement obj = new Meassurement();

            using (HttpClient client = new HttpClient())
            {
                string content = new StringContent(obj, Encoding.UTF8, "application/json");
                client.PostAsync(URI, content);
            }
        }
    }
}
