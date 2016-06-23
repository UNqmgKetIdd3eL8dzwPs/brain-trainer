using System.Collections.ObjectModel;
using System.Linq;
using BrainTrainer.DataObjects;

namespace BrainTrainer.ViewModels
{
    class MainViewModel : BTViewModelBase
    {
        private ObservableCollection<Question> _questions;

        public MainViewModel()
        {

            var randomQuestions =  ServiceClient.GetRandomQuestionsPack().GetAwaiter();
            randomQuestions.OnCompleted(() =>
            {
                Questions = new ObservableCollection<Question>(randomQuestions.GetResult().Select(question => new Question(question)));
            });
        }

        public ObservableCollection<Question> Questions
        {
            get { return _questions; }
            set { SetProperty(ref _questions, value); }
        }
    }
}
