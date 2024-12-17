using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entitys;

public partial class Content
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<ContentDetail> ContentDetails { get; set; } = new List<ContentDetail>();
}
