using System;

namespace PayBook.Model
{
    public class PartyRole
    {
        public int PartyId { get; set; }

        public int RoleId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}