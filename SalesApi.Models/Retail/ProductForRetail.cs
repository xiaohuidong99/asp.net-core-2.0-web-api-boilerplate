﻿using System.Collections.Generic;
using Infrastructure.Features.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesApi.Models.Settings;

namespace SalesApi.Models.Retail
{
    public class ProductForRetail : EntityBase
    {
        public ProductForRetail()
        {
            RetailPromotionSeries = new List<RetailPromotionSeries>();
            RetailPromotionSeriesBonuses = new List<RetailPromotionSeriesBonus>();
            RetailPromotionEvents = new List<RetailPromotionEvent>();
            RetailPromotionEventBonuses = new List<RetailPromotionEventBonus>();
            RetailProductSnapshots = new List<RetailProductSnapshot>();
        }

        public int ProductId { get; set; }
        public int EquivalentBox { get; set; }
        public decimal Price { get; set; }
        public decimal InternalPrice { get; set; }
        public decimal BoxPrice { get; set; }
        public bool IsOrderByBox { get; set; }
        public int MinOrderCount { get; set; }
        public int OrderDivisor { get; set; }

        public Product Product { get; set; }
        public ICollection<RetailPromotionSeries> RetailPromotionSeries { get; set; }
        public ICollection<RetailPromotionSeriesBonus> RetailPromotionSeriesBonuses { get; set; }
        public ICollection<RetailPromotionEvent> RetailPromotionEvents { get; set; }
        public ICollection<RetailPromotionEventBonus> RetailPromotionEventBonuses { get; set; }
        public ICollection<RetailProductSnapshot> RetailProductSnapshots { get; set; }
    }

    public class ProductForRetailConfiguration : EntityBaseConfiguration<ProductForRetail>
    {
        public override void ConfigureDerived(EntityTypeBuilder<ProductForRetail> b)
        {
            b.Property(x => x.Price).HasColumnType("decimal(10, 6)");
            b.Property(x => x.InternalPrice).HasColumnType("decimal(10, 6)");
            b.Property(x => x.BoxPrice).HasColumnType("decimal(10, 2)");
            b.HasOne(x => x.Product).WithOne(x => x.ProductForRetail).HasForeignKey<ProductForRetail>(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
