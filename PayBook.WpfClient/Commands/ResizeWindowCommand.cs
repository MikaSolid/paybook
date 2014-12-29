using System;
using System.Windows;

namespace PayBook.WpfClient.Commands
{
    public class ResizeWindowCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            var w = parameter as Window;

            if (w == null)
                throw new ArgumentException("CommandParameter must be Window type");

            if (w.WindowState == WindowState.Normal)
                w.WindowState = WindowState.Maximized;
            else
                w.WindowState = WindowState.Normal;
        }
    }
}