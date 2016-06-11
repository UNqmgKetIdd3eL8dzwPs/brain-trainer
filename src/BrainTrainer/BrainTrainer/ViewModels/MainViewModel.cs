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
            Questions = new ObservableCollection<Question>(ServiceClient.GetRandomQuestionsPack().GetAwaiter().GetResult().Select(question => new Question(question)));
        }

        public ObservableCollection<Question> Questions
        {
            get { return _questions; }
            set { SetProperty(ref _questions, value); }
        }
    }
}
