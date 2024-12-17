using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class Facility
{
    public long Id { get; set; }

    public Guid Uuid { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Direction { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime LastUpdated { get; set; }

    public byte IdentificationTypeId { get; set; }

    public int AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<FacilityDetail> FacilityDetails { get; set; } = new List<FacilityDetail>();

    public virtual IdentificationType IdentificationType { get; set; } = null!;
}
