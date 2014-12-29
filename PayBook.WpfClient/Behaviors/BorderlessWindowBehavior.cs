using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace PayBook.WpfClient
{
    public class BorderlessWindowBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.Loaded += (s, e) => this.AttachBehavior();
        }

        protected override void OnDetaching()
        {
            this.DetachBehavior();

            base.OnDetaching();
        }

        private void AttachBehavior()
        {
            Window source = this.AssociatedObject;

            source.BorderThickness = new Thickness(0);

            source.ResizeMode = ResizeMode.NoResize;

            source.WindowStyle = WindowStyle.None;

            source.MouseLeftButtonDown += this.OnWindowMouseLeftButtonDown;
        }

        private void DetachBehavior()
        {
            Window source = this.AssociatedObject;

            if (source == null)
            {
                return;
            }

            source.MouseLeftButtonDown -= this.OnWindowMouseLeftButtonDown;
        }

        private void OnWindowMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            this.AssociatedObject.DragMove();
        }
    }
}
