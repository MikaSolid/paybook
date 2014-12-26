using System;

namespace PayBook.Model
{
    public class InvoiceRole
    {
        public int PartyId { get; set; }

        public Party Party { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public DateTime DateTime { get; set; }
    }
}
