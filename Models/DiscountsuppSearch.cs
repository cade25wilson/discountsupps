using System;
using System.Collections.Generic;

namespace supps.Models;

public partial class DiscountsuppSearch
{
    public long Id { get; set; }

    public string Search { get; set; } = null!;

    public byte[] Date { get; set; } = null!;
}
