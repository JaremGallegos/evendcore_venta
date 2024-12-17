using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entitys;

public partial class UserDetail
{
    public long Id { get; set; }

    public string? Pin { get; set; }

    public string? Facility { get; set; }

    public string? GoogleSigninEmail { get; set; }

    public string? GithubSignin { get; set; }

    public string? AppleSignin { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? Source { get; set; }

    public string? DefaultWarehouse { get; set; }

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
