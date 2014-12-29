using PayBook.Model;
using PayBook.ViewModels;

namespace PayBook.WpfClient.Commands
{
    public class SaveCompanyCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            ModelService.SaveCompany(parameter as Company);
            NavigationService.Navigate(new CompaniesVM(ModelService));
        }
    }
}