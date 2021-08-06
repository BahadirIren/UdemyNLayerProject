using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // TODO primary key ne ise yariyor?
            // Id alanini primary key yap HasKey metodu yardimiyla
            builder.HasKey(x => x.Id);

            // Id birer birer artsin
            builder.Property(x => x.Id).UseIdentityColumn();

            // product name girilmesi zorunlu olsun max length ise 200 olsun
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Stock).IsRequired();

            // 123.52 TL decimal(5,2) (5: toplam 5 karakter, 2: virgulden sonra kac karakter oludugu)
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(x => x.InnerBarcode).HasMaxLength(50);

            // tablo ismi
            builder.ToTable("Products");
        }
    }
}
