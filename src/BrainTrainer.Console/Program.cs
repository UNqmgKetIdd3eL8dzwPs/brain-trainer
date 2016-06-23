 using System;
 using System.Threading.Tasks;
 using BrainTrainer.Client;

namespace BrainTrainer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestionsClient clinet = new QuestionsClient(@"http://db.chgk.info/");

            //var allQ = clinet.GetRandomQuestionsPack().GetAwaiter().GetResult();
            //var qp = clinet.GetQuestionsAnswersContain("Пушкин").GetAwaiter().GetResult();
            //var qpAsSearch = clinet.GetAllQuestionsAnswersContain("Пушкин").GetAwaiter().GetResult();
            var lastWeekQ = clinet.GetQuestions(new Settings()).GetAwaiter().GetResult();
        }
    }
}
