using System;
using System.Collections.Generic;

namespace supps.Models;

public partial class DiscountsuppWebsite
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string TagElement { get; set; } = null!;

    public string TagClass { get; set; } = null!;

    public string Nametag { get; set; } = null!;

    public string Nameclass { get; set; } = null!;

    public string? Brandtag { get; set; }

    public string? Brandclass { get; set; }

    public string? Ogpricetag { get; set; }

    public string? Ogpriceclass { get; set; }

    public string Dispricetag { get; set; } = null!;

    public string Dispriceclass { get; set; } = null!;

    public string Urltag { get; set; } = null!;

    public string Urlclass { get; set; } = null!;

    public string Imgtag { get; set; } = null!;

    public string? Imgclass { get; set; }

    public byte[] Active { get; set; } = null!;

    public long? AdvertiserId { get; set; }

    public virtual DiscountsuppAdvertiser? Advertiser { get; set; }
}
