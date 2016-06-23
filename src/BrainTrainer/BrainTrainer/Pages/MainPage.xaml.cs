using System;
using BrainTrainer.ViewModels;
using Xamarin.Forms;

namespace BrainTrainer.Pages
{
    public partial class MainPage : BaseContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void SwipeContentView_OnSwipeLeft(object sender, EventArgs e)
        {
            AnimateViewOnSwipe();
        }

        private async void AnimateViewOnSwipe()
        {
            MainSwipeContentView.FadeTo(0, 125);
            await MainSwipeContentView.TranslateTo(-MainSwipeContentView.Width, 0, 125);

            MainSwipeContentView.TranslationX = MainSwipeContentView.Width;

            MainSwipeContentView.TranslateTo(0, 0, 125);
            await MainSwipeContentView.FadeTo(1, 125);
        }
    }
}
