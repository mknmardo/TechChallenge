using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WH.RiskApplication.TechChallenge.Utils
{
    public class HttpHelper
    {
        private readonly HttpClient _client;

        public HttpClient Client
        {
            get
            {
                return _client;
            }
        }

        public HttpHelper(Uri baseAddress)
        {
            _client = new HttpClient { BaseAddress = baseAddress };

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public TModel Get<TModel>(string endpoint)
        {
            return GetResult<TModel>(Client.GetAsync(endpoint).Result);
        }

        public List<TModel> GetList<TModel>(string endpoint)
        {
            return JsonConvert.DeserializeObject<List<TModel>>(Client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result);
        }

        public TResult Post<TModel, TResult>(string endpoint, TModel model)
        {
            return GetResult<TResult>(Client.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result);
        }

        private static TResult GetResult<TResult>(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<TResult>(response.Content.ReadAsStringAsync().Result);
        }

    }
}
