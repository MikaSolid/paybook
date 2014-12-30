using System.Collections.Generic;
using System.Linq;
using PayBook.Model;

namespace PayBook.DataAccess.Ef
{
    public static class CompanyTranslators
    {
        public static Company ToModel(this Organization dataModel)
        {
            var model = new Company();
            model.Id = dataModel.Id;
            model.Name = dataModel.Name;
            return model;
        }

        public static IEnumerable<Model.Company> ToModel(this IEnumerable<Organization> dataModel)
        {
            return dataModel.Select(dm => dm.ToModel());
        }
    }
}
