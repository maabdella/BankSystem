using System;
using System.Collections.Generic;
using System.Text;
using BankSystem.Models;
using Microsoft.IdentityModel.Tokens;

namespace BankSystem.Options;

public static class OpenNewAcc
{
    public static void OpenAccount()
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


        int accType;
        while (true)
        {
            Console.WriteLine("Account Type : ");
            Console.WriteLine("  1) Savings");
            Console.WriteLine("  2) Current ");
            Console.WriteLine("  2) Business ");
            Console.Write("    Choice : ");

            if (int.TryParse(Console.ReadLine(), out int t) && t == 1 || t == 2 || t == 3)
            {
                accType = t;
                break;
            }
            else
            {
                Console.WriteLine("Enter 1 Or 2 Or 3");
            }
        }


        Branch branch;
        while (true)
        {

            Console.Write("Branch Code : ");
            if (int.TryParse(Console.ReadLine(), out int code))
            {

                branch = db.Branches.FirstOrDefault(b => b.Code == code);
                if (branch == null)
                {
                    Console.WriteLine("Enter a Valid Branch Code ");

                }
                else
                {
                    break;
                }
            }
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


        int Orole;
        while (true)
        {
            Console.WriteLine("OwnerShip Role : ");
            Console.WriteLine("  1) Primary");
            Console.WriteLine("  2) Coholder ");
            Console.WriteLine("  2) Business ");
            Console.Write("    Choice : ");

            if (int.TryParse(Console.ReadLine(), out int role) && role == 1 || role == 2)
            {
                Orole = role;
                break;
            }
            else { Console.WriteLine("Enter a Valid Role ..  "); }
        }


        var newAccount = new Account()
        {
            AccountNumber = accNumber,
            AccountType = (AccountType)accType,

            BranchId = branch.Id,
            CustomerAccounts = new List<CustomerAccount>() { new CustomerAccount() { CustomerId = cusId, OwnershipType = (OwnershipRole)Orole } }

        };



        Console.WriteLine($"Validating BranchCode #{branch.Code} and CustomerId #{cusId}");

        Console.WriteLine($"Account #{accNumber} Created and linked to Customer #{cusId} as {Orole} Owner");



        db.Accounts.Add(newAccount);
        db.SaveChanges();
    }
}
