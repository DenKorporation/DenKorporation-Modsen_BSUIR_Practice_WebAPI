using EShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DAL.Context.Configurations;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasKey(o => o.Id);

        builder
            .Property(o => o.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(o => o.OrderDate)
            .IsRequired();
        
        builder
            .Property(o => o.Address)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .Property(o => o.Commentary)
            .HasMaxLength(200);

        builder
            .Property(o => o.CustomerId)
            .IsRequired();

        builder
            .Property(o => o.OrderStatus)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder
            .HasOne(o => o.Customer)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}