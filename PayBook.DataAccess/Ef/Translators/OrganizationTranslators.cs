using PayBook.Model;

namespace PayBook.DataAccess.Ef
{
    public static class OrganizationTranslators
    {
        public static Organization ToOrganization(this Supplier supplier)
        {
            var o = new Organization();
            
            o.Name = supplier.Organization.Name;
            
            return o;
        }
    }
}
