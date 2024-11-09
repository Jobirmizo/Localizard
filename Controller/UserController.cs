using AutoMapper;
using Localizard.DAL;
using Localizard.DAL.Repositories;
using Localizard.Domain.Entites;
using Localizard.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Localizard.Controller;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    
    private readonly IUserManager _userManager;
    private readonly IMapper _mapper;
    
    public UserController(IUserManager userManager, IMapper mapper )
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userManager.GetAllUsers();
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        if (!_userManager.UserExists(id))
            return NotFound();

        var user = await _userManager.GetByIdAsync(id);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(user);
    }
}