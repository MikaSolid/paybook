using System.ComponentModel.Composition;
using PayBook.Model;

namespace PayBook.WpfClient
{
    [Export(typeof(IModelService))]
    public class TestDesignTimeModelService : DesignTimeModelService
    {
    }
}