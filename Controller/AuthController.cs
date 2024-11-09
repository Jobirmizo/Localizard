using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Localizard.DAL;
using Localizard.DAL.Repositories;
using Localizard.Domain.Entites;
using Localizard.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Localizard.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserManager _userManager;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    
    public static User user = new User();
    public AuthController(IUserManager userManager, IMapper mapper, IConfiguration configuration)
    {
        _userManager = userManager;
        _mapper = mapper;
        _configuration = configuration;
    }

    
    
    [HttpPost]
    public ActionResult<User> Login(LoginDto request)
    {
        if (user.Username != request.Useranme)
            return BadRequest("User not found!");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return BadRequest("Wrong password!");

        string token = CreateToken(user);
        
        return Ok(token);
    }

    [HttpPost]
    public  ActionResult<User> Register(LoginDto request)
    {
        string passwordHash
            = BCrypt.Net.BCrypt.HashPassword(request.Password);
        user.Username = request.Useranme;
        user.PasswordHash = passwordHash;

        return Ok(user);
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token  =new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

}
    