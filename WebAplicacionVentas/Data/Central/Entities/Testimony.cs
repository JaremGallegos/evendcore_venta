using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entities;

public partial class Testimony
{
    public long Id { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public byte Rating { get; set; }

    public int LikeCount { get; set; }

    public long UserId { get; set; }

    public byte TestimonyTypeId { get; set; }

    public virtual ICollection<TestimonyDetail> TestimonyDetails { get; set; } = new List<TestimonyDetail>();

    public virtual TestimonyType TestimonyType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
