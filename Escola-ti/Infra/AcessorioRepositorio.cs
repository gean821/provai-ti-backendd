using Escola_ti.Domain;
using Escola_ti.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Escola_ti.Infra
{
    public class AcessorioRepositorio : IAcessorioRepositorio
    {

        private readonly AppDbContext _db;

        public AcessorioRepositorio(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Acessorio> AddAcessorio(
             Acessorio Acessorio,
             CancellationToken token = default
             )
        {
            await _db.Acessorios.AddAsync(Acessorio, token);
            await SaveChangesAsync(token);
            return Acessorio;
        }
        public async Task Delete(
            Acessorio Acessorio,
            CancellationToken token = default)
        {
            _db.Acessorios.Remove(Acessorio);
            await SaveChangesAsync(token);
        }

        public async Task<List<Acessorio>> Listar(CancellationToken token = default)
        {
            var Acessorios = await _db.Acessorios
                .ToListAsync(token);

            return Acessorios;
        }

        public async Task<Acessorio?> FindById(Guid id, CancellationToken token = default)
        {
            return await _db.Acessorios.FirstOrDefaultAsync(x => x.Id == id, token);
        }
        public async Task SaveChangesAsync(CancellationToken token = default)
        {
            await _db.SaveChangesAsync(token);
        }

        public async Task<Acessorio> Update(
            Acessorio Acessorio,
            CancellationToken token = default)
        {
            _db.Acessorios.Update(Acessorio);
            await SaveChangesAsync(token);
            return Acessorio;
        }
    }
}
