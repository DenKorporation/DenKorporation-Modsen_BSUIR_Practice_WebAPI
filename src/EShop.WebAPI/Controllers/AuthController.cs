using System.Security.Claims;
using EShop.BLL.DTO.User;
using EShop.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IJwtCreationService _jwtCreationService;
    
    public AuthController(IUserService userService, IJwtCreationService jwtCreationService)
    {
        _userService = userService;
        _jwtCreationService = jwtCreationService;
    }
    
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(
        [FromBody] RegisterUserDto model, CancellationToken cancellationToken = default)
    {
        var user = await _userService.Register(model, cancellationToken);

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUserDto model, CancellationToken cancellationToken = default)
    {
        var loggedUser = await _userService.Login(model, cancellationToken);

        var claims = new ClaimsIdentity();
        
        var token = _jwtCreationService.GenerateToken(claims);

        return Ok("Bearer " + token);
    }
}