using System.Collections.Generic;
using System.Linq;
using WebApiCadastroCurso.Models;

namespace WebApiCadastroCurso.Repository
{
    public class CadastraUserCourseRepository
    {
        public static User Get(string name, string email, string password, Role? role )
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Name = "Tamara", Email = "tamara@tamara.com", Password = "tamara123", Role = Role.Gerente });
            users.Add(new User { Id = 2, Name = "Maria", Email = "maria@maria.com", Password = "maria123", Role = Role.Secretaria });
            users.Add(new User { Id = 3, Name = "Paulo", Email = "paulo@paulo.com", Password = "paulo123", Role = Role.Usuario });
            return users.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();

        }

        public static Course Get(string titulo, int duracao, Status? status)
        {
            var courses = new List<Course>();
            courses.Add(new Course { Id = 1, Titulo = "ASP.NET Básico", Duracao = 1, Status = Status.EmAndamento });
            courses.Add(new Course { Id = 2, Titulo = "Java Básico", Duracao = 1, Status = Status.Previsto });
            courses.Add(new Course { Id = 3, Titulo = "Python Básico", Duracao = 1, Status = Status.Concluido });
            return courses.Where(x => x.Titulo.ToLower() == titulo.ToLower()).FirstOrDefault();

        }
    };
}
