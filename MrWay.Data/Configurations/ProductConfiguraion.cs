using Microsoft.EntityFrameworkCore;
using MrWay.Domain.DomainModels.Retail;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MrWay.Data.Configurations
{
    public class ProductConfiguraion : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Store)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.StoreId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
