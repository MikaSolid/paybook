namespace PayBook.Model
{
    public class Company : LegalOrganization
    {
        public int DefaultPaymentDays { get; set; }

        public string Account { get; set; }  

        public string CompanyNumber { get; set; }

        public string TaxNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ContactPerson { get; set; }

        public string Comments { get; set; }
    }
}