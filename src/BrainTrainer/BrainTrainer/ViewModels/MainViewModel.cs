using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BrainTrainer.Client;
using BrainTrainer.Client.Models;
using BrainTrainer.Client.UrlSerializer;
using BrainTrainer.Collections;
using BrainTrainer.DataObjects;
using Xamarin.Forms;

namespace BrainTrainer.ViewModels
{
    class MainViewModel : BTViewModelBase
    {
        private BtQueue<Question> _questions;
        private int _questionsLimit = 15;
        private Question _currentQuestion;
        private ICommand _nextQuestionCommand;
        private int _minNumberOfElements = 10;
        private ICommand _showAnswerCommand;
        private bool _isAnswerShowed;

        public MainViewModel()
        {
            var randomQuestions =  ServiceClient.GetQuestions(App.Settings).GetAwaiter();
            randomQuestions.OnCompleted(() => InitializeQuestions(randomQuestions));
        }

        public ICommand NextQuestionCommand
            => _nextQuestionCommand ?? (_nextQuestionCommand = new Command(() => OnNextQuestion()));

        public ICommand ShowAnswerCommand
            => _showAnswerCommand ?? (_showAnswerCommand = new Command(() => OnShowAnswer()));

        public bool IsAnswerShowed
        {
            get { return _isAnswerShowed; }
            set { SetProperty(ref _isAnswerShowed, value); }
        }

        public Question CurrentQuestion
        {
            get { return _currentQuestion; }
            set { SetProperty(ref _currentQuestion, value); }
        }

        private void InitializeQuestions(TaskAwaiter<IEnumerable<searchQuestion>> randomQuestions)
        {
            _questions = new BtQueue<Question>(randomQuestions.GetResult().Select(question => new Question(question)));
            _questions.MinNumberOfElements = _minNumberOfElements;
            _questions.MinNumberReached += MinNumberReached;
            CurrentQuestion = _questions.Dequeue();
        }

        private void OnNextQuestion()
        {
            if (_questions != null)
            {
                IsAnswerShowed = false;
                CurrentQuestion = _questions.Dequeue();
            }
        }

        private void OnShowAnswer()
        {
            IsAnswerShowed = true;
        }

        private async void MinNumberReached(object sender, EventArgs eventArgs)
        {
            var moreQuestions = await ServiceClient.GetQuestions(App.Settings);
            var searchQuestions = moreQuestions.ToList();
            if (moreQuestions != null && searchQuestions.Any())
            {
                _questions.QueueRange(searchQuestions.Select(question => new Question(question)));
            }
        }
    }
}
