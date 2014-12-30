﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LocalDatabase : DbContext
    {
        public LocalDatabase()
            : base("name=LocalDatabase")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Party> Parties { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<RoleType> RoleTypes { get; set; }
        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<InvoiceRoleType> InvoiceRoleTypes { get; set; }
        public virtual DbSet<InvoiceStatusType> InvoiceStatusTypes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentApplication> PaymentApplications { get; set; }
        public virtual DbSet<PaymentMethodType> PaymentMethodTypes { get; set; }
        public virtual DbSet<InvoiceRole> InvoiceRoles { get; set; }
        public virtual DbSet<InvoiceTerm> InvoiceTerms { get; set; }
        public virtual DbSet<TermType> TermTypes { get; set; }
        public virtual DbSet<BillingAccount> BillingAccounts { get; set; }
        public virtual DbSet<InvoiceStatu> InvoiceStatus { get; set; }
        public virtual DbSet<BillingAccountRole> BillingAccountRoles { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
    }
}
