using System.ComponentModel.Composition;
using PayBook.Model;

namespace PayBook.ViewModels
{
    [Export]
    public class CalendarVM : BillsVM
    {
        [ImportingConstructor]
        public CalendarVM(IModelService modelService)
            : base(modelService)
        {
            Title = "kalendar";
        }
    }
}