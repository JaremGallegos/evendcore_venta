using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class SytemDetail
{
    public long Id { get; set; }

    public string? Description { get; set; }

    public string? SupportContact { get; set; }

    public DateTime? LastBackupDate { get; set; }

    public int? MaxUsers { get; set; }

    public string? LicenseKey { get; set; }

    public string? OsSupported { get; set; }

    public string? LogLevel { get; set; }

    public string? ActiveModules { get; set; }

    public long SystemId { get; set; }

    public virtual System System { get; set; } = null!;
}
