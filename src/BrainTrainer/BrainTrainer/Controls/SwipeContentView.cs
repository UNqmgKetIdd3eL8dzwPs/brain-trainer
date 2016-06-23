using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace BrainTrainer.Controls
{
    public class SwipeContentView : ContentView
    {
        public event EventHandler SwipeDown;
        public event EventHandler SwipeUp;
        public event EventHandler SwipeLeft;
        public event EventHandler SwipeRight;


        public static readonly BindableProperty SwipeLeftCommandProperty =
            BindableProperty.Create<SwipeContentView, ICommand>(w => w.SwipeLeftCommand, default(ICommand),
                BindingMode.TwoWay, (bindable, value) => true);

        public ICommand SwipeLeftCommand
        {
            get { return (ICommand) GetValue(SwipeLeftCommandProperty); }
            set { SetValue(SwipeLeftCommandProperty, value); }
        }


        public static readonly BindableProperty SwipeRightCommandProperty =
            BindableProperty.Create<SwipeContentView, ICommand>(w => w.SwipeRightCommand, default(ICommand),
                BindingMode.TwoWay, (bindable, value) => true);

        public ICommand SwipeRightCommand
        {
            get { return (ICommand) GetValue(SwipeRightCommandProperty); }
            set { SetValue(SwipeRightCommandProperty, value); }
        }

        public static readonly BindableProperty SwipeUpCommandProperty =
            BindableProperty.Create<SwipeContentView, ICommand>(w => w.SwipeUpCommand, default(ICommand),
                BindingMode.TwoWay, (bindable, value) => true);

        public ICommand SwipeUpCommand
        {
            get { return (ICommand) GetValue(SwipeUpCommandProperty); }
            set { SetValue(SwipeUpCommandProperty, value); }
        }

        public static readonly BindableProperty SwipeDownCommandProperty =
            BindableProperty.Create<SwipeContentView, ICommand>(w => w.SwipeDownCommand, default(ICommand),
                BindingMode.TwoWay, (bindable, value) => true);

        public ICommand SwipeDownCommand
        {
            get { return (ICommand) GetValue(SwipeDownCommandProperty); }
            set { SetValue(SwipeDownCommandProperty, value); }
        }


        public void OnSwipeDown()
        {
            if (SwipeDown != null)
                SwipeDown(this, null);
            if (SwipeDownCommand != null && SwipeDownCommand.CanExecute(null))
            {
                SwipeDownCommand.Execute(null);
            }
        }

        public void OnSwipeUp()
        {
            if (SwipeUp != null)
                SwipeUp(this, null);
            if (SwipeUpCommand != null && SwipeUpCommand.CanExecute(null))
            {
                SwipeUpCommand.Execute(null);
            }
        }

        public void OnSwipeLeft()
        {
            if (SwipeLeft != null)
                SwipeLeft(this, null);
            if (SwipeLeftCommand != null && SwipeLeftCommand.CanExecute(null))
            {
                SwipeLeftCommand.Execute(null);
            }
        }

        public void OnSwipeRight()
        {
            if (SwipeRight != null)
                SwipeRight(this, null);
            if (SwipeRightCommand != null && SwipeRightCommand.CanExecute(null))
            {
                SwipeRightCommand.Execute(null);
            }
        }
    }
}
