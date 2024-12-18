using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class System
{
    public long Id { get; set; }

    public Guid Uuid { get; set; }

    public string Name { get; set; } = null!;

    public string Version { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAd { get; set; }

    public string Type { get; set; } = null!;

    public string Environment { get; set; } = null!;

    public virtual ICollection<AutomaticNotification> AutomaticNotifications { get; set; } = new List<AutomaticNotification>();

    public virtual ICollection<SytemDetail> SytemDetails { get; set; } = new List<SytemDetail>();
}
