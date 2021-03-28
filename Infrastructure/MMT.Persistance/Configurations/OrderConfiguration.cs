using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMT.Domain.Entities;

namespace MMT.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("ORDERS");

            builder.Property(e => e.Orderid).HasColumnName("ORDERID");

            builder.Property(e => e.Containsgift).HasColumnName("CONTAINSGIFT");

            builder.Property(e => e.Customerid)
                .HasMaxLength(10)
                .HasColumnName("CUSTOMERID");

            builder.Property(e => e.Deliveryexpected)
                .HasColumnType("date")
                .HasColumnName("DELIVERYEXPECTED");

            builder.Property(e => e.Orderdate)
                .HasColumnType("date")
                .HasColumnName("ORDERDATE");

            builder.Property(e => e.Ordersource)
                .HasMaxLength(30)
                .HasColumnName("ORDERSOURCE");

            builder.Property(e => e.Shippingmode)
                .HasMaxLength(30)
                .HasColumnName("SHIPPINGMODE");
        }
    }
}