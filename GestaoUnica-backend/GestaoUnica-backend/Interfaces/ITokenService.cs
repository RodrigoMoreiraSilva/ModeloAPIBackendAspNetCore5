using GestaoUnica_backend.Models;

namespace GestaoUnica_backend.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        string RefreshToken(string token);
    }
}
