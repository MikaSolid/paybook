using PayBook.DataAccess;
using PayBook.ViewModels;

namespace PayBook
{
    public class ViewModelLocator
    {
        private readonly Container _container = Container.GetInstance();
        private readonly IModelService _modelService;
        private readonly ShellVM _shell;

        #region Constructor 

        public ViewModelLocator()
        {
            if (BaseVM.GetIsInDesignMode())
            {
                _modelService = new DesignTimeModelService();
            }
            else
            {
                _modelService = new XmlModelService();
            }

            _shell = new ShellVM(_modelService);

            _container.Register(typeof(ShellVM), () => _shell);
            _container.Register(typeof(IModelService), () => _modelService);        
        }

        #endregion

        public ShellVM ShellVM { get { return _shell; } }
    }
}