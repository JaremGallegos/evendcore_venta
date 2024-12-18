using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entities;

public partial class LeadDetail
{
    public int Id { get; set; }

    public string? Phone { get; set; }

    public string? Message { get; set; }

    public long LeadsId { get; set; }

    public virtual Lead Leads { get; set; } = null!;
}
