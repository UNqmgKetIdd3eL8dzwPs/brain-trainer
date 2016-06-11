using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrainTrainer.Client
{
    public class WebClient
    {
        private const string ApiUri = @"http://db.chgk.info/xml";

        private const string SearchQuestionPath = "/questions/types1";
        private const string RandomQuestionPath = "/random";

        public async Task<object> GetRandomQuestionsPack()
        {
            var getPackTask = await GetObjects<object>(RandomQuestionPath);
            return getPackTask;
        }

        private static async Task<List<T>> GetObjects<T>(string uri, string baseUrl = ApiUri)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            try
            {
                var responseMessage = await client.GetAsync(uri);
                client.Dispose();
                if (!responseMessage.IsSuccessStatusCode)
                {
                    responseMessage.Dispose();
                    return null;
                }
                var responseString = await responseMessage.Content.ReadAsStringAsync();
                if (responseString == "null")
                    return null;

                //var resultObjectList = JsonConvert.DeserializeObject<List<T>>(responseString);
                var resultObjectList = new List<T>();
                return resultObjectList;
            }
            catch (WebException exception)
            {
                throw;
            }
        }

    }
}
