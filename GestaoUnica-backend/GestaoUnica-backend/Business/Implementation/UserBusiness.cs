using GestaoUnica_backend.Business.Interfaces;
using GestaoUnica_backend.Data.Repository.Interfaces;
using GestaoUnica_backend.Models;
using GestaoUnica_backend.Repository.Generic;
using System.Collections.Generic;

namespace GestaoUnica_backend.Business.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IRepository<User> _repository;
        private readonly IUserRepository _userRepository;

        public UserBusiness(IRepository<User> repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public User Create(User user)
        {
            return _repository.Create(user);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }

        public List<User> FindAll()
        {
            return _repository.FindAll();
        }

        public User FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public User FindByUsername(string username)
        {
            return _userRepository.FindByUsername(username);
        }

        public User Update(User user)
        {
            return _repository.Update(user);
        }
    }
}
