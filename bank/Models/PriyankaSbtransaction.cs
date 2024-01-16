using System;
using System.Collections.Generic;

namespace bank.Models;

public partial class PriyankaSbtransaction
{
    public int TransactionId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public int? AccountNumber { get; set; }

    public decimal? Amount { get; set; }

    public string? TransactionType { get; set; }

    public virtual PriyankaSbaccount? AccountNumberNavigation { get; set; }
}
