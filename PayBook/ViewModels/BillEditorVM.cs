using PayBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayBook.ViewModels
{
    public class BillEditorVM : BaseViewVM
    {
        private readonly Bill _bill;

        public BillEditorVM(Bill bill)
        {
            _bill = bill;
        }

        public override void LoadModel()
        {
        }
    }
}
