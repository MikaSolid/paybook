using System;
using System.ComponentModel.Composition;

namespace PayBook.ViewModels
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ExportViewModel : ExportAttribute
    {
        internal const string NameProperty = "Name";
        internal const string IsViewModelFirstProperty = "IsViewModelFirst";
        internal const string ShouldReSatisfyImportsProperty = "ShouldReSatisfyImports";

        public ExportViewModel(string name)
            : this(name, false)
        { }

        public ExportViewModel(string name, bool isViewModelFirst)
            : base(name, typeof(object))
        {
            Name = name;
            IsViewModelFirst = isViewModelFirst;
        }

        public string Name { get; private set; }

        public bool IsViewModelFirst { get; private set; }

        /// <summary>
        /// Set to true to re satisfy imports on a ViewModel which is marked as IsViewModelFirst whenever the data context of the view changes. 
        /// Please note this is only supported in WPF since Silverlight still does not expose a DataContextChanged event
        /// </summary>
        public bool ShouldReSatisfyImports { get; set; }

    }
}