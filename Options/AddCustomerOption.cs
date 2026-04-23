using System;
using System.Collections.Generic;
using System.Text;
using BankSystem.Models;


namespace BankSystem.Options;

public static class AddCustomerOption
{
    public static void AddCustomer()
    {
        using var db = new BankDbContext();

        Console.WriteLine("-------- Add New Cusomer --------");
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
            if (!string.IsNullOrWhiteSpace(nationalId) && nationalId.Length == 14)
                break;
            Console.WriteLine("National Id Must be 14");
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

        int custype;
        while (true)
        {
            Console.WriteLine("Customer Type : ");
            Console.WriteLine("  1) Individual");
            Console.WriteLine("  2) Business ");
            Console.Write("    Choice : ");

            if (int.TryParse(Console.ReadLine(), out int t) && t == 1 || t == 2)
            {
                custype = t;
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
            CustomerType = (CustomerType)custype,
            PhoneNumber = phone,
            NationalId = nationalId,
            DateOfBirth = dob
        };


        db.Customers.Add(customer);
        db.SaveChanges();


        Console.WriteLine($"Customer Created Succesfully CustomerID #{customer.Id}");
    }
}
