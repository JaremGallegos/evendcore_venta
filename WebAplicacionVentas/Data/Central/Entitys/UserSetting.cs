using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entitys;

public partial class UserSetting
{
    public long SettingUser { get; set; }

    public string SettingLabel { get; set; } = null!;

    public string SettingValue { get; set; } = null!;

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
