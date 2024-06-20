using EShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DAL.Context.Configurations;

public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder
            .HasKey(oi => oi.Id);

        builder
            .Property(oi => oi.Quantity)
            .IsRequired();

        builder
            .Property(oi => oi.ProductId)
            .IsRequired();
        
        builder
            .Property(oi => oi.OrderId)
            .IsRequired();

        builder
            .HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(oi => oi.Order)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}