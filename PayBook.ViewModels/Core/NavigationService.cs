using System;
using System.ComponentModel.Composition;

namespace PayBook.ViewModels
{
    [Export(typeof(INavigationService))]
    public class NavigationService : INavigationService
    {
        private readonly ShellVM _shellVM;

        [ImportingConstructor]
        public NavigationService(ShellVM shellVM)
        {
            _shellVM = shellVM;
        }

        public void Navigate(BaseViewVM vm)
        {
            _shellVM.Navigate(vm);
        }
    }

    public delegate void NavigateDelegate(Type vm);
}