using System.ComponentModel.Composition.Hosting;

namespace PayBook.ViewModels
{
    public interface IContainerProvider
    {
        CompositionContainer CreateContainer();
    }
}