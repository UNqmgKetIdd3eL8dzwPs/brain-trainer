using System.ComponentModel;
using Xamarin.Forms;

namespace BrainTrainer.Views
{
    public partial class QuestionView : ContentView
    {
        public QuestionView()
        {
            InitializeComponent();
        }

        private void BindableObject_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == View.IsVisibleProperty.PropertyName)
            {
                var control = sender as View;
                if (control != null)
                {
                    control.HeightRequest = control.IsVisible ? this.Height/2 : 0;
                }
            }
        }
    }
}
