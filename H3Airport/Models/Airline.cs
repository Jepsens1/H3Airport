using System;
using System.Collections.Generic;

namespace H3Airport.Models;

public partial class Airline
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Flight> Flights { get; } = new List<Flight>();
}
