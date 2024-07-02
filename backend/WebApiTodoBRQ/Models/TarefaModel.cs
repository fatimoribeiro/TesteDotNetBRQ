using WebApiTodoBRQ.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApiTodoBRQ.Models
{
    public class TarefaModel
    {
        [Key]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public TarefaStatusEnum Status { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
