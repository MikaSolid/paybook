using System;

namespace PayBook.Model
{
    public class Payment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public int PartyId { get; set; }

        public int BillId { get; set; }

        public bool IsPayed { get; set; }

        public bool IsCanceled { get; set; }
    }
}