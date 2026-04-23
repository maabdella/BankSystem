using BankSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Options;

public static class UpdateAccountStatus
{
    public static void UpdateStatus()
    {
        using var db = new BankDbContext();

        string accNumber;
        while (true)
        {
            Console.Write("Account Number : ");
            accNumber = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(accNumber) && accNumber.Length == 16)
                break;
            Console.WriteLine("Account Number Must be 16");
        }

        int cusId;
        while (true)
        {
            Console.Write("Customer ID : ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (db.Customers.Any(c => c.Id == id))
                {
                    cusId = id;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a Valid Customer ID ");
                }
            }
        }

        var verfication = db.CustomerAccounts.Include(cs => cs.Account)
                                                          .Where(cs => cs.CustomerId == cusId && cs.Account.AccountNumber == accNumber)
                                                          .FirstOrDefault();


        if (verfication != null)
        {
            Console.WriteLine("New Status :  ");

            Console.WriteLine("  1) Active ");
            Console.WriteLine("  2) Closed ");
            Console.Write("   Choice  : ");

            int newState = int.Parse(Console.ReadLine());
            verfication.AccountStatus = (AccountStatus)newState;
            Console.WriteLine($"Status Udated to be {(AccountStatus)newState}");

            db.SaveChanges();

        }
    }
}