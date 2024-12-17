using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class SupplierDetail
{
    public long Id { get; set; }

    public byte? Rating { get; set; }

    public string? Notes { get; set; }

    public string? ContractTerms { get; set; }

    public bool? AcceptTerms { get; set; }

    public long SupplierId { get; set; }

    public int AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
