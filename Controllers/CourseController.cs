
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCadastroCurso.Data;
using WebApiCadastroCurso.Models;


namespace WebApiCadastroCurso.Controllers
{
    public class CourseController : ControllerBase
    {
       
        private readonly ApplicationContext _context;

        public CourseController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/api/v1/user/courses")]
        [AllowAnonymous]
            
        public async Task<IActionResult> Index()
        {
            var course = await _context.Courses.ToListAsync();
            return Ok(course);
        }

        [HttpGet]
        [Route("/api/v1/user/status")]
        [AllowAnonymous]

        public async Task<IActionResult> PorStatus(Status? status)
        {
            
            var course = await _context.Courses.ToListAsync();


            return Ok(course);
        }

        [HttpPost]
        [Authorize]
        [Route("/api/v1/user/cadastrar")]
        public async Task<ActionResult<Course>> PostEmployee(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }


        [HttpPost]
        [Authorize(Roles = "Gerente, Secretaria")]
        [Route("/api/v1/user/atualizar")]
        public async Task<IActionResult> Edit(int id, Course course)
        {

            if (id != course.Id)
            {
                return NotFound();
            }

            _context.Entry(course).State = EntityState.Modified;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }

           
            return NoContent();


        }

        [HttpDelete]
        [Authorize(Roles = "Gerente")]
        [Route("/api/v1/user/deletar")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deletar = await _context.Courses.FindAsync(id);
            if (deletar == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(deletar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

    }
    
}