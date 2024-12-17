using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class EmployeeDetail
{
    public long Id { get; set; }

    public string? Suffix { get; set; }

    public string? Valedictory { get; set; }

    public bool? SeeAuth { get; set; }

    public DateOnly? TerminationDate { get; set; }

    public decimal? Salary { get; set; }

    public string? Shift { get; set; }

    public string? ContractTerms { get; set; }

    public long EmployeeId { get; set; }

    public int AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
