using System;
namespace WebApiCadastroCurso.DTOs
{

    public enum Status
    {
        Previsto, EmAndamento, Concluido
    }

    public class CadastrarCourseDTO
    {
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public Status? Status { get; set; }
    }
}
