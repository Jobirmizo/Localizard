using Localizard.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Localizard.DAL.Repositories.Implementations;

public class ProjectRepo : IProjectRepo
{
    private readonly AppDbContext _context;
    
    public ProjectRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProjectInfo>> GetAllProjects()
    {
        return await _context.Projects.OrderBy(p => p.Id).ToListAsync();
    }

    public async Task<ProjectInfo> GetById(int id)
    {
        return await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
    }

    public bool ProjectExists(int id)
    {
        return _context.Users.Any(p => p.Id == id);
    }
}