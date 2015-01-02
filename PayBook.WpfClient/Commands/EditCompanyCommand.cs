using PayBook.ViewModels;

namespace PayBook.WpfClient.Commands
{
    public class EditCompanyCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            var cd = new CompanyDetailsVM(ModelService);
            cd.SetCompanyId((int)parameter); 
            NavigationService.Navigate(cd);
        }
    }
}