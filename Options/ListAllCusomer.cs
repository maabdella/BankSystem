using System;
using System.Collections.Generic;
using System.Text;
using BankSystem.Models;
using Microsoft.EntityFrameworkCore;


namespace BankSystem.Options;

public static class ListAllCusomer
{
    public static void GetAllCusomer()
    {

        using var db = new BankDbContext();

        var results = db.Customers.Include(c => c.CustomerAccounts).ThenInclude(ca => ca.Account).ThenInclude(a => a.Branch).ToList();

        foreach (var customer in results)
        {
            Console.WriteLine($"#{customer.Id}  {customer.FullName} ({customer.CustomerType})");

            if (!customer.CustomerAccounts.Any())
                Console.WriteLine("NO Accounts Found");
            else
            {
                foreach (var item in customer.CustomerAccounts)
                {
                    Console.WriteLine($"                 ({item.Account.Branch.Code}) {item.Account.AccountType}  Balance : {item.Account.CurrentBalance}  {item.OwnershipType} {item.AccountStatus} {item.Account.Branch.Name}");
                }
            }
        }
    }
}
