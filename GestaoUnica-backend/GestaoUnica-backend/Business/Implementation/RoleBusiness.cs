using GestaoUnica_backend.Business.Interfaces;
using GestaoUnica_backend.Models;
using GestaoUnica_backend.Repository.Generic;
using System.Collections.Generic;

namespace GestaoUnica_backend.Business.Implementation
{
    public class RoleBusiness : IRoleBusiness
    {
        private readonly IRepository<Role> _repository;

        public RoleBusiness(IRepository<Role> repository)
        {
            _repository = repository;
        }
        public Role Create(Role role)
        {
            return _repository.Create(role);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }

        public List<Role> FindAll()
        {
            return _repository.FindAll();
        }

        public Role FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public Role Update(Role role)
        {
            return _repository.Update(role);
        }
    }
}
