using Microsoft.AspNetCore.Mvc;
using ProvaTecnica.Models.InputModel;
using ProvaTecnica.Services.Interfaces;

namespace ProvaTecnica.Controllers
{
    [Route("api/v1/salas")]
    [ApiController]
    public class SalasController : ControllerBase
    {


        private readonly ISalaServices _salaServices;
        public SalasController(ISalaServices salaServices)
        {
            _salaServices = salaServices;
        }



        [HttpGet("lista-salas")]
        public async Task<IActionResult> BuscarSalas()
        {
            var retornoSalas = await _salaServices.GetListaSalas();

            return Ok(retornoSalas);
        }

        [HttpGet("sala/{id}")]
        public async Task<IActionResult> BuscarSala(int id)
        {
            var retornoSala = await _salaServices.GetSalaById(id);

            return Ok(retornoSala);
        }


        [HttpPost("adicionar")]
        public async Task<IActionResult> SalaAdicionar([FromBody] SalaInputModel sala)
        {
            if (sala == null) return BadRequest("Dados inválidos!");

            var retornoAdd = await _salaServices.PostSala(sala);

            return Ok(retornoAdd);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> SalaAtualizar(int id, [FromBody] SalaInputModel sala)
        {
            if (id <= 0 || sala == null) return BadRequest("Objeto inválido!");

            var retornoUpdate = await _salaServices.PutSala(id, sala);

            return Ok(retornoUpdate);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> SalaEliminar(int id)
        {
            if (id <= 0) return BadRequest("Código inválido!");

            var retornoRemove = await _salaServices.DeleteSala(id);

            return Ok(retornoRemove);
        }


    }
}
