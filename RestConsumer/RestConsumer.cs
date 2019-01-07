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
            var restDatas = GetAll();

            foreach (Meassurement data in restDatas)
            {
                Console.WriteLine(data);
            }
        }

        private IList<Meassurement> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(URI).Result;
                IList<Meassurement> cList = JsonConvert.DeserializeObject<IList<Meassurement>>(content);
                return cList;
            }
        }

        private Meassurement GetOne(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(URI).Result;
                Meassurement obj = JsonConvert.DeserializeObject<Meassurement>(content);
                return obj;
            }
        }
    }
}
