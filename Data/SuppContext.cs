using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using supps.Models;

namespace supps.Data;

public partial class SuppContext : DbContext
{
    public SuppContext()
    {
    }

    public SuppContext(DbContextOptions<SuppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiscountsuppAdvertiser> DiscountsuppAdvertisers { get; set; }

    public virtual DbSet<DiscountsuppBrand> DiscountsuppBrands { get; set; }

    public virtual DbSet<DiscountsuppBrandpagevisit> DiscountsuppBrandpagevisits { get; set; }

    public virtual DbSet<DiscountsuppCategory> DiscountsuppCategories { get; set; }

    public virtual DbSet<DiscountsuppSearch> DiscountsuppSearches { get; set; }

    public virtual DbSet<DiscountsuppSubscription> DiscountsuppSubscriptions { get; set; }

    public virtual DbSet<DiscountsuppSupplement> DiscountsuppSupplements { get; set; }

    public virtual DbSet<DiscountsuppSupplementlink> DiscountsuppSupplementlinks { get; set; }

    public virtual DbSet<DiscountsuppWebsite> DiscountsuppWebsites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=db.sqlite3");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiscountsuppAdvertiser>(entity =>
        {
            entity.ToTable("discountsupp_advertiser");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("varchar(200)")
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasColumnType("varchar(200)")
                .HasColumnName("url");
        });

        modelBuilder.Entity<DiscountsuppBrand>(entity =>
        {
            entity.ToTable("discountsupp_brand");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("varchar(200)")
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasColumnType("varchar(200)")
                .HasColumnName("url");
        });

        modelBuilder.Entity<DiscountsuppBrandpagevisit>(entity =>
        {
            entity.ToTable("discountsupp_brandpagevisit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasColumnType("varchar(200)")
                .HasColumnName("brand");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Page)
                .HasColumnType("varchar(400)")
                .HasColumnName("page");
        });

        modelBuilder.Entity<DiscountsuppCategory>(entity =>
        {
            entity.ToTable("discountsupp_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("varchar(200)")
                .HasColumnName("name");
        });

        modelBuilder.Entity<DiscountsuppSearch>(entity =>
        {
            entity.ToTable("discountsupp_search");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Search)
                .HasColumnType("varchar(400)")
                .HasColumnName("search");
        });

        modelBuilder.Entity<DiscountsuppSubscription>(entity =>
        {
            entity.ToTable("discountsupp_subscription");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasColumnType("bool")
                .HasColumnName("active");
            entity.Property(e => e.Email)
                .HasColumnType("varchar(200)")
                .HasColumnName("email");
        });

        modelBuilder.Entity<DiscountsuppSupplement>(entity =>
        {
            entity.ToTable("discountsupp_supplement");

            entity.HasIndex(e => e.AdvertiserId, "discountsupp_supplement_advertiser_id_2bb55f56");

            entity.HasIndex(e => e.BrandId, "discountsupp_supplement_brand_id_d84b26a6");

            entity.HasIndex(e => e.CategoryId, "discountsupp_supplement_category_id_7bbfb019");

            entity.HasIndex(e => e.SupplementlinkId, "discountsupp_supplement_supplementlink_id_53180ecc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasColumnType("bool")
                .HasColumnName("active");
            entity.Property(e => e.AdvertiserId)
                .HasColumnType("bigint")
                .HasColumnName("advertiser_id");
            entity.Property(e => e.BrandId)
                .HasColumnType("bigint")
                .HasColumnName("brand_id");
            entity.Property(e => e.CategoryId)
                .HasColumnType("bigint")
                .HasColumnName("category_id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal")
                .HasColumnName("discount");
            entity.Property(e => e.DiscountPrice)
                .HasColumnType("decimal")
                .HasColumnName("discount_price");
            entity.Property(e => e.Image)
                .HasColumnType("varchar(200)")
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasColumnType("varchar(200)")
                .HasColumnName("name");
            entity.Property(e => e.OriginalPrice)
                .HasColumnType("decimal")
                .HasColumnName("original_price");
            entity.Property(e => e.SupplementlinkId)
                .HasColumnType("bigint")
                .HasColumnName("supplementlink_id");
            entity.Property(e => e.Url)
                .HasColumnType("varchar(200)")
                .HasColumnName("url");

            entity.HasOne(d => d.Advertiser).WithMany(p => p.DiscountsuppSupplements).HasForeignKey(d => d.AdvertiserId);

            entity.HasOne(d => d.Brand).WithMany(p => p.DiscountsuppSupplements).HasForeignKey(d => d.BrandId);

            entity.HasOne(d => d.Category).WithMany(p => p.DiscountsuppSupplements).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Supplementlink).WithMany(p => p.DiscountsuppSupplements).HasForeignKey(d => d.SupplementlinkId);
        });

        modelBuilder.Entity<DiscountsuppSupplementlink>(entity =>
        {
            entity.ToTable("discountsupp_supplementlink");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("varchar(200)")
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasColumnType("varchar(200)")
                .HasColumnName("url");
        });

        modelBuilder.Entity<DiscountsuppWebsite>(entity =>
        {
            entity.ToTable("discountsupp_website");

            entity.HasIndex(e => e.AdvertiserId, "discountsupp_website_advertiser_id_00e06816");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasColumnType("bool")
                .HasColumnName("active");
            entity.Property(e => e.AdvertiserId)
                .HasColumnType("bigint")
                .HasColumnName("advertiser_id");
            entity.Property(e => e.Brandclass)
                .HasColumnType("varchar(200)")
                .HasColumnName("brandclass");
            entity.Property(e => e.Brandtag)
                .HasColumnType("varchar(200)")
                .HasColumnName("brandtag");
            entity.Property(e => e.Dispriceclass)
                .HasColumnType("varchar(200)")
                .HasColumnName("dispriceclass");
            entity.Property(e => e.Dispricetag)
                .HasColumnType("varchar(200)")
                .HasColumnName("dispricetag");
            entity.Property(e => e.Imgclass)
                .HasColumnType("varchar(200)")
                .HasColumnName("imgclass");
            entity.Property(e => e.Imgtag)
                .HasColumnType("varchar(200)")
                .HasColumnName("imgtag");
            entity.Property(e => e.Name)
                .HasColumnType("varchar(200)")
                .HasColumnName("name");
            entity.Property(e => e.Nameclass)
                .HasColumnType("varchar(200)")
                .HasColumnName("nameclass");
            entity.Property(e => e.Nametag)
                .HasColumnType("varchar(200)")
                .HasColumnName("nametag");
            entity.Property(e => e.Ogpriceclass)
                .HasColumnType("varchar(200)")
                .HasColumnName("ogpriceclass");
            entity.Property(e => e.Ogpricetag)
                .HasColumnType("varchar(200)")
                .HasColumnName("ogpricetag");
            entity.Property(e => e.TagClass)
                .HasColumnType("varchar(200)")
                .HasColumnName("tag_class");
            entity.Property(e => e.TagElement)
                .HasColumnType("varchar(200)")
                .HasColumnName("tag_element");
            entity.Property(e => e.Url)
                .HasColumnType("varchar(400)")
                .HasColumnName("url");
            entity.Property(e => e.Urlclass)
                .HasColumnType("varchar(200)")
                .HasColumnName("urlclass");
            entity.Property(e => e.Urltag)
                .HasColumnType("varchar(200)")
                .HasColumnName("urltag");

            entity.HasOne(d => d.Advertiser).WithMany(p => p.DiscountsuppWebsites).HasForeignKey(d => d.AdvertiserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
