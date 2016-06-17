using System.Collections.Generic;
using System.Threading.Tasks;
using BrainTrainer.Client.Models;
using BrainTrainer.Client.Service;

namespace BrainTrainer.Client
{
    public class QuestionsClient : BaseServiceClient
    {
        public QuestionsClient(string baseApiAddress) : base(baseApiAddress)
        {
        }

        public Task<IEnumerable<searchQuestion>> GetQuestions(Settings settings)
        {
            return null;
        }
    }
}