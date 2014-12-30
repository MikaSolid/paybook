using System.Collections.Generic;
using System.Linq;
using PayBook.Model;

namespace PayBook.DataAccess.Ef
{
    public static class CompanyTranslators
    {
        public static Model.Company ToCompany(this Company dataModel)
        {
            var model = new Model.Company();
            model.Id = dataModel.Id;

            if (dataModel.Organization.Party.BillingAccountRole != null)
                model.Account = dataModel.Organization.Party.BillingAccountRole.BillingAccount.Description;
            
            model.Code = dataModel.Organization.Party.Code;
            model.Name = dataModel.Organization.Name;

            model.CompanyNumber = dataModel.CompanyNumber;
            model.TaxNumber = dataModel.TaxNumber;
            
            return model;
        }

        public static IEnumerable<Model.Company> ToCompany(this IEnumerable<Company> dataModel)
        {
            return dataModel.Select(dm => dm.ToCompany());
        }

        public static IEnumerable<CompanyInfo> ToCompanyInfo(this IEnumerable<Company> dataModel)
        {
            return dataModel.Select(dm => dm.ToCompanyInfo());
        }

        public static CompanyInfo ToCompanyInfo(this Company dataModel)
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
