using GestaoUnica_backend.Models;

namespace GestaoUnica_backend.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        User FindByUsername(string username);
    }
}
