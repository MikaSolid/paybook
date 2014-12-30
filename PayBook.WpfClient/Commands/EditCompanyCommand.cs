using PayBook.ViewModels;

namespace PayBook.WpfClient.Commands
{
    public class EditCompanyCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            NavigationService.Navigate(new CompanyDetailsVM(ModelService, (int)parameter));
        }
    }
}