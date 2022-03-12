﻿
namespace WebApiCadastroCurso.Models
{
    public enum Role
    {
        Gerente, Secretaria, Usuario
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role? Role { get; set; }
    }
}
