using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMT.Domain.Entities;

namespace MMT.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<Orderitem>
    {
        public void Configure(EntityTypeBuilder<Orderitem> builder)
        {
            builder.ToTable("ORDERITEMS");

            builder.Property(e => e.Orderitemid).HasColumnName("ORDERITEMID");

            builder.Property(e => e.Orderid).HasColumnName("ORDERID");

            builder.Property(e => e.Price)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PRICE");

            builder.Property(e => e.Productid).HasColumnName("PRODUCTID");

            builder.Property(e => e.Quantity).HasColumnName("QUANTITY");

            builder.Property(e => e.Returnable).HasColumnName("RETURNABLE");

            builder.HasOne(d => d.Order)
                .WithMany(p => p.Orderitems)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("FK__ORDERITEM__ORDER__60A75C0F");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Orderitems)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("FK__ORDERITEM__PRODU__619B8048");
        }
    }
}