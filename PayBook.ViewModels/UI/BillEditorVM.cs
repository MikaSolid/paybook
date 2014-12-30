using System.ComponentModel.Composition;
using PayBook.Model;

namespace PayBook.ViewModels
{
    [Export]
    public class BillEditorVM : BaseViewVM
    {
        private readonly Invoice _invoice;

        [ImportingConstructor]
        public BillEditorVM(IModelService modelService, Invoice invoice)
            : base(modelService)
        {
            _invoice = invoice;
        }

        public override void LoadModel()
        {
        }
    }
}
