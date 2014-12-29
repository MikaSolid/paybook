using System.ComponentModel.Composition;
using PayBook.Model;
using PayBook.WebApiAgent;

namespace PayBook.WpfClient
{
    [Export(typeof(IModelService))]
    public class WpfWebApiModelService : WebApiModelService
    {
    }
}