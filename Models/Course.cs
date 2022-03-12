
namespace WebApiCadastroCurso.Models
{
    public enum Status
    {
        Previsto, EmAndamento, Concluido
    }
    public class Course
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public Status? Status { get; set; }
        
    }
}
