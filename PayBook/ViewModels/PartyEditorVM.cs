using PayBook.Model;
using System.Windows.Input;

namespace PayBook.ViewModels
{
    public class PartyEditorVM : BaseViewVM
    {
        private readonly Party _party;

        public PartyEditorVM() : this(new Party()) { }


        public PartyEditorVM(Party party)
        {
            _party = party;

            Title = "partija";
        }

        public string Code
        {
            get
            {
                return _party.Code;
            }
            set
            {
                if (_party.Code == value) return;
                _party.Code = value;
                OnPropertyChanged("Code");
            }
        }

        public string Name
        {
            get
            {
                return _party.Name;
            }
            set
            {
                if (_party.Name == value) return;
                _party.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Account
        {
            get
            {
                return _party.Account;
            }
            set
            {
                if (_party.Account == value) return;
                _party.Account = value;
                OnPropertyChanged("Account");
            }
        }


        public string CompanyNumber
        {
            get { return _party.CompanyNumber; }
            set
            {
                if (_party.CompanyNumber == value) return;
                _party.CompanyNumber = value;
                OnPropertyChanged("CompanyNumber");
            }
        }


        public string Address1
        {
            get { return _party.Address1; }
            set
            {
                if (_party.Address1 == value) return;
                _party.Address1 = value;
                OnPropertyChanged("Address1");
            }
        }

        public string Address2
        {
            get { return _party.Address2; }
            set
            {
                if (_party.Address2 == value) return;
                _party.Address2 = value;
                OnPropertyChanged("Address2");
            }
        }

        public string Comments
        {
            get { return _party.Comments; }
            set
            {
                if (_party.Comments == value) return;
                _party.Comments = value;
                OnPropertyChanged("Comments");
            }
        }

        public string ContactPerson
        {
            get { return _party.ContactPerson; }
            set
            {
                if (_party.ContactPerson == value) return;
                _party.ContactPerson = value;
                OnPropertyChanged("ContactPerson");
            }
        }

        public string Email
        {
            get { return _party.Email; }
            set
            {
                if (_party.Email == value) return;
                _party.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Phone
        {
            get { return _party.Phone; }
            set
            {
                if (_party.Phone == value) return;
                _party.Phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string TaxNumber
        {
            get { return _party.TaxNumber; }
            set
            {
                if (_party.TaxNumber == value) return;
                _party.TaxNumber = value;
                OnPropertyChanged("TaxNumber");
            }
        }

        public override void LoadModel()
        {
        }

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(arg =>
                {
                    ModelService.SaveParty(_party);
                    Shell.Navigate(new PartysVM());
                });
            }
        }
    }
}
