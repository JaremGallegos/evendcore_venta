using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entitys;

public partial class Analitic
{
    public long Id { get; set; }

    public string UserIp { get; set; } = null!;

    public string PageViewed { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Referrer { get; set; } = null!;

    public int SessionDuration { get; set; }

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
