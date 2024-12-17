using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class Employee
{
    public long Id { get; set; }

    public Guid Uuid { get; set; }

    public string In { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Fname { get; set; } = null!;

    public string Mname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public byte RoleId { get; set; }

    public virtual ICollection<AutomaticNotification> AutomaticNotifications { get; set; } = new List<AutomaticNotification>();

    public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();

    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; } = new List<EmployeeDetail>();

    public virtual Role Role { get; set; } = null!;
}
