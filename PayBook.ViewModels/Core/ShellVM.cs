using System.ComponentModel.Composition;
using PayBook.Model;

namespace PayBook.ViewModels
{
    [Export]
    public class ShellVM : BaseVM
    {
        private readonly IModelService _modelService;

        [ImportingConstructor]
        public ShellVM(IModelService modelService)
        {
            View = new HubVM(modelService);
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

        //private WindowState _windowState = WindowState.Maximized;

        //public WindowState WindowState
        //{
        //    get
        //    {
        //        return _windowState;
        //    }
        //    set
        //    {
        //        _windowState = value;
        //        OnPropertyChanged("WindowState");
        //    }
        //}
    }
}