using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entitys;

public partial class Lead
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime SubscriptionDate { get; set; }

    public virtual ICollection<LeadDetail> LeadDetails { get; set; } = new List<LeadDetail>();
}
