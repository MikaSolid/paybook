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
    
    public partial class InvoiceStatus
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public System.DateTime StatusDate { get; set; }
        public int InvoiceStatusTypeId { get; set; }
    
        public virtual Invoice Invoice { get; set; }
        public virtual InvoiceStatusType InvoiceStatusType { get; set; }
    }
}
