using Microsoft.AspNetCore.Mvc;
using WebApiCadastroCurso.Models;
using WebApiCadastroCurso.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;

namespace WebApiCadastroCurso.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {

        public object TokenService { get; private set; }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/v1/auth")]
        public async Task<IActionResult> Auth([FromBody] User model)
        {
            try
            {

                var userExists = CadastraUserCourseRepository.Get(model.Name, model.Email, model.Password, model.Role);

                if (userExists == null)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });


                if (userExists.Password != model.Password)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });


                var token = AutenticationController.GerarToken();

                return Ok(new
                {
                    Token = token,
                    Usuario = userExists
                });

            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
        }
    }

}