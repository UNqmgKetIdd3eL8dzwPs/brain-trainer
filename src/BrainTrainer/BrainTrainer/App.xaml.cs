using BrainTrainer.Client.Enums;
using BrainTrainer.Client.Extensions;
using BrainTrainer.Pages;
using Xamarin.Forms;

namespace BrainTrainer
{
    public partial class App 
    {
        public App()
        {
            // The root page of your application
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
