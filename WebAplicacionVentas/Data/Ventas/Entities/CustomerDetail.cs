using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entities;

public partial class CustomerDetail
{
    public long Id { get; set; }

    public string? Title { get; set; }

    public string? PreferredName { get; set; }

    public string? Language { get; set; }

    public string? Email { get; set; }

    public string? ContactRelationship { get; set; }

    public string? BillingNote { get; set; }

    public bool? Financial { get; set; }

    public bool? IsRetain { get; set; }

    public string? Status { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? UpdatedBy { get; set; }

    public string? ContractTerms { get; set; }

    public long CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
