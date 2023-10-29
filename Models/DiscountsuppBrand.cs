using System;
using System.Collections.Generic;

namespace supps.Models;

public partial class DiscountsuppBrand
{
    public long Id { get; set; }

    public string BrandName { get; set; } = null!;

    public string BrandUrl { get; set; } = null!;

    public virtual ICollection<DiscountsuppSupplement> DiscountsuppSupplements { get; set; } = new List<DiscountsuppSupplement>();
}
