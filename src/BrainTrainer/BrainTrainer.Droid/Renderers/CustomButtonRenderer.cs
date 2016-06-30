using Android.Graphics;
using BrainTrainer.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace BrainTrainer.Droid.Renderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            var button = Control;
            var font = Typeface.CreateFromAsset(Forms.Context.Assets, "roboto-condensed.regular.ttf");
            button.Typeface = font;
        }
    }
}