using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using PayBook.Model;

namespace PayBook.ViewModels
{
    [Export]
    public class InvoiceDetailsVM : BaseViewVM
    {
        private readonly int _invoiceId;
        private Invoice _invoice;
        private List<CompanyInfo> _companyInfos;
        private string _selectedCompany;
        private string _amount;

        [ImportingConstructor]
        public InvoiceDetailsVM(IModelService modelService)
            : base(modelService)
        {
            Title = "izdavanje računa";
        }

        public InvoiceDetailsVM(IModelService modelService, int id)
            : this(modelService)
        {
            _invoiceId = id;
            Title = "izmena računa";
        }

        public override void LoadModel()
        {
            _invoice = _invoiceId > 0 ? _modelService.GetInvoice(_invoiceId) : Invoice.Create(InvoiceType.PurchaseInvoice);
            _companyInfos = _modelService.GetCompanyInfos();
        }

        public string Amount
        {
            get { return _invoice.Amount.ToString(); }
            set
            {
                _invoice.SetAmount(value);
                OnPropertyChanged(() => Amount);
            }
        }

        public Company Company { get { return _invoice.Company; } }

        public Invoice Invoice { get { return _invoice; } }

        public IEnumerable<string> Companies { get { return _companyInfos.Select(c => c.Name); } }

        public string SelectedCompany
        {
            get { return _selectedCompany; }
            set
            {
                _selectedCompany = value;

                if (value != null)
                {
                    var info = _companyInfos.SingleOrDefault(ci => ci.Name == _selectedCompany);

                    if (info != null)
                    {
                        _invoice.SetCompany(_modelService.GetCompany(info.Id));
                        OnPropertyChanged(() => Company);
                    }
                }
            }
        }

        public List<CompanyInfo> CompanyInfos { get { return _companyInfos; } }
    }
}
