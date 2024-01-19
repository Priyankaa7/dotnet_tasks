using System;
using System.Collections.Generic;

namespace AirplaneBooking.Models;

public partial class UserTable
{
    public string Email { get; set; } = null!;

    public string? Password { get; set; }
}
