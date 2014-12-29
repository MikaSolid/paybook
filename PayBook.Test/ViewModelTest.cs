using System.ComponentModel.Composition.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayBook.Composition;
using PayBook.ViewModels;

namespace PayBook.Test
{
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void TestViewModels()
        {
        }

        [TestMethod]
        public void TestMef()
        {
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ViewModelTest).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ShellVM).Assembly));

            var wpfCatalog = new MvvmCatalog(catalog);

            var container = new CompositionContainer(wpfCatalog);

            var shell = container.GetExportedValue<ShellVM>();

            var sh2 = container.GetExportedValue<object>("PayBook.ViewModels.ShellVM");


            shell.Navigate(container.GetExportedValue<HubVM>());
        }
    }
}
