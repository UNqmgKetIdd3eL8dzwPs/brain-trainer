using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BrainTrainer.Client.Extensions;

namespace BrainTrainer.Client.Service
{
    class BaseServiceClient
    {
        private readonly string ApiUri = String.Empty;

        internal BaseServiceClient(string baseApiAddress)
        {
            ApiUri = baseApiAddress;
        }

        internal async Task<T> GetObject<T>(string uri) where T : class
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApiUri);
            try
            {
                var responseMessage = await client.GetAsync(uri);
                client.Dispose();
                var responseString = await responseMessage.Content.ReadAsStringAsync();
                responseMessage.Dispose();

                var resultObjectList = responseString.XmlDeserializeFromString(typeof(T)) as T;
                return resultObjectList;
            }
            catch (WebException exception)
            {
                throw;
            }
        }

        internal async Task<List<T>> GetObjects<T>(string uri)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(ApiUri);
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

                var resultObjectList = responseString.XmlDeserializeFromString(typeof(List<T>)) as List<T>;
                return resultObjectList;
            }
            catch (WebException exception)
            {
                throw;
            }
        }
    }
}