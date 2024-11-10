using AutoMapper;
using Localizard.DAL.Repositories;
using Localizard.Domain.Entites;
using Localizard.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Localizard.Controller;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectRepo _projectRepo;
    private readonly IMapper _mapper;
    
    public ProjectController(IProjectRepo project, IMapper mapper)
    {
        _projectRepo = project;
        _mapper = mapper;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var projects = await _projectRepo.GetAllProjects();
        var mappedProjects = _mapper.Map<List<ProjectInfoDto>>(projects);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(mappedProjects);
    }
    
   
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        if (!_projectRepo.ProjectExists(id))
            return NotFound();

        var project = await _projectRepo.GetById(id);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(project);
    }
}