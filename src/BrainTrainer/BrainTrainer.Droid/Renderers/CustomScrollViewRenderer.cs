using Android.Views;
using BrainTrainer.Controls;
using BrainTrainer.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomScrollView), typeof(CustomScrollViewRenderer))]
namespace BrainTrainer.Droid.Renderers
{
    public class CustomScrollViewRenderer : ScrollViewRenderer
    {
        public override bool DispatchTouchEvent(MotionEvent e)
        {
            if (Parent != null)
            {
                var swipeContentViewRenderer = Parent.Parent as SwipeContentViewRenderer;
                if (swipeContentViewRenderer != null)
                {
                    swipeContentViewRenderer._detector.OnTouchEvent(e);
                }
            }
            return base.DispatchTouchEvent(e);
        }
    }
}