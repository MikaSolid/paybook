using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;

namespace PayBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("sr-Latn-CS"); ;

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sr-Latn-CS"); ;

            FrameworkElement.LanguageProperty.OverrideMetadata(
             typeof(FrameworkElement),
             new FrameworkPropertyMetadata(
             System.Windows.Markup.XmlLanguage.GetLanguage(CultureInfo.CurrentUICulture.IetfLanguageTag)));

            base.OnStartup(e);

        }
    }
}
