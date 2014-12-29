using System.ComponentModel.Composition.Hosting;

namespace PayBook.ViewModels
{
    public interface IMefExportProvider
    {
        void SetContextToInject(object context);
        ExportProvider SourceProvider { get; set; }
    }
}