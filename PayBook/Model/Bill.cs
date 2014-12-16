using System;

namespace PayBook.Model
{
    public class Bill
    {
        public Guid Id { get; set; }

        public Guid PartyId { get; set; }

        public string Code { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public DateTime DueDate { get; set; }

        public Guid PaymentId { get; set; }

        public bool IsPayed { get; set; }
    }
}