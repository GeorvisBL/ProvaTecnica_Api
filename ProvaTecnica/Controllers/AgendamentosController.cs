using Microsoft.AspNetCore.Mvc;
using ProvaTecnica.Models.InputModel;
using ProvaTecnica.Services.Interfaces;

namespace ProvaTecnica.Controllers
{
    [Route("api/v1/agendamentos")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {

        private readonly IAgendamentoServices _agendamentoServices;
        public AgendamentosController(IAgendamentoServices agendamentoServices)
        {
            _agendamentoServices = agendamentoServices;
        }


        [HttpGet("listaAgendamentos")]
        public async Task<IActionResult> BuscarAgendamentos()
        {
            var retornoAgendamentos = await _agendamentoServices.GetListaAgendamentos();

            return Ok(retornoAgendamentos);
        }

        [HttpGet("agendamento/{id}")]
        public async Task<IActionResult> BuscarAgendamento(int id)
        {
            var retornoAgendamento = await _agendamentoServices.GetAgendamentoById(id);

            return Ok(retornoAgendamento);
        }


        [HttpPost("adicionar")]
        public async Task<IActionResult> AgendamentoAdicionar([FromBody] AgendamentoInputModel agendamento)
        {
            if (agendamento == null) return BadRequest("Dados inválidos!");

            var retornoAdd = await _agendamentoServices.PostAgendamento(agendamento);

            return Ok(retornoAdd);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> AgendamentoAtualizar(int id, [FromBody] AgendamentoInputModel agendamento)
        {
            if (id <= 0 || agendamento == null) return BadRequest("Objeto inválido!");

            var retornoUpdate = await _agendamentoServices.PutAgendamento(id, agendamento);

            return Ok(retornoUpdate);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> AgendamentoEliminar(int id)
        {
            if (id <= 0) return BadRequest("Código inválido!");

            var retornoRemove = await _agendamentoServices.DeleteAgendamento(id);

            return Ok(retornoRemove);
        }

    }
}
