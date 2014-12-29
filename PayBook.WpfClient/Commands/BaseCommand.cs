using System;
using System.Windows;
using System.Windows.Input;
using PayBook.ViewModels;

namespace PayBook.WpfClient.Commands
{
    public abstract class BaseCommand : Freezable, ICommand
    {
        private INavigationService _navigationService;

        public abstract void Execute(object parameter);

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

        protected override Freezable CreateInstanceCore()
        {
            return null;
        }

        public INavigationService NavigationService
        {
            get
            {
                if (_navigationService == null)
                    _navigationService = App.Container.GetExportedValue<INavigationService>();

                return _navigationService;
            }
        }

    }

}
