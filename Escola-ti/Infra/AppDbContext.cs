using Escola_ti.Domain;
using Microsoft.EntityFrameworkCore;

namespace Escola_ti.Infra
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Acessorio> Acessorios { get; set; }
    }
}
