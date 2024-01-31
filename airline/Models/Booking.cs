public partial class Booking
{
    public int BookingId { get; set; }

    public int? FlightId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? BookingDate { get; set; }

    public int? NoOfPassengers { get; set; }

    public double? TotalCost { get; set; }
}