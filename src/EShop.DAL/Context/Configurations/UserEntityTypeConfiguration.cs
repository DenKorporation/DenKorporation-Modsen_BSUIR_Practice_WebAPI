using EShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DAL.Context.Configurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder
            .Property(u => u.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(u => u.Email)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .HasIndex(c => c.Email)
            .IsUnique();
    }
}