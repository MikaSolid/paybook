using System;

namespace PayBook.Model
{
    public class Payment
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public Guid PartyId { get; set; }

        public Guid BillId { get; set; }

        public bool IsPayed { get; set; }

        public bool IsCanceled { get; set; }
    }
}