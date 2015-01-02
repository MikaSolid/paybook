using System.Collections.Generic;
using System.Linq;
using PayBook.Model;

namespace PayBook.DataAccess.Ef
{
    public static class CompanyTranslators
    {
        public static Model.Company ToModel(this Company dataModel)
        {
            var model = new Model.Company();
            model.Id = dataModel.Id;

            var bar = dataModel.Organization.Party.BillingAccountRole;

            if (bar != null)
                model.Account = dataModel.Organization.Party.BillingAccountRole.BillingAccount.Description;

            var postalAddress = dataModel.Organization.Party.PartyContactMechanism.SingleOrDefault(e => e.ContactMechanism.PostalAddress != null);

            if (postalAddress != null)
            {
                model.Address1 = postalAddress.ContactMechanism.PostalAddress.Address1;
                model.Address2 = postalAddress.ContactMechanism.PostalAddress.Address2;
            }

            var email = dataModel.Organization.Party.PartyContactMechanism.SingleOrDefault(e => e.ContactMechanism.EmailAddress != null);

            if (email != null)
                model.Email = email.ContactMechanism.EmailAddress.Address;

            var phone = dataModel.Organization.Party.PartyContactMechanism.SingleOrDefault(e => e.ContactMechanism.Phone != null);

            if (phone != null)
                model.Phone = phone.ContactMechanism.Phone.Number;


            model.Code = dataModel.Organization.Party.Code;
            model.Name = dataModel.Organization.Name;

            model.CompanyNumber = dataModel.CompanyNumber;
            model.TaxNumber = dataModel.TaxNumber;
            
            return model;
        }

        public static IEnumerable<Model.Company> ToModel(this IEnumerable<Company> dataModel)
        {
            return dataModel.Select(dm => dm.ToModel());
        }

        public static IEnumerable<CompanyInfo> ToModelInfo(this IEnumerable<Company> dataModel)
        {
            return dataModel.Select(dm => dm.ToModelInfo());
        }

        public static CompanyInfo ToModelInfo(this Company dataModel)
        {
            var model = new CompanyInfo();
            
            model.Id = dataModel.Id;
            
            model.Name = dataModel.Organization.Name;
            
            model.Code = dataModel.Organization.Party.Code;

            if (dataModel.Organization.Party.BillingAccountRole != null)
                model.BillingAccount = dataModel.Organization.Party.BillingAccountRole.BillingAccount.Description;

            return model;
        }

    }
}
