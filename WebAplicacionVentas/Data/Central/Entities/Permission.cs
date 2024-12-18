using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entities;

public partial class Permission
{
    public byte Id { get; set; }

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime LastUpdated { get; set; }

    public virtual ICollection<PermissionContent> PermissionContents { get; set; } = new List<PermissionContent>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
