using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankSystem.Models;

public class Branch
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    public Manager Manager { get; set; }
    public ICollection<Account> Accounts { get; set; } = new HashSet<Account>();
}
