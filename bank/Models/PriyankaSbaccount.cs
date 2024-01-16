using System;
using System.Collections.Generic;

namespace bank.Models;

public partial class PriyankaSbaccount
{
    public int AccountNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public decimal? CurrentBalance { get; set; }

    public virtual ICollection<PriyankaSbtransaction> PriyankaSbtransactions { get; set; } = new List<PriyankaSbtransaction>();
}
