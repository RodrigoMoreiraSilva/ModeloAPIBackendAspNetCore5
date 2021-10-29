using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoUnica_backend.Context;
using GestaoUnica_backend.Models;
using GestaoUnica_backend.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace GestaoUnica_backend.Controllers
{
    [Authorize(Roles ="Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly SQLContext _context;
        private readonly IRoleBusiness _roleBusiness;

        public RolesController(SQLContext context, IRoleBusiness roleBusiness)
        {
            _context = context;
            _roleBusiness = roleBusiness;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRegras()
        {
            return _roleBusiness.FindAll();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = _roleBusiness.FindByID(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Role>> PutRole(int id, [FromBody] Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }
            try
            {
                return _roleBusiness.Update(role);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }    
        }

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            return _roleBusiness.Create(role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = _roleBusiness.FindByID(id);
            if (role == null)
            {
                return NotFound();
            }

            _roleBusiness.Delete(id);

            return NoContent();
        }

        private bool RoleExists(int id)
        {
            return _roleBusiness.Exists(id);
        }
    }
}
