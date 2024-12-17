using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class AutomaticNotification
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string Status { get; set; } = null!;

    public string TriggerEvent { get; set; } = null!;

    public long SystemId { get; set; }

    public long EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual System System { get; set; } = null!;
}
