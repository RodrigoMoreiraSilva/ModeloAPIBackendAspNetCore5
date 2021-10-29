using GestaoUnica_backend.Models;
using System.Collections.Generic;

namespace GestaoUnica_backend.Business.Interfaces
{
    public interface IRoleBusiness
    {
        Role Create(Role role);
        Role FindByID(int id);
        List<Role> FindAll();
        Role Update(Role role);
        void Delete(int id);
        bool Exists(int id);
    }
}
