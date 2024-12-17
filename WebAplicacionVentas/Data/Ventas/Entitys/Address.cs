using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class Address
{
    public int Id { get; set; }

    public string? CountryCode { get; set; }

    public string? Country { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? PostalCode { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; } = new List<EmployeeDetail>();

    public virtual ICollection<Facility> Facilities { get; set; } = new List<Facility>();
}
