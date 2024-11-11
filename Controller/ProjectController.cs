using AutoMapper;
using System.Linq;
using Localizard.DAL.Repositories;
using Localizard.Domain.Entites;
using Localizard.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Localizard.Controller;

[Route("api/[controller]/[action]")]
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
    public  IActionResult GetAllProjects()
    {
        var projects = _projectRepo.GetAllProjects();
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

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateProject([FromBody] ProjectInfoDto projectCreate)
    {
        if (projectCreate == null)
            return BadRequest(ModelState);

        var project = _projectRepo.GetAllProjects()
            .Where(p => p.Name.Trim().ToUpper() == projectCreate.Name.TrimEnd().ToUpper())
            .FirstOrDefault();

        if (project != null)
        {
            ModelState.AddModelError("", "Project already exist!");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var projectMap = _mapper.Map<List<ProjectInfoDto>>(projectCreate);

        if (!_projectRepo.CreateProject(projectMap))
        {
            ModelState.AddModelError("", "Something went wrong! while saving");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created");
    }
}