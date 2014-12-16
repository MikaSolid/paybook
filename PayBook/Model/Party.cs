namespace PayBook.Model
{
    public class Party : Company
    {
        public string Code { get; set; }

        public int DefaultPaymentDays { get; set; }
        
        public string Account { get; set; }  
    }
}