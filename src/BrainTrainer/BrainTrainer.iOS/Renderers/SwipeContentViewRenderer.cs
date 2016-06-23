using BrainTrainer.Controls;
using BrainTrainer.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SwipeContentView), typeof(SwipeContentViewRenderer))]
namespace BrainTrainer.iOS.Renderers
{
    public class SwipeContentViewRenderer : ViewRenderer<ContentView, UIView>
    {
        UISwipeGestureRecognizer _swipeDown;
        UISwipeGestureRecognizer _swipeUp;
        UISwipeGestureRecognizer _swipeLeft;
        UISwipeGestureRecognizer _swipeRight;
        
        protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
        {
            base.OnElementChanged(e);

            _swipeDown = new UISwipeGestureRecognizer(
                () =>
                {
                    SwipeContentView element = (SwipeContentView)this.Element;
                    element.OnSwipeDown();
                }
            )
            {
                Direction = UISwipeGestureRecognizerDirection.Down,
            };

            _swipeUp = new UISwipeGestureRecognizer(
                () =>
                {
                    SwipeContentView element = (SwipeContentView)this.Element;
                    element.OnSwipeUp();
                }
            )
            {
                Direction = UISwipeGestureRecognizerDirection.Up,
            };

            _swipeLeft = new UISwipeGestureRecognizer(
                () =>
                {
                    SwipeContentView element = (SwipeContentView)this.Element;
                    element.OnSwipeLeft();
                }
            )
            {
                Direction = UISwipeGestureRecognizerDirection.Left,
            };

            _swipeRight = new UISwipeGestureRecognizer(
                () =>
                {
                    SwipeContentView element = (SwipeContentView)this.Element;
                    element.OnSwipeRight();
                }
            )
            {
                Direction = UISwipeGestureRecognizerDirection.Right,
            };

            if (e.NewElement == null)
            {
                if (_swipeDown != null)
                {
                    this.RemoveGestureRecognizer(_swipeDown);
                }
                if (_swipeUp != null)
                {
                    this.RemoveGestureRecognizer(_swipeUp);
                }
                if (_swipeLeft != null)
                {
                    this.RemoveGestureRecognizer(_swipeLeft);
                }
                if (_swipeRight != null)
                {
                    this.RemoveGestureRecognizer(_swipeRight);
                }
            }

            if (e.OldElement == null)
            {
                this.AddGestureRecognizer(_swipeDown);
                this.AddGestureRecognizer(_swipeUp);
                this.AddGestureRecognizer(_swipeLeft);
                this.AddGestureRecognizer(_swipeRight);
            }
        }
    }
}