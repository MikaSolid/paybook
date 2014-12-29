using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PayBook.ViewModels;
using System.Windows.Controls;

namespace PayBook.WpfClient
{
    /// <summary>
    /// Custom calendar control that supports appointments.
    /// </summary>
    public class BillingCalendar : Calendar, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        #endregion

        public static DependencyProperty BillsProperty =
            DependencyProperty.Register
            (
                "Bills",
                typeof(ObservableCollection<BillVM>),
                typeof(BillingCalendar)
            );

        /// <summary>
        /// The list of appointments. This is a dependency property.
        /// </summary>
        public ObservableCollection<BillVM> Bills
        {
            get { return (ObservableCollection<BillVM>)GetValue(BillsProperty); }
            set { SetValue(BillsProperty, value); }
        }

        static BillingCalendar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BillingCalendar), new FrameworkPropertyMetadata(typeof(BillingCalendar)));
        }

        public BillingCalendar()
            : base()
        {
            SetValue(BillsProperty, new ObservableCollection<BillVM>());
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            FrameworkElement element = e.OriginalSource as FrameworkElement;

            if (element.DataContext is DateTime)
            {
                //AppointmentWindow appointmentWindow = new AppointmentWindow
                //(
                //    (BillVM appointment) =>
                //    {
                //        Bills.Add(appointment);
                //        if (PropertyChanged != null)
                //        {
                //            PropertyChanged(this, new PropertyChangedEventArgs("Appointments"));
                //        }
                //    }
                //);
                //appointmentWindow.Show();
            }
        }
    }
}
