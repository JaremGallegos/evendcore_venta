using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class IdentificationType
{
    public byte Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Facility> Facilities { get; set; } = new List<Facility>();
}
