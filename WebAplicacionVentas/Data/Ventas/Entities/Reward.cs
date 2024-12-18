using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class Reward
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Value { get; set; }

    public string Criteria { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int RewardTypeId { get; set; }

    public virtual ICollection<RewardDetail> RewardDetails { get; set; } = new List<RewardDetail>();

    public virtual RewardType RewardType { get; set; } = null!;
}
