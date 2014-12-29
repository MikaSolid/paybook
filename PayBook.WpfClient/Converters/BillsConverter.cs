using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using PayBook.ViewModels;

namespace PayBook.WpfClient
{
    /// <summary>
    /// Gets the appointments for the specified date.
    /// </summary>
    [ValueConversion(typeof(ObservableCollection<BillVM>), typeof(ObservableCollection<BillVM>))]
    public class BillsConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime date = (DateTime)values[1];

            ObservableCollection<BillVM> bills = new ObservableCollection<BillVM>();

            if (values[0] != null)
            {
                var originalBills = values[0] as IEnumerable<BillVM>;

                if (originalBills != null)
                {
                    foreach (BillVM bill in originalBills)
                    {
                        if (bill != null && bill.DueDate.GetValueOrDefault().Date == date)
                        {
                            bills.Add(bill);
                        }
                    }
                }
            }

            return bills;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}