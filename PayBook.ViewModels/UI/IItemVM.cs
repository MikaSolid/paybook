namespace PayBook.ViewModels
{
    public interface IItemVM
    {
        int Id { get; }

        string Name { get; set; }

        bool IsSelected { get; set; }
    }
}