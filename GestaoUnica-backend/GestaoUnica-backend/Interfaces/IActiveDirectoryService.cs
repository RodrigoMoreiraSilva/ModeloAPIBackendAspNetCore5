using GestaoUnica_backend.Models;
using System.Threading.Tasks;

namespace GestaoUnica_backend.Interfaces
{
    public interface IActiveDirectoryService
    {
        Task<bool> IsADAuthenticated(User user);
    }
}
