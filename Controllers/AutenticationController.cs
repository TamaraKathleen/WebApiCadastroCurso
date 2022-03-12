using System;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using WebApiCadastroCurso.Settings;

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

        [HttpGet]
        public IActionResult ObterToken()
        {
            var token = GerarToken();

            var retorno = new
            {
                Token = token
            };

            return Ok(retorno);
        }

        public static string GerarToken()
        {

            var handler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ConfigurationJwt.Segredo)),SecurityAlgorithms.HmacSha256Signature),
                Audience = "https://localhost:5001",
                Issuer = "WebApiCadastroCurso",
            };

            SecurityToken token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }

   
}
