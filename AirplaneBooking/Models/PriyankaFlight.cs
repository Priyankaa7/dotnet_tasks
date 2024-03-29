﻿using System;
using System.Collections.Generic;

namespace AirplaneBooking.Models;

public partial class PriyankaFlight
{
    public int FlightId { get; set; }

    public string? FlightName { get; set; }

    public string? Source { get; set; }

    public string? Destination { get; set; }

    public double? Rating { get; set; }

    public virtual ICollection<PriyankaBooking> PriyankaBookings { get; set; } = new List<PriyankaBooking>();
}
