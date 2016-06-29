using BrainTrainer.Client;
using MvvmHelpers;

namespace BrainTrainer.ViewModels
{
    class BTViewModelBase : BaseViewModel
    {
        protected QuestionsClient ServiceClient => new QuestionsClient(@"http://db.chgk.info/xml/");

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
