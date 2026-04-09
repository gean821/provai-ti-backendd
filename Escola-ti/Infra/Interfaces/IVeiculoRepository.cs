using Escola_ti.Domain;

namespace Escola_ti.Infra.Interfaces
{
    public interface IVeiculoRepository
    {
        public Task<Veiculo> AddVeiculo(Veiculo veiculo, CancellationToken token = default);
        public Task<Veiculo> Update(Veiculo veiculo, CancellationToken token = default);
        public Task Delete(Veiculo veiculo, CancellationToken token = default);
        public Task<List<Veiculo>> Listar(CancellationToken token = default);
        public Task<Veiculo?> FindById(Guid id, CancellationToken token = default);

        public Task SaveChangesAsync(CancellationToken token = default);
    }
}
