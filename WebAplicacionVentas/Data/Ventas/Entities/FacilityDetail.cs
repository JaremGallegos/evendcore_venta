using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class FacilityDetail
{
    public long Id { get; set; }

    public string? X12SenderId { get; set; }

    public string? WenoId { get; set; }

    public string? Website { get; set; }

    public bool? ServiceLocation { get; set; }

    public bool? BillingLocation { get; set; }

    public bool? AcceptsAssignment { get; set; }

    public string? PosCode { get; set; }

    public string? Attn { get; set; }

    public string? DomainIdentifier { get; set; }

    public string? Color { get; set; }

    public bool? PrimaryBusinessEntity { get; set; }

    public string? FacilityCode { get; set; }

    public bool? ExtraValidation { get; set; }

    public string? Cci { get; set; }

    public string? Info { get; set; }

    public bool? Inactive { get; set; }

    public long FacilityId { get; set; }

    public virtual Facility Facility { get; set; } = null!;
}
