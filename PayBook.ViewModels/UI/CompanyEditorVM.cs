using System.ComponentModel.Composition;
using PayBook.Model;

namespace PayBook.ViewModels
{
    [Export]
    public class CompanyEditorVM : BaseViewVM
    {
        private readonly int _companyId;
        private Company _company = new Company();

        [ImportingConstructor]
        public CompanyEditorVM(IModelService modelService) : base(modelService)
        {
            Title = "snabdevači";
        }

        public CompanyEditorVM(IModelService modelService, int companyId) : this (modelService)
        {
            _companyId = companyId;
        }

        public Company Company { get { return _company; } }

        public string Code
        {
            get
            {
                return _company.Code;
            }
            set
            {
                if (_company.Code == value) return;
                _company.Code = value;
                OnPropertyChanged("Code");
            }
        }

        public string Name
        {
            get
            {
                return _company.Name;
            }
            set
            {
                if (_company.Name == value) return;
                _company.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Account
        {
            get
            {
                return _company.Account;
            }
            set
            {
                if (_company.Account == value) return;
                _company.Account = value;
                OnPropertyChanged("Account");
            }
        }


        public string CompanyNumber
        {
            get { return _company.CompanyNumber; }
            set
            {
                if (_company.CompanyNumber == value) return;
                _company.CompanyNumber = value;
                OnPropertyChanged("CompanyNumber");
            }
        }


        public string Address1
        {
            get { return _company.Address1; }
            set
            {
                if (_company.Address1 == value) return;
                _company.Address1 = value;
                OnPropertyChanged("Address1");
            }
        }

        public string Address2
        {
            get { return _company.Address2; }
            set
            {
                if (_company.Address2 == value) return;
                _company.Address2 = value;
                OnPropertyChanged("Address2");
            }
        }

        public string Comments
        {
            get { return _company.Comments; }
            set
            {
                if (_company.Comments == value) return;
                _company.Comments = value;
                OnPropertyChanged("Comments");
            }
        }

        public string ContactPerson
        {
            get { return _company.ContactPerson; }
            set
            {
                if (_company.ContactPerson == value) return;
                _company.ContactPerson = value;
                OnPropertyChanged("ContactPerson");
            }
        }

        public string Email
        {
            get { return _company.Email; }
            set
            {
                if (_company.Email == value) return;
                _company.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Phone
        {
            get { return _company.Phone; }
            set
            {
                if (_company.Phone == value) return;
                _company.Phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string TaxNumber
        {
            get { return _company.TaxNumber; }
            set
            {
                if (_company.TaxNumber == value) return;
                _company.TaxNumber = value;
                OnPropertyChanged("TaxNumber");
            }
        }

        public override void LoadModel()
        {
            if (_companyId > 0)
                _company = _modelService.GetCompany(_companyId);
        }
    }
}