using System;
using System.Collections.Generic;

namespace supps.Models;

public partial class DiscountsuppSupplement
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public float OriginalPrice { get; set; }

    public float DiscountPrice { get; set; }

    public string? Url { get; set; }

    public long? BrandId { get; set; }

    public string? Image { get; set; }

    public long? CategoryId { get; set; }

    public DateOnly? Date { get; set; }

    public float Discount { get; set; }

    public bool Active { get; set; }

    public long? AdvertiserId { get; set; }

    public long? SupplementlinkId { get; set; }

    public virtual DiscountsuppAdvertiser? Advertiser { get; set; }

    public virtual DiscountsuppBrand? Brand { get; set; }

    public virtual DiscountsuppCategory? Category { get; set; }

    public virtual DiscountsuppSupplementlink? Supplementlink { get; set; }
}
