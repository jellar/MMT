using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMT.Domain.Entities;

namespace MMT.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCTS");

            builder.Property(e => e.Productid).HasColumnName("PRODUCTID");

            builder.Property(e => e.Colour)
                .HasMaxLength(20)
                .HasColumnName("COLOUR");

            builder.Property(e => e.Packheight)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PACKHEIGHT");

            builder.Property(e => e.Packweight)
                .HasColumnType("decimal(8, 3)")
                .HasColumnName("PACKWEIGHT");

            builder.Property(e => e.Packwidth)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PACKWIDTH");

            builder.Property(e => e.Productname)
                .HasMaxLength(50)
                .HasColumnName("PRODUCTNAME");

            builder.Property(e => e.Size)
                .HasMaxLength(20)
                .HasColumnName("SIZE");
        }
    }
}