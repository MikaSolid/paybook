using PayBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PayBook.ViewModels
{
    public abstract class BaseViewVM : BaseVM
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            protected set
            {
                if (_title == value) return;
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public abstract void LoadModel();

        public RelayCommand NavigateTo(BaseViewVM view)
        {
            return new RelayCommand(a =>
                {
                    Shell.Navigate(view);
                });
        }

        private ICommand _navigateToHub;

        public ICommand NavigateToHub
        {
            get
            {
                return _navigateToHub = _navigateToHub ??
                   new RelayCommand(
                       p => Shell.Navigate(new HubVM()),
                       p => !(this is HubVM));
            }
        }

        public IModelService ModelService
        {
            get
            {
                return Container.GetInstance().Resolve<IModelService>();
            }
        }

        public ShellVM Shell
        {
            get
            {
                return Container.GetInstance().Resolve<ShellVM>();
            }
        }

        public virtual bool CanNavigateBack
        {
            get { return true; }
        }
    }
}