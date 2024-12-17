using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entitys;

public partial class ContentSection
{
    public int Id { get; set; }

    public string? SectionName { get; set; }

    public int? ParentSection { get; set; }

    public string? SectionIdentifier { get; set; }

    public int ContentDetailId { get; set; }

    public virtual ContentDetail ContentDetail { get; set; } = null!;
}
