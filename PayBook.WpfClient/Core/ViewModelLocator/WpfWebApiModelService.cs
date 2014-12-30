using System.ComponentModel.Composition;
using PayBook.Composition;
using PayBook.DataAccess.Ef;
using PayBook.Model;

namespace PayBook.WpfClient
{
    [Export(typeof(IModelService))]
    [DesignTimeExport(DesignTime = false)]
    public class WpfWebApiModelService : EfModelService
    {
    }
}