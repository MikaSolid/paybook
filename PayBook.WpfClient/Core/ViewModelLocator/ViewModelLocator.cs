using System;
using System.Diagnostics;
using System.Windows;
using PayBook.WpfClient;

namespace PayBook.ViewModels
{
    public class ViewModelLocator : Observable
    {
        public static INavigationService NavigationService
        {
            get
            {
                if (App.Container == null)
                    App.BootstrapCatalog();

                return App.Container.GetExportedValue<INavigationService>();
            }
        }

        public static BaseViewVM GetBaseViewModel(Type type)
        {
            return GetBaseViewModel(type.FullName);
        }

        public static BaseViewVM GetBaseViewModel(string typeName)
        {
            try
            {
                if (App.Container == null)
                    App.BootstrapCatalog();
                
                var x = App.Container.GetExportedValue<object>(typeName) as BaseViewVM;
                
                return x;
            }
            catch (Exception ex)
            {
               //  MessageBox.Show(ex.Message);
                Debug.WriteLine("Error while resolving ViewModel. " + ex);
            }

            return null;
        }

        public ShellVM Shell
        {
            get
            {
                if (App.Container == null)
                    App.BootstrapCatalog();

                return App.Container.GetExportedValue<ShellVM>();
            }
        }

        public BaseViewVM this[string typeName]
        {
            get
            {
                var vm = GetBaseViewModel(typeName);
                vm.LoadModel();
                return vm;
            }
        }
    }
}