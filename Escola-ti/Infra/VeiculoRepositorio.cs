using Escola_ti.Domain;
using Escola_ti.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Escola_ti.Infra
{
    public class VeiculoRepositorio : IVeiculoRepository
    {

        private readonly AppDbContext _db;

        public VeiculoRepositorio(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Veiculo> AddVeiculo(
            Veiculo veiculo,
            CancellationToken token = default
            )
        {
            await _db.Veiculos.AddAsync(veiculo, token);
            await SaveChangesAsync(token);
            return veiculo;
        }

        public async Task Delete(
            Veiculo veiculo,
            CancellationToken token = default)
        {
            _db.Veiculos.Remove(veiculo);
            await SaveChangesAsync(token);
        }

        public async Task<Veiculo?> FindById(Guid id, CancellationToken token = default)
        {
            return await _db.Veiculos.FirstOrDefaultAsync(x => x.Id == id, token);
        }
        public async Task<List<Veiculo>> Listar(CancellationToken token = default)
        {
            var veiculos = await _db.Veiculos
                .Include(x => x.Acessorios)
                .ToListAsync(token);

            return veiculos;
        }

        public async Task SaveChangesAsync(CancellationToken token = default)
        {
            await _db.SaveChangesAsync(token);
        }

        public async Task<Veiculo> Update(
            Veiculo veiculo,
            CancellationToken token = default)
        {
             _db.Veiculos.Update(veiculo);
            await SaveChangesAsync(token);
            return veiculo;
        }
    }
}
