using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace PayBook.ViewModels
{
    public interface IComposer
    {
        ComposablePartCatalog InitializeContainer();

        IEnumerable<ExportProvider> GetCustomExportProviders();
    }
}
