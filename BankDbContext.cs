using BankSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem;

public class BankDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer($"Server=.;Database=BankSystemDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }


    public DbSet<Branch> Branches { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<CustomerAccount> CustomerAccounts { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerAccount>().HasKey(ca => new {ca.AccountId ,ca.CustomerId });

        modelBuilder.Entity<Account>().HasIndex(a => a.AccountNumber)
                                      .IsUnique();

        modelBuilder.Entity<Branch>().HasOne(b=>b.Manager)  
                                     .WithOne(m=>m.Branch)   
                                     .HasForeignKey<Manager>(m=>m.BranchId);

        modelBuilder.Entity<Branch>().HasMany(b => b.Accounts)
                                     .WithOne(a => a.Branch)
                                     .HasForeignKey(a => a.BranchId);

        modelBuilder.Entity<CustomerAccount>().HasOne(ca => ca.Account)
                                              .WithMany(a => a.CustomerAccounts)
                                              .HasForeignKey(ca => ca.AccountId);

        modelBuilder.Entity<CustomerAccount>().HasOne(ca => ca.Customer)
                                              .WithMany(a => a.CustomerAccounts)
                                              .HasForeignKey(ca => ca.CustomerId);

        modelBuilder.Entity<Account>().Property(a => a.AccountType)
                                      .HasConversion<string>();

        modelBuilder.Entity<CustomerAccount>().Property(a => a.OwnershipType)
                                              .HasConversion<string>();

        modelBuilder.Entity<CustomerAccount>().Property(a => a.AccountStatus)
                                      .HasConversion<string>();

        modelBuilder.Entity<Customer>().Property(a => a.CustomerType)
                                      .HasConversion<string>();

        modelBuilder.Entity<CustomerAccount>()
                    .Property(a => a.OwnershipStartDate)
                    .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Transaction>()
                    .Property(t => t.Amount)
                    .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Account>()
                    .Property(a => a.OpeningDate)
                    .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Account>()
                    .Property(a => a.CurrentBalance)
                    .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Manager>()
                    .Property(m => m.HireDate)
                    .HasDefaultValueSql("GETDATE()");

    }
}
