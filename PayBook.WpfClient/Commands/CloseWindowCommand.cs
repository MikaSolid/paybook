using System;
using System.Windows;

namespace PayBook.WpfClient.Commands
{
    public class CloseWindowCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            var w = parameter as Window;

            if (w == null)
                throw new ArgumentException("CommandParameter must be Window type");
            
            w.Close();
        }
    }
}