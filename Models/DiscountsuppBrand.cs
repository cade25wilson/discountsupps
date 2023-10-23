﻿using System;
using System.Collections.Generic;

namespace supps.Models;

public partial class DiscountsuppBrand
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<DiscountsuppSupplement> DiscountsuppSupplements { get; set; } = new List<DiscountsuppSupplement>();
}
