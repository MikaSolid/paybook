//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PayBook.DataAccess.Ef
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoiceTerm
    {
        public int InvoiceTermId { get; set; }
        public int TermTypeId { get; set; }
        public Nullable<int> InvoiceId { get; set; }
        public Nullable<int> InvoiceItemId { get; set; }
        public Nullable<decimal> TermValue { get; set; }
    
        public virtual Invoice Invoice { get; set; }
        public virtual InvoiceItem InvoiceItem { get; set; }
        public virtual TermType TermType { get; set; }
    }
}
