using Escola_ti.Domain;
using Escola_ti.Infra.Interfaces;

namespace Escola_ti.Application
{
    public class AcessorioService
    {
        private readonly IAcessorioRepositorio _repo;

        public AcessorioService(IAcessorioRepositorio repo)
        {
            _repo = repo;
        }

        public async Task<Acessorio> AddAcessorio(
            Acessorio acessorio,
            CancellationToken token = default
            )
        {
            return await _repo.AddAcessorio(acessorio, token);
        }
        public async Task<Acessorio> Update(
            Guid id,
            Acessorio acessorio,
            CancellationToken token = default
            )
        {
            var existing = await _repo.FindById(id, token)
                ?? throw new Exception("Acessorio não encontrado.");

            existing.Nome = acessorio.Nome;
             
            return existing;
        }
        public async Task Delete(
            Acessorio acessorio,
            CancellationToken token = default)
        {
            var existing = await _repo.FindById(acessorio.Id, token)
               ?? throw new Exception("Acessorio não encontrado.");

            await _repo.Delete(existing, token);
        }
        public async Task<List<Acessorio>> Listar(CancellationToken token = default)
        {
            return await _repo.Listar(token);
        }
        
        public async Task<Acessorio?> FindById (
            Guid id,
            CancellationToken token = default)
        {
            var acessorio = await _repo.FindById(id, token)
                ?? throw new Exception("Acessório não encontrado.");

            return acessorio;
        }
    }
}
