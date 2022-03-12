using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiCadastroCurso.Models;
using WebApiCadastroCurso.Repository;

namespace WebApiCadastroCurso.Controllers
{
    public class CourseController : ControllerBase
    {
        [HttpGet]
        [Route("/api/v1/user/users")]
        [Authorize]
        public async Task<IActionResult> Couser([FromBody] Course model)
        {
            var couse = CadastraUserCourseRepository.Get(model.Titulo, model.Duracao, model.Status);
            return Ok(couse);
        }

        
    }
    
}
