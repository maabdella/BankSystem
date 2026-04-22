using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Models;

public class CustomerAccount
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public OwnershipRole OwnershipType { get; set; }
    public DateTime OwnershipStartDate { get; set; }
    public AccountStatus AccountStatus { get; set; }


}
public enum OwnershipRole
{
     Primary = 1,  
     CoHolder = 2  
}

public enum AccountStatus
{
    Active = 1, 
    Closed = 2  
}