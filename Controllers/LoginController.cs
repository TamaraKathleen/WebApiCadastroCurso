
using Microsoft.AspNetCore.Mvc;
using WebApiCadastroCurso.DTOs;
using WebApiCadastroCurso.Models;
using WebApiCadastroCurso.Services;


namespace WebApiCadastroCurso.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        public object TokenService { get; private set; }

        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Authenticate([FromBody] CadastrarUserDTO model)
        {
            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password

            };

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenServices.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }

}
