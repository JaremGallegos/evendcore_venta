using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entities;

public partial class UserSecure
{
    public long Id { get; set; }

    public string PasswordHistory1 { get; set; } = null!;

    public string PasswordHistory2 { get; set; } = null!;

    public string PasswordHistory3 { get; set; } = null!;

    public string PasswordHistory4 { get; set; } = null!;

    public bool AutoBlockEmailed { get; set; }

    public string LoginWorkArea { get; set; } = null!;

    public int TotalLoginFailCounter { get; set; }

    public int LoginFailCounter { get; set; }

    public DateTime LastUpdated { get; set; }

    public DateTime? LastChallengeResponse { get; set; }

    public DateTime? LastLoginFail { get; set; }

    public DateTime? LastUpdatedPassword { get; set; }

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
