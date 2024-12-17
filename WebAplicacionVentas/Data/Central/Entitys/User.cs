using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entitys;

public partial class User
{
    public long Id { get; set; }

    public Guid Uuid { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime LastUpdated { get; set; }

    public DateTime DateCreated { get; set; }

    public byte PermissionId { get; set; }

    public virtual ICollection<Analitic> Analitics { get; set; } = new List<Analitic>();

    public virtual ICollection<Configuration> Configurations { get; set; } = new List<Configuration>();

    public virtual Permission Permission { get; set; } = null!;

    public virtual ICollection<Testimony> Testimonies { get; set; } = new List<Testimony>();

    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();

    public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();

    public virtual ICollection<UserSecure> UserSecures { get; set; } = new List<UserSecure>();

    public virtual ICollection<UserSetting> UserSettings { get; set; } = new List<UserSetting>();
}
