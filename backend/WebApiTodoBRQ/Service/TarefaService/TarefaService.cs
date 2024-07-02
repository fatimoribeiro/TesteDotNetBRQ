using WebApiTodoBRQ.Models;

namespace WebApiTodoBRQ.Service.TarefaService
{
    public class TarefaService : ITarefaInterface
    {
        public Task<ServiceResponse<List<TarefaModel>>> CreateTarefas(TarefaModel novaTarefa)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<TarefaModel>>> DeleteTarefas(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<TarefaModel>>> GetTarefas()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<TarefaModel>> GetTarefasById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<TarefaModel>>> UpdateTarefas(TarefaModel editadaTarefa)
        {
            throw new NotImplementedException();
        }
    }
}
