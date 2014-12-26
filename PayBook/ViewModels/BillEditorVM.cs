using PayBook.Model;

namespace PayBook.ViewModels
{
    public class BillEditorVM : BaseViewVM
    {
        private readonly Invoice _invoice;

        public BillEditorVM(Invoice invoice)
        {
            _invoice = invoice;
        }

        public override void LoadModel()
        {
        }
    }
}
