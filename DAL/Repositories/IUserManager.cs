using Localizard.Domain.Entites;

namespace Localizard.DAL.Repositories;

public interface IUserManager
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetByIdAsync(int id);
    bool UserExists(int id);
    bool Add(User user);
    bool Update(User user);
    bool Delete(User user);
    bool Save();

}