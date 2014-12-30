using System;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using PayBook.Composition;
using PayBook.ViewModels;

namespace PayBook.WpfClient
{
    public partial class App
    {
        public static CompositionContainer Container { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

#if (DEBUG)
            BootstrapCatalog();
#else
            RunInReleaseMode();
#endif
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        internal static void BootstrapCatalog()
        {
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(App).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ShellVM).Assembly));

            Container = new CompositionContainer(
                Mvvm.GetIsInDesignMode() ? 
                new MvvmCatalog(catalog, true) : 
                new MvvmCatalog(catalog));
        }

        private void RunInReleaseMode()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;

            try
            {
                BootstrapCatalog();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        private static void HandleException(Exception ex)
        {
            if (ex == null)
                return;

            MessageBox.Show(ex.ToString());
            Environment.Exit(1);
        }
    }

}