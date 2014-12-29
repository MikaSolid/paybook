using System.ComponentModel.Composition;
using PayBook.Composition;
using PayBook.Model;

namespace PayBook.WpfClient
{
    [Export(typeof(IModelService))]
    [DesignTimeExport(DesignTime = true)]
    public class WpfDesignTimeModelService : DesignTimeModelService
    {
    }
}