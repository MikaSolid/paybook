using System.Collections.Generic;
using System.Linq;
using PayBook.Model;

namespace PayBook.DataAccess.Ef
{
    public static class CompanyTranslators
    {
        public static Company ToCompany(this Organization dataModel)
        {
            var model = new Company();
            model.Id = dataModel.Id;
            model.Name = dataModel.Name;
            return model;
        }

        public static IEnumerable<Company> ToCompany(this IEnumerable<Organization> dataModel)
        {
            return dataModel.Select(dm => dm.ToCompany());
        }

        public static IEnumerable<CompanyInfo> ToCompanyInfo(this IEnumerable<Organization> dataModel)
        {
            return dataModel.Select(dm => dm.ToCompanyInfo());
        }

        public static CompanyInfo ToCompanyInfo(this Organization dataModel)
        {
            var model = new CompanyInfo();
            model.Id = dataModel.Id;
            model.Name = dataModel.Name;

            if (dataModel.Party != null)
            {
                if (dataModel.Party.BillingAccountRole != null)
                    model.BillingAccount = dataModel.Party.BillingAccountRole.BillingAccount.Description;
            }
            return model;
        }

    }
}
