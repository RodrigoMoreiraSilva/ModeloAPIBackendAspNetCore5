using GestaoUnica_backend.Context;
using GestaoUnica_backend.Data.Repository.Interfaces;
using GestaoUnica_backend.Models;
using System.Linq;

namespace GestaoUnica_backend.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLContext _context;

        public UserRepository(SQLContext context)
        {
            _context = context;
        }

        public User FindByUsername(string username)
        {
            return _context.Usuarios.SingleOrDefault(x => x.Username == username);
        }
    }
}
