using System;
using System.Windows;
using System.Windows.Input;
using PayBook.Model;
using PayBook.ViewModels;

namespace PayBook.WpfClient.Commands
{
    public abstract class BaseCommand : Freezable, ICommand
    {
        private INavigationService _navigationService;

        private IModelService _modelService;

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

        public IModelService ModelService
        {
            get
            {
                if (_modelService == null)
                    _modelService = App.Container.GetExportedValue<IModelService>();

                return _modelService;
            }
        }

    }

}
