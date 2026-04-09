using Escola_ti.Application;
using Escola_ti.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Escola_ti.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcessorioController: ControllerBase
    {
        private readonly AcessorioService _service;
        public AcessorioController(AcessorioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddAcessorio(
            [FromBody] Acessorio acessorio,
            CancellationToken token = default)
        {
            var acessorioCriado = await _service.AddAcessorio(acessorio, token);

            return CreatedAtAction(nameof(FindById), new { id = acessorioCriado.Id }, acessorioCriado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(
            [FromRoute] Guid id,
            CancellationToken token = default)
        {
            var acessorio = await _service.FindById(id, token);
            return Ok(acessorio);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll(CancellationToken token = default)
        {
            var acessorios = await _service.Listar(token);
            return Ok(acessorios);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] Acessorio acessorio,
            CancellationToken token = default
            )
        {
            var acessorioAtualizado = await _service.Update(id, acessorio, token);
            return Ok(acessorioAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            CancellationToken token = default)
        {
            await _service.Delete(id, token);
            return NoContent();
        } 
    }
}
