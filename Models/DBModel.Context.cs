﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASCO.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBACSOEntities : DbContext
    {
        public DBACSOEntities()
            : base("name=DBACSOEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Farmer> Farmers { get; set; }
        public virtual DbSet<Farmer_Fertilizer_RS> Farmer_Fertilizer_RS { get; set; }
        public virtual DbSet<Farmer_Loan_RS> Farmer_Loan_RS { get; set; }
        public virtual DbSet<Farmer_Machinery_RS> Farmer_Machinery_RS { get; set; }
        public virtual DbSet<Farmer_Seed_RS> Farmer_Seed_RS { get; set; }
        public virtual DbSet<Farmer_Tool_RS> Farmer_Tool_RS { get; set; }
        public virtual DbSet<Fertilizer> Fertilizers { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Machinery> Machineries { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Seed> Seeds { get; set; }
        public virtual DbSet<Tool> Tools { get; set; }
    }
}
