using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class Loyalty
{
    public int Id { get; set; }

    public int TotalPoints { get; set; }

    public string MembershipLevel { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Status { get; set; } = null!;

    public long CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
