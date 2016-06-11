 using System;
 using System.Threading.Tasks;
 using BrainTrainer.Client;

namespace BrainTrainer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestionsDBServiceClient clinet = new QuestionsDBServiceClient();

            //var allQ = clinet.GetRandomQuestionsPack().GetAwaiter().GetResult();
            //var qp = clinet.GetQuestionsAnswersContain("Пушкин").GetAwaiter().GetResult();
            //var qpAsSearch = clinet.GetAllQuestionsAnswersContain("Пушкин").GetAwaiter().GetResult();
            var lastWeekQ = clinet.GetRandomQuestionsPack().GetAwaiter().GetResult();
        }
    }
}
