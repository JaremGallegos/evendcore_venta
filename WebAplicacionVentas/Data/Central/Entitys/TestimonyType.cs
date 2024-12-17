using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entitys;

public partial class TestimonyType
{
    public byte Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Testimony> Testimonies { get; set; } = new List<Testimony>();
}
