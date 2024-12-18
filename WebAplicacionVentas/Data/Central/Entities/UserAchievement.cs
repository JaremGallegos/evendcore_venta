using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entities;

public partial class UserAchievement
{
    public int Id { get; set; }

    public Guid Uuid { get; set; }

    public string AchievementTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime EarnedAt { get; set; }

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
