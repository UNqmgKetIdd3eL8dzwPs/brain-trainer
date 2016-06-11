using BrainTrainer.ViewModels;
using Xamarin.Forms;

namespace BrainTrainer.Pages
{
    public class BaseContentPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext != null & BindingContext is BTViewModelBase)
            {
                var vm = (BTViewModelBase)BindingContext;
                vm.OnViewAppearing();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (BindingContext != null & BindingContext is BTViewModelBase)
            {
                var vm = (BTViewModelBase)BindingContext;
                vm.OnViewDisappearing();
            }
        }
    }
}
