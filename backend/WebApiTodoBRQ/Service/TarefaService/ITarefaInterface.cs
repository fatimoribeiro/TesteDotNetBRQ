using WebApiTodoBRQ.Models;

namespace WebApiTodoBRQ.Service.TarefaService
{
    public interface ITarefaInterface
    {
        Task<ServiceResponse<List<TarefaModel>>> GetTarefas();
        Task<ServiceResponse<List<TarefaModel>>> CreateTarefas(TarefaModel novaTarefa);
        Task<ServiceResponse<TarefaModel>> GetTarefasById(int id);
        Task<ServiceResponse<List<TarefaModel>>> UpdateTarefas(TarefaModel editadaTarefa);
        Task<ServiceResponse<List<TarefaModel>>> DeleteTarefas(int id);
    }
}
