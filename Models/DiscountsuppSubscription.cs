using System;
using System.Collections.Generic;

namespace supps.Models;

public partial class DiscountsuppSubscription
{
    public long Id { get; set; }

    public byte[] Active { get; set; } = null!;

    public string Email { get; set; } = null!;
}
