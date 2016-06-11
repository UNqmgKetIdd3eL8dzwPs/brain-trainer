using System.Collections.Generic;
using System.Threading.Tasks;
using BrainTrainer.Client.Models;
using BrainTrainer.Client.Service;

namespace BrainTrainer.Client
{
    public class QuestionsDBServiceClient
    {
        private const string SearchQuestionPath = "xml/questions/types1";
        private const string RandomQuestionPath = "xml/random";

        private readonly BaseServiceClient _client = new BaseServiceClient(@"http://db.chgk.info/");

        public async Task<IEnumerable<searchQuestion>> GetRandomQuestionsPack()
        {
            var getPackTask = await _client.GetObject<search>(RandomQuestionPath);
            return getPackTask.Items;
        }
    }
}
