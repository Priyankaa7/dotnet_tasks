using System;
using System.Collections.Generic;

namespace firstapi.Models;

public partial class PriyankaCustomer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? Location { get; set; }

    /*public virtual ICollection<PriyankaBooking> PriyankaBookings { get; set; } = new List<PriyankaBooking>();*/
}
