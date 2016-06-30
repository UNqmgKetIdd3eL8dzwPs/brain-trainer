using Android.Graphics;
using Android.Views;
using Android.Widget;
using BrainTrainer.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(CustomLabelRenderer))]
namespace BrainTrainer.Droid.Renderers
{
    public class CustomLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var label = Control;
            var font = Typeface.CreateFromAsset(Forms.Context.Assets, "roboto-condensed.regular.ttf");
            label.Typeface = font;
        }
    }
}