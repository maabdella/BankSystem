using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Models;

public class Account
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public decimal CurrentBalance { get; set; }
    public AccountType AccountType { get; set; }
    public DateTime OpeningDate { get; set; }

    public Branch Branch { get; set; }
    public int BranchId { get; set; }

    public ICollection<CustomerAccount> CustomerAccounts { get; set; }  = new HashSet<CustomerAccount>();
    public ICollection<Transaction> Transactions { get; set; } =new HashSet<Transaction>();

}

public enum AccountType
{
    Savings = 1, 
    Current = 2, 
    Business = 3 
}
