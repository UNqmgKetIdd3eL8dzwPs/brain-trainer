using System.Collections.Generic;
using System.Threading.Tasks;
using BrainTrainer.Client.Models;
using BrainTrainer.Client.Service;
using BrainTrainer.Client.UrlSerializer;

namespace BrainTrainer.Client
{
    public class QuestionsClient : BaseServiceClient
    {
        public QuestionsClient(string baseApiAddress) : base(baseApiAddress)
        {
        }

        public async Task<IEnumerable<searchQuestion>> GetQuestions(Settings settings)
        {
           return (await GetObject<search>(UrlConverter.ToUrl(settings))).Items;
        }
    }
}