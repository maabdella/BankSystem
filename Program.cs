using BankSystem.Models;
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
            string name;
            while (true)
            {
                Console.Write("Full Name : ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Enter Valid Name");
                }
                break;
            }

            string nationalId;
            while (true)
            {
                Console.Write("NationalID : ");
                nationalId = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(nationalId) && nationalId.Length == 14)
                    break;
                Console.WriteLine( "National Id Must be 14");
            }
            string email;
            while (true)
            {
                Console.Write("Email : ");
                email = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(email) && email.Contains("@"))
                    break;
                Console.WriteLine("Enter Valid Email");
            }

            DateTime dob;
            while (true)
            {
                try
                {
                    Console.Write("Date of Birth (yyyy-MM-dd) : ");
                    dob = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid date format. Use yyyy-MM-dd.");
                }
            }

            string phone;
            while (true)
            {
                Console.Write("Phone Number : ");
                phone = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(phone) && phone.Length >= 10)
                    break;

                Console.WriteLine("Phone number must be at least 10 digits.");
            }

          
            string address;
            while (true)
            {
                Console.Write("Address : ");
                address = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(address))
                    break;

                Console.WriteLine("Address is required.");
            }

            int type;
            while (true) 
            {
                Console.WriteLine("Customer Type : ");
                Console.WriteLine("  1) Individual");
                Console.WriteLine("  2) Business ");
                Console.Write("    Choice : ");

                if (int.TryParse(Console.ReadLine(), out int t) && t == 1 || t == 2)
                {
                    type = t;
                    break;
                }
                else 
                {
                    Console.WriteLine("Enter 1 Or 2 "); 
                }
            }

            var customer = new Customer
            {
                FullName = name,
                Email = email,
                Address = address,
                CustomerType = (CustomerType)type,
                PhoneNumber = phone,
                NationalId = nationalId,
                DateOfBirth = dob
            };


            db.Customers.Add( customer );
            db.SaveChanges();   


            Console.WriteLine($"Customer Created Succesfully CustomerID #{customer.Id}");
            #endregion











        }
    }
}
