using WebApiTodoBRQ.Models;
using WebApiTodoBRQ.DataContext;
using Microsoft.EntityFrameworkCore;

namespace WebApiTodoBRQ.Service.TarefaService
{
    public class TarefaService : ITarefaInterface
    {
        private readonly ApplicationDbContext _context;

        public TarefaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<TarefaModel>>> CreateTarefas(TarefaModel novaTarefa)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                if (novaTarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novaTarefa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Tarefas.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefaModel>>> GetTarefas()
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                serviceResponse.Dados = await _context.Tarefas.ToListAsync();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<TarefaModel>> GetTarefasById(int id)
        {
            ServiceResponse<TarefaModel> serviceResponse = new ServiceResponse<TarefaModel>();

            try
            {
                var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

                if (tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Tarefa não localizada.";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Dados = tarefa;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefaModel>>> UpdateTarefas(TarefaModel editadaTarefa)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                var tarefa = await _context.Tarefas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == editadaTarefa.Id);

                if (tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Tarefa não localizada.";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    tarefa.DataDeAlteracao = DateTime.Now.ToLocalTime();

                    _context.Tarefas.Update(editadaTarefa);
                    await _context.SaveChangesAsync();
                }

                serviceResponse.Dados = await _context.Tarefas.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefaModel>>> DeleteTarefas(int id)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                var funcionario = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Tarefa não localizada.";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    _context.Tarefas.Remove(funcionario);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Tarefas.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
