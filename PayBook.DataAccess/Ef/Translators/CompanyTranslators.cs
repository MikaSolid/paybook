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
            model.Name = dataModel.Name;
            return model;
        }

        public static IEnumerable<Company> ToModel(this IEnumerable<Organization> dataModel)
        {
            return dataModel.Select(dm => dm.ToModel());
        }

        public static Model.Supplier ToModel(this Supplier dataModel)
        {
            var model = new Model.Supplier();
            model.Id = dataModel.Id;
            model.Name = dataModel.Organization.Name;
            return model;
        }

        public static IEnumerable<Model.Supplier> ToModel(this IEnumerable<Supplier> dataModel)
        {
            return dataModel.Select(dm => dm.ToModel());
        }
    }
}
