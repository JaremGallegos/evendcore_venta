using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entitys;

public partial class Configuration
{
    public long Id { get; set; }

    public string KeyName { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
