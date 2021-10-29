using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoUnica_backend.Models;
using GestaoUnica_backend.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace GestaoUnica_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        // GET: api/Users
        [Authorize(Roles ="Administrador")]
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
        public async Task<ActionResult<User>> FindByUsername([FromBody]User user)
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
        [Authorize(Roles ="Administrador")]
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> AlterUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                user.Password = "xxxx";
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles ="Administrador")]
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            user.Password = "xxxx";
            return _userBusiness.Create(user);
        }

        // DELETE: api/Users/5
        [Authorize(Roles ="Administrador")]
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
