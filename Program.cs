using BankSystem.Models;
using BankSystem.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.RP;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            
            using var db = new BankDbContext();

            #region Seeding DATA
            if (!db.Branches.Any())
            {
                var branches = new List<Branch>
                {
                    new Branch { Code = 101, Name = "Alex Branch", Address = "Alexandria", PhoneNumber = "0121212115" },
                    new Branch { Code = 102, Name = "Cairo Branch", Address = "Cairo", PhoneNumber = "0121254115" },
                    new Branch { Code = 103, Name = "Giza Branch", Address = "Giza", PhoneNumber = "0121787115" },
                    new Branch { Code = 104, Name = "Qina Branch", Address = "Qina", PhoneNumber = "0121254116" }

                };
                //db.Branches.AddRange(branches);
                //db.SaveChanges();
            }

            if (!db.Managers.Any())
            {
                var managers = new List<Manager>
                {
                    new Manager { FullName = "Ahmed Ali", Email = "ahmed@bank.com", PhoneNumber = "0111111111", HireDate = new DateTime(2023, 1, 10), BranchId = 1},
                    new Manager { FullName = "Sara Mohamed", Email = "sara@bank.com",PhoneNumber = "0111111112",HireDate = new DateTime(2023, 5, 20),BranchId = 2},
                    new Manager { FullName = "Omar Hassan", Email = "omar@bank.com",  PhoneNumber = "0111111113",HireDate = new DateTime(2024, 2, 1),BranchId = 3},
                    new Manager { FullName = "Abdellah", Email = "abdo@bank.com",  PhoneNumber = "0111111114",HireDate = new DateTime(2019, 2, 1),BranchId = 4}

                };
                //db.Managers.AddRange(managers);
                //db.SaveChanges();
            }
            #endregion

          

            int pick;

            do
            {
                Console.WriteLine("==============================================================");
                Console.WriteLine("                    Bank - Managemnt System                   ");
                Console.WriteLine("==============================================================");
                Console.WriteLine("    1. Add a new Customer ");
                Console.WriteLine("    2. Open a new Account for a Customer ");
                Console.WriteLine("    3. Update Account Status ");
                Console.WriteLine("    4. Remove an Account from a Customer ");
                Console.WriteLine("    5. List all Cusomers (With Accounts)");
                Console.WriteLine("    0. Exit     ");
                Console.WriteLine("==============================================================");
                Console.Write("           Enter Choice :      ");

                bool isValidInput = int.TryParse(Console.ReadLine(), out pick);

                if (!isValidInput || pick < 0 || pick > 5)
                {
                    Console.WriteLine("Invalid Input Please, Enter a Number between ( 0 , 5 ) ");
                    continue;
                }

                switch (pick)
                {
                    case 1:
                        AddCustomerOption.AddCustomer();
                        break;

                    case 2:
                        OpenNewAcc.OpenAccount();
                        break;

                    case 3:
                        UpdateAccountStatus.UpdateStatus();
                        break;

                    case 4:
                        RemoveAccountFromCus.RemoveAccount();
                        break;

                    case 5:
                        ListAllCusomer.GetAllCusomer();
                        break;

                    case 0:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid option Try again");
                        break;
                }

            } while (pick != 0);






        }
    }
}
