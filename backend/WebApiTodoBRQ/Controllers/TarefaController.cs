using Microsoft.AspNetCore.Mvc;
using WebApiTodoBRQ.Models;
using WebApiTodoBRQ.Service.TarefaService;

namespace WebApiTodoBRQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaInterface _tarefaInterface;

        public TarefaController(ITarefaInterface tarefaInterface)
        {
            _tarefaInterface = tarefaInterface;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<TarefaModel>>>> CreateTarefas(TarefaModel novaTarefa)
        {
            return Ok(await _tarefaInterface.CreateTarefas(novaTarefa));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TarefaModel>>>> GetTarefas()
        {
            return Ok(await _tarefaInterface.GetTarefas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<TarefaModel>>> GetTarefasById(int id)
        {
            ServiceResponse<TarefaModel> serviceResponse = await _tarefaInterface.GetTarefasById(id);
            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TarefaModel>>> UpdateTarefas(TarefaModel editadaTarefa)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = await _tarefaInterface.UpdateTarefas(editadaTarefa);
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<TarefaModel>>>> DeleteTarefas(int id)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = await _tarefaInterface.DeleteTarefas(id);
            return Ok(serviceResponse);
        }

    }
}
