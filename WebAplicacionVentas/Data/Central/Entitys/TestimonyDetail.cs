using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entitys;

public partial class TestimonyDetail
{
    public int Id { get; set; }

    public bool? IsVisible { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? ImageUrl { get; set; }

    public long TestimonyId { get; set; }

    public virtual Testimony Testimony { get; set; } = null!;
}
