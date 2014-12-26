using System;

namespace PayBook.Model
{
    public class InvoiceStatus
    {
        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public InvoiceStatusType Status { get; set; }
        
        public DateTime DateTime { get; set; }
    }
}
