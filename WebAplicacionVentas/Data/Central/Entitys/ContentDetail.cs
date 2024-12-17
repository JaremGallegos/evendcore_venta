using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Central.Entitys;

public partial class ContentDetail
{
    public int Id { get; set; }

    public string ContDirectory { get; set; } = null!;

    public string ContParent { get; set; } = null!;

    public string ContType { get; set; } = null!;

    public bool ContActive { get; set; }

    public string ContUiName { get; set; } = null!;

    public string ContRelativeLink { get; set; } = null!;

    public byte ContUiOrder { get; set; }

    public bool ContUiActive { get; set; }

    public string ContDescription { get; set; } = null!;

    public string ContNickName { get; set; } = null!;

    public string ContEncMenu { get; set; } = null!;

    public bool PermissionsItemTable { get; set; }

    public string Directory { get; set; } = null!;

    public DateTime Date { get; set; }

    public byte SqlRun { get; set; }

    public string SqlVersion { get; set; } = null!;

    public string AclVersion { get; set; } = null!;

    public long ContentId { get; set; }

    public int ContentTypeId { get; set; }

    public virtual Content Content { get; set; } = null!;

    public virtual ICollection<ContentSection> ContentSections { get; set; } = new List<ContentSection>();

    public virtual ContentType ContentType { get; set; } = null!;

    public virtual ICollection<PermissionContent> PermissionContents { get; set; } = new List<PermissionContent>();
}
