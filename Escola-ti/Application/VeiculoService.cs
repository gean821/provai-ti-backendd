using Escola_ti.Domain;
using Escola_ti.Infra.Interfaces;

namespace Escola_ti.Application
{
    public class VeiculoService
    {
        private readonly IVeiculoRepository _repo;

        public VeiculoService(IVeiculoRepository repo)
        {
            _repo = repo;
        }
        public async Task<Veiculo> AddVeiculo(
            Veiculo veiculo,
            CancellationToken token = default
            )
        {
            return await _repo.AddVeiculo(veiculo, token);
        }
        public async Task<Veiculo> Update(
            Guid id,
            Veiculo veiculo,
            CancellationToken token = default
            )
        {
            var existing = await _repo.FindById(id, token)
                ?? throw new Exception("Veiculo não encontrado.");

            existing.AnoFabricacao = veiculo.AnoFabricacao;
            existing.Placa = veiculo.Placa;
            existing.Modelo = veiculo.Modelo;

            await _repo.Update(existing, token);
            return existing;
        }
        public async Task Delete(
            Guid id,
            CancellationToken token = default)
        {
            var existing = await _repo.FindById(id, token)
               ?? throw new Exception("Veiculo não encontrado.");

            await _repo.Delete(existing, token);
        }
        public async Task<List<Veiculo>> Listar(CancellationToken token = default)
        {
            return await _repo.Listar(token);
        }
        
        public async Task<Veiculo?> FindById(Guid id, CancellationToken token = default)
        {
            var veiculo = await _repo.FindById(id, token)
                ?? throw new Exception("Veiculo não encontrado.");

            return veiculo;
        }
    }
}
