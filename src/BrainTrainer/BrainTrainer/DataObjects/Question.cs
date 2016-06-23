using System;
using System.Linq;
using System.Threading.Tasks;
using BrainTrainer.Client.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace BrainTrainer.DataObjects
{
    //ToDO: investigate and remove unnecesssary properties (i.e. tournament properties)
    class Question : ObservableObject
    {
        private string _questionId;
        private string _parentId;
        private string _number;
        private string _type;
        private string _typeNum;
        private string _textId;
        private string _questionText;
        private string _answer;
        private string _passCriteria;
        private string _authors;
        private string _sources;
        private string _comments;
        private string _rating;
        private string _ratingNumber;
        private string _complexity;
        private string _topic;
        private string _processedBySearch;
        private string _notices;
        private ImageSource _image;
        private const string _webImagePath = @"http://db.chgk.info/images/db/";

        public Question(searchQuestion searchQuestion)
        {
            this.Answer = searchQuestion.Answer;
            this.Authors = searchQuestion.Authors;
            this.Comments = searchQuestion.Comments;
            this.Complexity = searchQuestion.Complexity;
            this.Notices = searchQuestion.Notices;
            this.Number = searchQuestion.Number;
            this.ParentId = searchQuestion.ParentId;
            this.PassCriteria = searchQuestion.PassCriteria;
            this.ProcessedBySearch = searchQuestion.ProcessedBySearch;

            var rawQuestionText = searchQuestion.Question;
            InitQuestionImage(rawQuestionText).GetAwaiter();
            this.Rating = searchQuestion.Rating;
            this.QuestionId = searchQuestion.QuestionId;
            this.RatingNumber = searchQuestion.RatingNumber;
            this.Sources = searchQuestion.Sources;
            this.TextId = searchQuestion.TextId;
            this.Topic = searchQuestion.Topic;
            this.Type = searchQuestion.Type;
            this.TypeNum = searchQuestion.TypeNum;
        }

        private async Task InitQuestionImage(string rawQuestionText)
        {
            if (ContainsImageReference(rawQuestionText))
            {
                var splittedText = rawQuestionText.Split(new string[] {"(pic:", ".jpg)"}, StringSplitOptions.RemoveEmptyEntries);
                var imageFileName = splittedText.FirstOrDefault();
                var imageUri = new Uri(_webImagePath + imageFileName.Trim() + ".jpg");
                Task<ImageSource> result = Task<ImageSource>.Factory.StartNew(() => ImageSource.FromUri(imageUri));
                Image = await result;
                QuestionText = splittedText.LastOrDefault();
            }
            else
            {
                QuestionText = rawQuestionText;
            }
        }

        private bool ContainsImageReference(string rawQuestionText)
        {
            return rawQuestionText.Contains("(pic:") && rawQuestionText.Contains(".jpg)");
        }

        //public string TourFileName{get; set;}

        //public string TournamentFileName{get; set;}

        public string QuestionId
        {
            get { return _questionId; }
            set { SetProperty(ref _questionId, value); }
        }

        public string ParentId
        {
            get { return _parentId; }
            set { SetProperty(ref _parentId, value); }
        }

        public string Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }

        public string Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
        }

        public string TypeNum
        {
            get { return _typeNum; }
            set { SetProperty(ref _typeNum, value); }
        }

        public string TextId
        {
            get { return _textId; }
            set { SetProperty(ref _textId, value); }
        }

        public string QuestionText
        {
            get { return _questionText; }
            set { SetProperty(ref _questionText, value); }
        }

        public ImageSource Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        public string Answer
        {
            get { return _answer; }
            set { SetProperty(ref _answer, value); }
        }

        public string PassCriteria
        {
            get { return _passCriteria; }
            set { SetProperty(ref _passCriteria, value); }
        }

        public string Authors
        {
            get { return _authors; }
            set { SetProperty(ref _authors, value); }
        }

        public string Sources
        {
            get { return _sources; }
            set { SetProperty(ref _sources, value); }
        }

        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
        }

        public string Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }

        public string RatingNumber
        {
            get { return _ratingNumber; }
            set { SetProperty(ref _ratingNumber, value); }
        }

        public string Complexity
        {
            get { return _complexity; }
            set { SetProperty(ref _complexity, value); }
        }

        public string Topic
        {
            get { return _topic; }
            set { SetProperty(ref _topic, value); }
        }

        public string ProcessedBySearch
        {
            get { return _processedBySearch; }
            set { SetProperty(ref _processedBySearch, value); }
        }

        //public string tourId{get; set;}

        //public string tournamentId{get; set;}

        //public string tourTitle{get; set;}

        //public string tournamentTitle{get; set;}

        //public string tourType{get; set;}

        //public string tournamentType{get; set;}

        //public string tourPlayedAt{get; set;}

        //public string tournamentPlayedAt{get; set;}

        //public string tourPlayedAt2{get; set;}

        //public string tournamentPlayedAt2{get; set;}

        public string Notices
        {
            get { return _notices; }
            set { SetProperty(ref _notices, value); }
        }
    }
}
