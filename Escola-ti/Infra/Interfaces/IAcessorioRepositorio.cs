using Escola_ti.Domain;

namespace Escola_ti.Infra.Interfaces
{
    public interface IAcessorioRepositorio
    {
        public Task<Acessorio> AddAcessorio(Acessorio Acessorio, CancellationToken token = default);
        public Task<Acessorio> Update(Acessorio Acessorio, CancellationToken token = default);
        public Task Delete(Acessorio Acessorio, CancellationToken token = default);
        public Task<List<Acessorio>> Listar(CancellationToken token = default);

        public Task<Acessorio?> FindById(Guid id, CancellationToken token = default);
    }
}
