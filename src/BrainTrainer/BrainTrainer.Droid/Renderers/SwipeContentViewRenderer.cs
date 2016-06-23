using System;
using Android.Views;
using BrainTrainer.Controls;
using BrainTrainer.Droid.Listeners;
using BrainTrainer.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SwipeContentView), typeof(SwipeContentViewRenderer))]
namespace BrainTrainer.Droid.Renderers
{
    public class SwipeContentViewRenderer : ViewRenderer<ContentView, Android.Views.View>
    {
        private readonly SwipeGestureListener _listener;
        private readonly GestureDetector _detector;

        public SwipeContentViewRenderer()
        {
            _listener = new SwipeGestureListener();
            _detector = new GestureDetector(_listener);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                this.GenericMotion -= HandleGenericMotion;
                this.Touch -= HandleTouch;
                _listener.OnSwipeLeft -= HandleOnSwipeLeft;
                _listener.OnSwipeRight -= HandleOnSwipeRight;
                _listener.OnSwipeTop -= HandleOnSwipeTop;
                _listener.OnSwipeDown -= HandleOnSwipeDown;
            }

            if (e.OldElement == null)
            {
                this.GenericMotion += HandleGenericMotion;
                this.Touch += HandleTouch;
                _listener.OnSwipeLeft += HandleOnSwipeLeft;
                _listener.OnSwipeRight += HandleOnSwipeRight;
                _listener.OnSwipeTop += HandleOnSwipeTop;
                _listener.OnSwipeDown += HandleOnSwipeDown;
            }
        }

        void HandleTouch(object sender, TouchEventArgs e)
        {
            _detector.OnTouchEvent(e.Event);
        }

        void HandleGenericMotion(object sender, GenericMotionEventArgs e)
        {
            _detector.OnTouchEvent(e.Event);
        }

        void HandleOnSwipeLeft(object sender, EventArgs e)
        {
            SwipeContentView element = (SwipeContentView)this.Element;
            element.OnSwipeLeft();
        }

        void HandleOnSwipeRight(object sender, EventArgs e)
        {
            SwipeContentView element = (SwipeContentView)this.Element;
            element.OnSwipeRight();
        }

        void HandleOnSwipeTop(object sender, EventArgs e)
        {
            SwipeContentView element = (SwipeContentView)this.Element;
            element.OnSwipeUp();
        }

        void HandleOnSwipeDown(object sender, EventArgs e)
        {
            SwipeContentView element = (SwipeContentView)this.Element;
            element.OnSwipeDown();
        }
    }
}