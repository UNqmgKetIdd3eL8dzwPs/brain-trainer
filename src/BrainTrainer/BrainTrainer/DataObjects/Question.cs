using BrainTrainer.Client.Models;
using Xamarin.Forms;

namespace BrainTrainer.DataObjects
{
    //ToDO: investigate and remove unnecesssary properties (i.e. tournament properties)
    class Question : BindableObject
    {
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
            this.QuestionText = searchQuestion.Question;
            this.Rating = searchQuestion.Rating;
            this.QuestionId = searchQuestion.QuestionId;
            this.RatingNumber = searchQuestion.RatingNumber;
            this.Sources = searchQuestion.Sources;
            this.TextId = searchQuestion.TextId;
            this.Topic = searchQuestion.Topic;
            this.Type = searchQuestion.Type;
            this.TypeNum = searchQuestion.TypeNum;
        }

        //public string TourFileName{get; set;}

        //public string TournamentFileName{get; set;}

        public string QuestionId{get; set;}

        public string ParentId{get; set;}

        public string Number{get; set;}

        public string Type{get; set;}

        public string TypeNum{get; set;}

        public string TextId{get; set;}

        public string QuestionText{get; set;}

        public string Answer{get; set;}

        public string PassCriteria{get; set;}

        public string Authors{get; set;}

        public string Sources{get; set;}

        public string Comments{get; set;}

        public string Rating{get; set;}

        public string RatingNumber{get; set;}

        public string Complexity{get; set;}

        public string Topic{get; set;}

        public string ProcessedBySearch{get; set;}

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

        public string Notices{get; set;}

    }
}
