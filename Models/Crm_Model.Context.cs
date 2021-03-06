﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace crm_system.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CRMEntities : DbContext
    {
        public CRMEntities()
            : base("name=CRMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Balance> Balances { get; set; }
        public virtual DbSet<Bank_Account> Bank_Accounts { get; set; }
        public virtual DbSet<Blog_Category> Blog_Categories { get; set; }
        public virtual DbSet<Credit> Credits { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Expence_History> Expence_Histories { get; set; }
        public virtual DbSet<Expence_Transaction> Expence_Transactions { get; set; }
        public virtual DbSet<Knowledge> Knowledges { get; set; }
        public virtual DbSet<Manage_Knowledge> Manage_Knowledges { get; set; }
        public virtual DbSet<Manage_Loan> Manage_Loans { get; set; }
        public virtual DbSet<Manage_Project> Manage_Projects { get; set; }
        public virtual DbSet<Manage_Supplier> Manage_Suppliers { get; set; }
        public virtual DbSet<Newsletter> Newsletters { get; set; }
        public virtual DbSet<Newsletter_History> Newsletter_Histories { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Note_History> Note_Histories { get; set; }
        public virtual DbSet<Personal_Loan> Personal_Loans { get; set; }
        public virtual DbSet<Product_Category> Product_Categories { get; set; }
        public virtual DbSet<Product_Management> Product_Managements { get; set; }
        public virtual DbSet<Product_Stock> Product_Stocks { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Proposal> Proposals { get; set; }
        public virtual DbSet<Proposal_History> Proposal_Histories { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Purchase_Report> Purchase_Reports { get; set; }
        public virtual DbSet<Sale_Management> Sale_Managements { get; set; }
        public virtual DbSet<Sold_History> Sold_Histories { get; set; }
        public virtual DbSet<Subscribe_Status> Subscribe_Status { get; set; }
        public virtual DbSet<Supply_Management> Supply_Managements { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
    }
}
