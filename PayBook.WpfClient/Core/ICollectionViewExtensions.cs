using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PayBook
{
    public static class ICollectionViewExtensions
    {
        public static void Sort(this ICollectionView view, string fieldToSort)
        {
            if (view.SortDescriptions.Count > 0)
            {
                ListSortDirection direction = view.SortDescriptions[0].Direction ==
                    ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;

                view.SortDescriptions.Clear();

                view.SortDescriptions.Add(new SortDescription(fieldToSort, direction));
            }
            else
                view.SortDescriptions.Add(new SortDescription(fieldToSort, ListSortDirection.Ascending));
        }
    }
}
