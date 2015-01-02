namespace PayBook.ViewModels
{
    public interface IItemVM
    {
        int Id { get; set; }

        string Title { get; set; }

        bool IsSelected { get; set; }
    }
}