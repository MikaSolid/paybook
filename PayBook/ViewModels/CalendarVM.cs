using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections.Generic;

using PayBook.Model;

namespace PayBook.ViewModels
{
    public class CalendarVM : BillsVM
    {
        public CalendarVM()
        {
            Title = "kalendar";
        }
    }
}