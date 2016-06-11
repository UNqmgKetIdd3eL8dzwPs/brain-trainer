using BrainTrainer.Client;
using MvvmHelpers;

namespace BrainTrainer.ViewModels
{
    class BTViewModelBase : BaseViewModel
    {
        protected QuestionsDBServiceClient ServiceClient => new QuestionsDBServiceClient();

        /// <summary>
        /// Called when the view appears.
        /// </summary>
        public virtual void OnViewAppearing()
        {}

        /// <summary>
        /// Called when the view disappears.
        /// </summary>
        public virtual void OnViewDisappearing()
        {}
    }
}
