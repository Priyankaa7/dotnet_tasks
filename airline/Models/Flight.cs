using System.ComponentModel.DataAnnotations;

public partial class Flight
{
    public int FlightId { get; set; }

    [Required(ErrorMessage = "Please Enter name of flight")]
    public string? FlightName { get; set; }

    [Required(ErrorMessage = "Enter source of flight")]
    public string? Source { get; set; }

    [Required(ErrorMessage = "Enter destination of flight")]
    public string? Destination { get; set; }

    public double? Rating { get; set; }

    [Required(ErrorMessage = "Enter price of ticket")]
    public double? CostPerTicket { get; set; }
}