using Localizard.Domain.Enums;
using Localizard.Domain.ViewModel;

namespace Localizard.DAL.Repositories;

public interface ILanguageRepo
{
    Task<IEnumerable<LanguageEnum>> GetAll();
    Task<LanguageEnum> GetById(int id);
}