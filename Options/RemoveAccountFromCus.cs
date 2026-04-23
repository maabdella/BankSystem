using System;
using System.Collections.Generic;
using System.Text;
using BankSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Options;

internal class RemoveAccountFromCus
{
    public static void RemoveAccount()
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
            db.CustomerAccounts.Remove(verfication);
            db.SaveChanges();
            Console.WriteLine("Ownership link deleted");
            Console.WriteLine($"That was the last owner - Account {accNumber} was also removed");
        }
    }
}
