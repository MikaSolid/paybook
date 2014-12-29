namespace PayBook.ViewModels
{
    public interface IContextAware
    {
        void InjectContext(object context);
    }
}