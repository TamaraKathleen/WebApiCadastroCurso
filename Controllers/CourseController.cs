using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCadastroCurso.Data;
using WebApiCadastroCurso.Models;
using WebApiCadastroCurso.Repository;

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
           

            var course = await _context.Courses.FirstOrDefaultAsync(m => m.Status == status);
            

            return Ok(course);
        }

        [HttpPost]
        [Authorize(Roles = "Gerente, Secretaria")]
        [Route("/api/v1/user/atualizar")]
        public async Task<IActionResult> Edit(int id, [Bind("Titulo,Duracao,Status")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

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
                return RedirectToAction(nameof(Index));
            }
            return Ok(course);
        }

        [HttpDelete]
        [Authorize(Roles = "Gerente")]
        [Route("/api/v1/user/deletar")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

    }
    
}