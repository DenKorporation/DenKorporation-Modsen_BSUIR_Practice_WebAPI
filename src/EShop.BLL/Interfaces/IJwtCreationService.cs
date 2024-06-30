using System.Security.Claims;

namespace EShop.BLL.Interfaces;

public interface IJwtCreationService
{
    string GenerateToken(ClaimsIdentity claimsIdentity);
}