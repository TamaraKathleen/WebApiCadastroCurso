using System;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using WebApiCadastroCurso.Settings;
using System.Threading.Tasks;
using WebApiCadastroCurso.Models;
using WebApiCadastroCurso.Repository;
using Microsoft.AspNetCore.Authorization;

namespace WebApiCadastroCurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticationController : ControllerBase
    {
        public static ConfigurationJwt ConfigurationJwt;

        public AutenticationController(IOptions<ConfigurationJwt> opcoes)
        {
            ConfigurationJwt = opcoes.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Auth([FromBody] User model)
        {
            try
            {

                var userExists = CadastraUserCourseRepository.Get(model.Name, model.Email, model.Password, model.Role);

                if (userExists == null)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });


                if (userExists.Password != model.Password)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });


                var token = AutenticationController.GerarToken(userExists);

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




        public static string GerarToken(User user)
        {

            var handler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ConfigurationJwt.Segredo)),SecurityAlgorithms.HmacSha256Signature),
                Audience = "https://localhost:5001",
                Issuer = "WebApiCadastroCurso",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Name.ToString()),
                    new Claim(ClaimTypes.Role,user.Role.ToString())
                    
                }),
            };

            SecurityToken token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

    
    }

   
}
