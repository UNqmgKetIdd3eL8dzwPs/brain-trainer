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
        }

        public ObservableCollection<Question> Questions
        {
            get { return _questions; }
            set { SetProperty(ref _questions, value); }
        }

        public async override void OnViewAppearing()
        {
            base.OnViewAppearing();
            var randomQuestions = await ServiceClient.GetRandomQuestionsPack();
            Questions = new ObservableCollection<Question>(randomQuestions.Select(question => new Question(question)));

        }
    }
}
