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

            if (retornoSalas.Status)
                return Ok(retornoSalas);
            else
                return NotFound(retornoSalas);
        }

        [HttpGet("sala/{id}")]
        public async Task<IActionResult> BuscarSala(int id)
        {
            var retornoSala = await _salaServices.GetSalaById(id);

            if (retornoSala.Status)
                return Ok(retornoSala);
            else
                return NotFound(retornoSala);
        }


        [HttpPost("adicionar")]
        public async Task<IActionResult> SalaAdicionar([FromBody] SalaInputModel sala)
        {
            if (sala == null) return BadRequest("Dados inválidos!");

            var retornoAdd = await _salaServices.PostSala(sala);

            if (retornoAdd.Status)
                return Ok(retornoAdd);
            else
                return BadRequest(retornoAdd);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> SalaAtualizar(int id, [FromBody] SalaInputModel sala)
        {
            if (id <= 0 || sala == null) return BadRequest("Objeto inválido!");

            var retornoUpdate = await _salaServices.PutSala(id, sala);

            if (retornoUpdate.Status)
                return Ok(retornoUpdate);
            else
                return NotFound(retornoUpdate);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> SalaEliminar(int id)
        {
            if (id <= 0) return BadRequest("Código inválido!");

            var retornoRemove = await _salaServices.DeleteSala(id);

            if (retornoRemove.Status)
                return Ok(retornoRemove);
            else
                return NotFound(retornoRemove);
        }


    }
}
