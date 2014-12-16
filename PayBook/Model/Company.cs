﻿using System;

namespace PayBook.Model
{
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

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