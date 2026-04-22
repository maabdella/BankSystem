using BankSystem.Models;
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

            /*Prompt the user for full name, national ID, 
              DOB, email, phone, address, and customer 
              type (Individual / Business). Validate inputs*/

            #region ADD new Cusomer
            //string name;
            //while (true)
            //{
            //    Console.Write("Full Name : ");
            //    name = Console.ReadLine();
            //    if (string.IsNullOrWhiteSpace(name))
            //    {
            //        Console.WriteLine("Enter Valid Name");
            //    }
            //    break;
            //}

            //string nationalId;
            //while (true)
            //{
            //    Console.Write("NationalID : ");
            //    nationalId = Console.ReadLine();
            //    if(!string.IsNullOrWhiteSpace(nationalId) && nationalId.Length == 14)
            //        break;
            //    Console.WriteLine( "National Id Must be 14");
            //}
            //string email;
            //while (true)
            //{
            //    Console.Write("Email : ");
            //    email = Console.ReadLine();
            //    if (!string.IsNullOrWhiteSpace(email) && email.Contains("@"))
            //        break;
            //    Console.WriteLine("Enter Valid Email");
            //}

            //DateTime dob;
            //while (true)
            //{
            //    try
            //    {
            //        Console.Write("Date of Birth (yyyy-MM-dd) : ");
            //        dob = DateTime.Parse(Console.ReadLine());
            //        break;
            //    }
            //    catch
            //    {
            //        Console.WriteLine("Invalid date format. Use yyyy-MM-dd.");
            //    }
            //}

            //string phone;
            //while (true)
            //{
            //    Console.Write("Phone Number : ");
            //    phone = Console.ReadLine();

            //    if (!string.IsNullOrWhiteSpace(phone) && phone.Length >= 10)
            //        break;

            //    Console.WriteLine("Phone number must be at least 10 digits.");
            //}


            //string address;
            //while (true)
            //{
            //    Console.Write("Address : ");
            //    address = Console.ReadLine();

            //    if (!string.IsNullOrWhiteSpace(address))
            //        break;

            //    Console.WriteLine("Address is required.");
            //}

            //int custype;
            //while (true) 
            //{
            //    Console.WriteLine("Customer Type : ");
            //    Console.WriteLine("  1) Individual");
            //    Console.WriteLine("  2) Business ");
            //    Console.Write("    Choice : ");

            //    if (int.TryParse(Console.ReadLine(), out int t) && t == 1 || t == 2)
            //    {
            //        custype = t;
            //        break;
            //    }
            //    else 
            //    {
            //        Console.WriteLine("Enter 1 Or 2 "); 
            //    }
            //}

            //var customer = new Customer
            //{
            //    FullName = name,
            //    Email = email,
            //    Address = address,
            //    CustomerType = (CustomerType)custype,
            //    PhoneNumber = phone,
            //    NationalId = nationalId,
            //    DateOfBirth = dob
            //};


            //db.Customers.Add( customer );
            //db.SaveChanges();   


            //Console.WriteLine($"Customer Created Succesfully CustomerID #{customer.Id}");
            #endregion

            /*
         
                Prompt for account number, account type, 
                branch code, the customer Id, and ownership 
                role (Primary / CoHolder). Must verify branch 
                and customer exist before creating the 
                Account  
             
             */
            #region open new Account 

            //string accNumber;
            //while (true)
            //{
            //    Console.Write("Account Number : ");
            //    accNumber = Console.ReadLine();
            //    if (!string.IsNullOrWhiteSpace(accNumber) && accNumber.Length == 16)
            //        break;
            //    Console.WriteLine("Account Number Must be 16");
            //}


            //int accType;
            //while (true)
            //{
            //    Console.WriteLine("Account Type : ");
            //    Console.WriteLine("  1) Savings");
            //    Console.WriteLine("  2) Current ");
            //    Console.WriteLine("  2) Business ");
            //    Console.Write("    Choice : ");

            //    if (int.TryParse(Console.ReadLine(), out int t) && t == 1 || t == 2 || t == 3)
            //    {
            //        accType = t;
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Enter 1 Or 2 Or 3");
            //    }
            //}


            //Branch branch;
            //while (true)
            //{

            //    Console.Write("Branch Code : ");
            //    if (int.TryParse(Console.ReadLine(), out int code))
            //    {

            //        branch = db.Branches.FirstOrDefault(b => b.Code == code);
            //        if (branch == null)
            //        {
            //            Console.WriteLine("Enter a Valid Branch Code ");

            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //}


            //int cusId;
            //while (true)
            //{
            //    Console.Write("Customer ID : ");
            //    if (int.TryParse(Console.ReadLine(), out int id))
            //    {
            //        if (db.Customers.Any(c => c.Id == id))
            //        {
            //            cusId = id;
            //            break;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Enter a Valid Customer ID ");
            //        }
            //    }
            //}


            //int Orole;
            //while (true)
            //{
            //    Console.WriteLine("OwnerShip Role : ");
            //    Console.WriteLine("  1) Primary");
            //    Console.WriteLine("  2) Coholder ");
            //    Console.WriteLine("  2) Business ");
            //    Console.Write("    Choice : ");

            //    if (int.TryParse(Console.ReadLine(), out int role) && role == 1 || role == 2)
            //    {
            //        Orole = role;
            //        break;
            //    }
            //    else { Console.WriteLine("Enter a Valid Role ..  "); }
            //}


            //var newAccount = new Account()
            //{
            //    AccountNumber = accNumber,
            //    AccountType = (AccountType)accType,

            //    BranchId = branch.Id,
            //    CustomerAccounts = new List<CustomerAccount>() { new CustomerAccount() { CustomerId = cusId, OwnershipType = (OwnershipRole)Orole } }

            //};



            //Console.WriteLine($"Validating BranchCode #{branch.Code} and CustomerId #{cusId}");

            //Console.WriteLine($"Account #{accNumber} Created and linked to Customer #{cusId} as {Orole} Owner");



            //db.Accounts.Add(newAccount);
            //db.SaveChanges();

            #endregion
            /*
             Prompt for account number + customer Id, 
                then toggle AccountStatus  
             */

            #region Update Account Status
            //string accNumber;
            //while (true)
            //{
            //    Console.Write("Account Number : ");
            //    accNumber = Console.ReadLine();
            //    if (!string.IsNullOrWhiteSpace(accNumber) && accNumber.Length == 16)
            //        break;
            //    Console.WriteLine("Account Number Must be 16");
            //}

            //int cusId;
            //while (true)
            //{
            //    Console.Write("Customer ID : ");
            //    if (int.TryParse(Console.ReadLine(), out int id))
            //    {
            //        if (db.Customers.Any(c => c.Id == id))
            //        {
            //            cusId = id;
            //            break;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Enter a Valid Customer ID ");
            //        }
            //    }
            //}

            //var verfication = db.CustomerAccounts.Include(cs => cs.Account)
            //                                                  .Where(cs => cs.CustomerId == cusId && cs.Account.AccountNumber == accNumber)
            //                                                  .FirstOrDefault();


            //if (verfication != null)
            //{
            //    Console.WriteLine("New Status :  ");

            //    Console.WriteLine("  1) Active ");
            //    Console.WriteLine("  2) Closed ");
            //    Console.Write("   Choice  : ");

            //    int newState = int.Parse(Console.ReadLine());
            //    verfication.AccountStatus = (AccountStatus)newState;
            //    Console.WriteLine($"Status Udated to be {(AccountStatus)newState}");

            //} 
            #endregion



            #region Remove an Account from a Customer
            //string accNumber;
            //while (true)
            //{
            //    Console.Write("Account Number : ");
            //    accNumber = Console.ReadLine();
            //    if (!string.IsNullOrWhiteSpace(accNumber) && accNumber.Length == 16)
            //        break;
            //    Console.WriteLine("Account Number Must be 16");
            //}

            //int cusId;
            //while (true)
            //{
            //    Console.Write("Customer ID : ");
            //    if (int.TryParse(Console.ReadLine(), out int id))
            //    {
            //        if (db.Customers.Any(c => c.Id == id))
            //        {
            //            cusId = id;
            //            break;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Enter a Valid Customer ID ");
            //        }
            //    }
            //}


            //var verfication = db.CustomerAccounts.Include(cs => cs.Account)
            //                                                  .Where(cs => cs.CustomerId == cusId && cs.Account.AccountNumber == accNumber)
            //                                                  .FirstOrDefault();

            //if (verfication != null)
            //{
            //    db.CustomerAccounts.Remove(verfication);
            //    db.SaveChanges();
            //    Console.WriteLine("Ownership link deleted");
            //    Console.WriteLine($"That was the last owner - Account {accNumber} was also removed");
            //} 
            #endregion
            /*
             load each Customer's CustomerAccount rows 
             and the Account behind each. Print a tidy 
             formatted list.  
             
             
             
             */

            #region List All Customers
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
            #endregion





        }
    }
}
