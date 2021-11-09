using GestaoUnica_backend.Context;
using GestaoUnica_backend.Data.Repository.Interfaces;
using GestaoUnica_backend.Services.Models;
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

        public bool ChangePassword(int userId, string password)
        {
            try
            {
                var user = new User() {Id = userId, Password = password };

                _context.Usuarios.Attach(user);
                _context.Entry(user).Property(x => x.Password).IsModified = true;
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public User FindByUsername(string username)
        {
            return _context.Usuarios.SingleOrDefault(x => x.Username == username);
        }
    }
}
