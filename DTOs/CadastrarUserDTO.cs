using System;
namespace WebApiCadastroCurso.DTOs
{
    public enum Role
    {
        Gerente, Secretaria, Usuario
    }

    public class CadastrarUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role? Role { get; set; }
    }
}
