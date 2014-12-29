using System;
using System.Windows;

using PayBook.ViewModels;

namespace PayBook.WpfClient.Commands
{
    public class NavigateCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            BaseViewVM vm = ViewModelLocator.GetBaseViewModel(ToViewModel);
            
            vm.LoadModel();
            
            NavigationService.Navigate(vm);
        }

        public static readonly DependencyProperty ToViewModelProperty =
            DependencyProperty.Register("ToViewModel", typeof (Type), typeof (NavigateCommand), new PropertyMetadata(default(Type)));

        public Type ToViewModel
        {
            get { return (Type)GetValue(ToViewModelProperty); }
            set { SetValue(ToViewModelProperty, value); }
        }
    }
}