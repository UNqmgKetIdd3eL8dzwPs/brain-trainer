using System;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using BrainTrainer.Controls;
using BrainTrainer.WinPhone.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;
using Color = Windows.UI.Color;
using Frame = Windows.UI.Xaml.Controls.Frame;

[assembly: ExportRenderer(typeof(SwipeContentView), typeof(SwipeContentViewRenderer))]
namespace BrainTrainer.WinPhone.Renderers
{
    class SwipeContentViewRenderer : ViewRenderer<SwipeContentView, FrameworkElement>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SwipeContentView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                Control.ManipulationCompleted -= Control_ManipulationCompleted;
            }
            if (e.NewElement != null)
            {
                //SetNativeControl(new Frame() {Background = new SolidColorBrush(Color.FromArgb(0,0,0,0))});
                Control.ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateRailsY;
                Control.ManipulationCompleted += Control_ManipulationCompleted;
            }
        }
        
        private void Control_ManipulationCompleted(object sender, Windows.UI.Xaml.Input.ManipulationCompletedRoutedEventArgs e)
        {
            var movePosition = e.Velocities;
            var translationX = movePosition.Linear.X;
            var translationY = movePosition.Linear.Y;

            if (translationY > Math.Abs(translationX))
            {
                if (translationY < 0)
                {
                    Element.OnSwipeUp();
                }
                else
                {
                    Element.OnSwipeDown();
                }
            }
            else
            {
                if (translationX < 0)
                {
                    Element.OnSwipeLeft();
                }
                else
                {
                    Element.OnSwipeRight();
                }
            }
        }
    }
}
