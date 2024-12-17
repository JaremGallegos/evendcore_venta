using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class ModuleDetail
{
    public byte Id { get; set; }

    public string? ModDirectory { get; set; }

    public string? ModUiName { get; set; }

    public bool? ModUiActive { get; set; }

    public string? ModNickName { get; set; }

    public string? ModEncMenu { get; set; }

    public string? PermissionsItemTable { get; set; }

    public string? Directory { get; set; }

    public string? SqlRun { get; set; }

    public string? SqlVersion { get; set; }

    public string? AclVersion { get; set; }

    public byte ModuleId { get; set; }

    public virtual Module Module { get; set; } = null!;
}
