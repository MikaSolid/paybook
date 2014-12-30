using PayBook.Model;
using PayBook.ViewModels;

namespace PayBook.WpfClient.Commands
{
    public class SaveInvoiceCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            ModelService.SaveInvoice(parameter as Invoice);
            NavigationService.Navigate(App.Container.GetExportedValue<HubVM>());
        }
    }
}