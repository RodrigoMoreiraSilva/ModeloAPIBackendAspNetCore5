using GestaoUnica_backend.Business.Interfaces;
using GestaoUnica_backend.Interfaces;
using GestaoUnica_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestaoUnica_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IActiveDirectoryService _activeDirectoryService;
        private readonly IUserBusiness _userBusiness;

        public LoginController(ITokenService tokenService, IActiveDirectoryService activeDirectoryService, IUserBusiness userBusiness)
        {
            _tokenService = tokenService;
            _activeDirectoryService = activeDirectoryService;
            _userBusiness = userBusiness;
        }

        [HttpPost]
        [Route("token")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] User model)
        {

            var user = _userBusiness.FindByUsername(model.Username);

            if (user != null)
            {
                model.Id = user.Id;
                model.Role = user.Role;
                model.IsActive = user.IsActive;
            }
            else
            {
                return NotFound(new { message = "Usuário não encontrado"});
            }

            if (!model.IsActive)
                return Unauthorized(new { message = "Usuário inativo" });

            var authenticated = await _activeDirectoryService.IsADAuthenticated(model);

            if (!authenticated)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            var token = _tokenService.GenerateToken(model);

            model.Password = "";

            return Ok(new
            {
                user = model,
                token = token
            });
        }
        [HttpPost]
        [Route("refreshtoken")]
        [Authorize]
        public async Task<IActionResult> RefreshToken([FromBody]Token token)
        {
            var newToken = string.Empty;
            try
            {
                newToken = _tokenService.RefreshToken(token.tokenValue);

                return Ok(new
                {
                    newToken = newToken
                });
            }
            catch(Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
