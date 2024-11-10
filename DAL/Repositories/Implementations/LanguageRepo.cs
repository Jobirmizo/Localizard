using AutoMapper;
using Localizard.Domain.Enums;
using Localizard.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Localizard.DAL.Repositories.Implementations;

public class LanguageRepo : ILanguageRepo
{
    
    private readonly AppDbContext _context;
    private readonly LanguageEnum _languageEnum;
    public LanguageRepo(IMapper mapper, AppDbContext context, LanguageEnum languageEnum)
    {
        _context = context;
        _languageEnum = languageEnum;
    }
    public Task<IEnumerable<LanguageEnum>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<LanguageEnum> GetById(int id)
    {
        throw new NotImplementedException();
    }
}