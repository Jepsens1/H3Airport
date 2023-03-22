using System;
using System.Collections.Generic;

namespace H3Airport.Models;

public partial class Flight
{
    public int Id { get; set; }

    public int? AirlineId { get; set; }

    public string? Departurelocation { get; set; }

    public string? Destination { get; set; }

    public DateTime? DepartureTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public virtual Airline? Airline { get; set; }

    public virtual Airport? DeparturelocationNavigation { get; set; }

    public virtual Airport? DestinationNavigation { get; set; }
}
