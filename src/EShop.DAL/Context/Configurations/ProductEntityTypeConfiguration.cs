using EShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DAL.Context.Configurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(p => p.Description)
            .HasMaxLength(200)
            .IsRequired();
        
        builder
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        
        builder
            .Property(p => p.AvailableStock)
            .IsRequired();
        
        builder
            .Property(p => p.CategoryId)
            .IsRequired();

        builder
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasIndex(c => c.Name)
            .IsUnique();
    }
}