using System;
using System.Collections.Generic;

namespace WebAplicacionVentas.Data.Ventas.Entitys;

public partial class TransactionType
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
