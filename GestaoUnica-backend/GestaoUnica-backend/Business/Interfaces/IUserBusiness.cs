using GestaoUnica_backend.Models;
using System.Collections.Generic;

namespace GestaoUnica_backend.Business.Interfaces
{
    public interface IUserBusiness
    {
        User Create(User user);
        User FindByID(int id);
        User FindByUsername(string username);
        List<User> FindAll();
        User Update(User user);
        void Delete(int id);
        bool Exists(int id);
    }
}
