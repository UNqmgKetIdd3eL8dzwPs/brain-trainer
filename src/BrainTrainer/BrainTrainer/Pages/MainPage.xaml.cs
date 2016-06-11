using BrainTrainer.ViewModels;

namespace BrainTrainer.Pages
{
    public partial class MainPage : BaseContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
