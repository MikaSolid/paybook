using PayBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PayBook.ViewModels
{
    public class ShellVM : BaseVM
    {
        private readonly IModelService _modelService;

        public ShellVM(IModelService modelService)
        {
            _modelService = modelService;

            View = new HubVM();
        }

        private BaseViewVM _view;

        public BaseViewVM View
        {
            get { return _view; }

            private set
            {
                if (_view == value) return;
                _view = value;
                OnPropertyChanged("View");
            }
        }

        public void Navigate(BaseViewVM viewVm)
        {
            viewVm.LoadModel();
            View = viewVm;
        }

        public ICommand ChangeSizeCommand
        {
            get
            {
                return new RelayCommand(
                    p =>
                    {
                        if (WindowState == WindowState.Normal)
                        {
                            WindowState = WindowState.Maximized;
                        }
                        else
                        {
                            WindowState = WindowState.Normal;
                        }
                    },
                    p => true);
            }
        }

        private double _width;

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private double _height;

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private WindowState _windowState = WindowState.Maximized;

        public WindowState WindowState
        {
            get
            {
                return _windowState;
            }
            set
            {
                _windowState = value;
                OnPropertyChanged("WindowState");
            }
        }
    }
}