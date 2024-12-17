using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class CustomerEmployee
{
    public long CustomerId { get; set; }

    public long EmployeeId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
