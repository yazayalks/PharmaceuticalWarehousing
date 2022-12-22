using Microsoft.EntityFrameworkCore;
using PharmaceuticalWarehousing.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PharmaceuticalWarehousing
{
    public class PharmaceuticalWarehousingDbContext : DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<Waybill> Waybills { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<Salesman> Salesmans { get; set; }
        public DbSet<Counterparty> Counterparties { get; set; }
        public DbSet<PaymentAccount> PaymentAccounts { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<User> Users { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("db");
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PharmaceuticalWarehousing;Username=postgres;Password=6969");
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }
}
