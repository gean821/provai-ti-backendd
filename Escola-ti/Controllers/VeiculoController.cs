using Escola_ti.Application;
using Escola_ti.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Escola_ti.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoService _service;
        public VeiculoController(VeiculoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddVeiculo(
            [FromBody] Veiculo veiculo,
            CancellationToken token = default)
        {
            var veiculoCriado = await _service.AddVeiculo(veiculo, token);

            return CreatedAtAction(
                nameof(FindById),
                new { id = veiculoCriado.Id },
                veiculoCriado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(
            [FromRoute] Guid id,
            CancellationToken token = default)
        {
            var veiculo = await _service.FindById(id, token);
            return Ok(veiculo);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll(CancellationToken token = default)
        {
            var veiculos = await _service.Listar(token);
            return Ok(veiculos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] Veiculo veiculo,
            CancellationToken token = default
            )
        {
            var veiculoAtualizado = await _service.Update(id, veiculo, token);
            return Ok(veiculoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            CancellationToken token = default
            )
        {
            await _service.Delete(id, token);
            return NoContent();
        }
    }
}
