using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoUnica_backend.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using GestaoUnica_backend.Services.Models;
using GestaoUnica_backend.Services.Interfaces;

namespace GestaoUnica_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IPasswordHasher _passwordHasher;

        public UsersController(IUserBusiness userBusiness, IPasswordHasher passwordHasher)
        {
            _userBusiness = userBusiness;
            _passwordHasher = passwordHasher;
        }

        // GET: api/Users
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> FindAll()
        {
            //return await _context.Usuarios.ToListAsync();
            return _userBusiness.FindAll();
        }

        // GET: api/Users/5
        [Authorize(Roles = "Administrador,Funcionario,Cliente")]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> FindByID(int id)
        {
            var user = _userBusiness.FindByID(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users/FindByUserName
        [Authorize(Roles = "Administrador,Funcionario,Cliente")]
        [HttpPost]
        public async Task<ActionResult<User>> FindByUsername([FromBody] User user)
        {
            var foundUser = _userBusiness.FindByUsername(user.Username);

            if (foundUser == null)
            {
                return NotFound();
            }

            return foundUser;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> AlterUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            try
            {
                if (!string.IsNullOrEmpty(user.Password))
                    user.Password = _passwordHasher.Hash(user.Password);

                return _userBusiness.Update(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<ActionResult> ChangePassword(int id, [FromBody] User user)
        {
            var hash = _passwordHasher.Hash(user.Password);

            try
            {
                _userBusiness.ChangePassword(id, hash);

                return Ok(new { message = "Senha alterada com sucesso"});
            }
            catch
            {
                return BadRequest(new { message = "Ocorreu um erro ao tentar alterar a senha" });
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (!string.IsNullOrEmpty(user.Password))
                user.Password = _passwordHasher.Hash(user.Password);

            return _userBusiness.Create(user);
        }

        // DELETE: api/Users/5
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = _userBusiness.FindByID(id);
            if (user == null)
            {
                return NotFound();
            }

            _userBusiness.Delete(id);

            return NoContent();
        }

        [Authorize]
        private bool UserExists(int id)
        {
            return _userBusiness.Exists(id);
        }
    }
}
