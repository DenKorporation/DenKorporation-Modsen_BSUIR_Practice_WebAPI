using Microsoft.AspNetCore.Identity;

namespace EShop.DAL.Entities;

public class User : IdentityUser<Guid>
{
    public ICollection<Order> Orders { get; set; } = null!;
}