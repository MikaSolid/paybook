using PayBook.Model;
using PayBook.ViewModels;

namespace PayBook.WpfClient.Commands
{
    public class NavigateToPickerCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            ModelService.SaveCompany(parameter as Company);
            NavigationService.Navigate(new PickerVM(null, null));
        }
    }
}