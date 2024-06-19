using EShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DAL.Context.Configurations;

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasIndex(c => c.Name)
            .IsUnique();
    }
}