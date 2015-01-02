using System.ComponentModel.Composition;
using PayBook.Composition;
using PayBook.Model;
using PayBook.WebApiAgent;

namespace PayBook.WpfClient
{
    [Export(typeof(IModelService))]
    [DesignTimeExport(DesignTime = false)]
    public class WpfWebApiModelService : WebApiModelService
    {
    }
}