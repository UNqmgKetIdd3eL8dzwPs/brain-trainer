using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrainTrainer.Client.Models;
using BrainTrainer.Client.Service;

namespace BrainTrainer.Client
{
    public class QuestionsDBServiceClient
    {
        private const string SearchQuestionPath = "xml/questions/types1/";
        private const string RandomQuestionPath = "xml/random";

        private const string QuestionsDateNumberLimitFlag = "/from_{0}/limit{1}";
        private const string SearchTextFlagAnswer = "/A?page=";

        private const int NumberOfItemsInPage = 50;

        private readonly BaseServiceClient _client = new BaseServiceClient(@"http://db.chgk.info/");

        public async Task<IEnumerable<searchQuestion>> GetRandomQuestionsPack()
        {
            var getPackTask = await _client.GetObject<search>(RandomQuestionPath);
            return getPackTask.Items;
        }

        public async Task<IEnumerable<searchQuestion>> GetRandomQuestionsPackFromDate(DateTime startDateTime, int numberOfQuestions = 100)
        {
            var getPackTask = await _client.GetObject<search>(RandomQuestionPath+ String.Format(QuestionsDateNumberLimitFlag, startDateTime.ToString("yyyy-MM-dd"), numberOfQuestions));
            return getPackTask.Items;
        }

        public async Task<IEnumerable<searchQuestion>> GetQuestionsAnswersContain(string containedText, int pageNumber = 1)
        {
            var actualPageNumber = pageNumber - 1;
            var getQuestionsWithAnswerstask =
                await _client.GetObject<search>(SearchQuestionPath + containedText + SearchTextFlagAnswer+ actualPageNumber);
            return getQuestionsWithAnswerstask.Items;
        }

        public async Task<IEnumerable<searchQuestion>> GetAllQuestionsAnswersContain(string containedText)
        {
            var resultQuestionsCollection = new List<searchQuestion>();
            var getFirstQuestionsWithAnswerstask =
                await _client.GetObject<search>(SearchQuestionPath + containedText + SearchTextFlagAnswer);

            resultQuestionsCollection.AddRange(getFirstQuestionsWithAnswerstask.Items);

            int allItemsCount = getFirstQuestionsWithAnswerstask.Total;
            int allPagesCount = (int) Math.Ceiling((decimal)allItemsCount/NumberOfItemsInPage);

            for (int currentpageIndex = 2; currentpageIndex < allPagesCount+1; currentpageIndex++)
            {
                var currentPageQuestions = await GetQuestionsAnswersContain(containedText, currentpageIndex);
                resultQuestionsCollection.AddRange(currentPageQuestions);
            }
            return resultQuestionsCollection;
        }
    }
}
