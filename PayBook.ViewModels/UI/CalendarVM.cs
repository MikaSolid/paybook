using System.ComponentModel.Composition;
using PayBook.Model;

namespace PayBook.ViewModels
{
    [Export]
    public class CalendarVM : InvoiceListVM
    {
        [ImportingConstructor]
        public CalendarVM(IModelService modelService)
            : base(modelService)
        {
            Title = "kalendar";
        }
    }
}