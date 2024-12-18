using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entities;

public partial class ContentType
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<ContentDetail> ContentDetails { get; set; } = new List<ContentDetail>();
}
