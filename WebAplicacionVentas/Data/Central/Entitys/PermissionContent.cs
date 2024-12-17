using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entitys;

public partial class PermissionContent
{
    public int Id { get; set; }

    public bool Allowed { get; set; }

    public int ContentDetailId { get; set; }

    public byte PermissionId { get; set; }

    public virtual ContentDetail ContentDetail { get; set; } = null!;

    public virtual Permission Permission { get; set; } = null!;
}
