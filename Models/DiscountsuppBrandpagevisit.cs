using System;
using System.Collections.Generic;

namespace supps.Models;

public partial class DiscountsuppBrandpagevisit
{
    public long Id { get; set; }

    public string Page { get; set; } = null!;

    public byte[] Date { get; set; } = null!;

    public string Brand { get; set; } = null!;
}
