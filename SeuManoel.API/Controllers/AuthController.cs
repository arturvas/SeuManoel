using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SeuManoel.API.Core.Dtos;

namespace SeuManoel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        if (loginDto is not { Username: "admin", Password: "0210" }) return Unauthorized();
        
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, loginDto.Username)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("voceNaoVaiVerMinhaSenhaSuperSecreta@987"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);
            
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            
        return Ok(new { token = tokenString });
    }
}
