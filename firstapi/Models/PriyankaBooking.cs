using System;
using System.Collections.Generic;

namespace firstapi.Models;

public partial class PriyankaBooking
{
    public int BookingId { get; set; }

    public int? FlightId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? BookingDate { get; set; }

    public int? NoOfPassengers { get; set; }

    public double? TotalCost { get; set; }

    public virtual PriyankaCustomer? Customer { get; set; }

    public virtual PriyankaFlight? Flight { get; set; }
}
