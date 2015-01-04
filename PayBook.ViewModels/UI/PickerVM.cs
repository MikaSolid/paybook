using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using PayBook.Model;

namespace PayBook.ViewModels
{
    [Export]
    public class PickerVM : BaseViewVM
    {
        private readonly BaseViewVM _hostView;
        private readonly ReadOnlyObservableCollection<IItemVM> _items;
        private readonly ObservableCollection<IItemVM> _itemsInternal;

        [ImportingConstructor]
        public PickerVM()
        {
            _itemsInternal = new ObservableCollection<IItemVM>
                             {
                                 new CompanyVM(new CompanyInfo() {Id =  1, Name = "The Network Place"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Soletis"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "m1k4"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "AVS Solutions"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Dinaroid"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test 7"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test 8"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test 9"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test a"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test b"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test c"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test d"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test e"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test f"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test g"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test h"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test i"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test j"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test k"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test l"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test m"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test n"}),
                                 new CompanyVM(new CompanyInfo() {Id =  2, Name = "Test o"})
                             };


            _items = new ReadOnlyObservableCollection<IItemVM>(_itemsInternal);

            // OnPropertyChanged("Items");
        }


        public PickerVM(BaseViewVM hostView, IEnumerable<IItemVM> items)
        {
            _hostView = hostView;
            _itemsInternal = new ObservableCollection<IItemVM>(items);
            _items = new ReadOnlyObservableCollection<IItemVM>(_itemsInternal);

            Title = "picker";
        }

        public override void LoadModel()
        {

        }

        public BaseViewVM HostView { get { return _hostView; } }

        public ReadOnlyObservableCollection<IItemVM> Items
        {
            get { return _items; }
        }
    }
}