using System;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Threading;

namespace PayBook.WpfClient
{
    public class ClockBehavior : Behavior<TextBlock>
    {
        public string Format { get; set; }

        protected override void OnAttached()
        {
            base.OnAttached();

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
              {
                  AssociatedObject.Text = DateTime.Now.ToString(Format);
              }, this.Dispatcher);

        }
    }
}