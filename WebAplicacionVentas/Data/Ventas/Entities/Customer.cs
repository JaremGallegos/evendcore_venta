using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class Customer
{
    public long Id { get; set; }

    public Guid Uuid { get; set; }

    public string In { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Fname { get; set; } = null!;

    public string Mname { get; set; } = null!;

    public bool Sex { get; set; }

    public DateOnly Dob { get; set; }

    public string Phone { get; set; } = null!;

    public DateTime LastUpdated { get; set; }

    public byte IdentificationTypeId { get; set; }

    public int AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();

    public virtual ICollection<CustomerDetail> CustomerDetails { get; set; } = new List<CustomerDetail>();

    public virtual IdentificationType IdentificationType { get; set; } = null!;

    public virtual ICollection<Loyalty> Loyalties { get; set; } = new List<Loyalty>();
}
