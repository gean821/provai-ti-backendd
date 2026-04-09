namespace Escola_ti.Domain
{
    public class Veiculo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Modelo { get; set; }
        public required int AnoFabricacao { get; set; }
        public required string Placa { get; set; }
        public ICollection<Acessorio>? Acessorios { get; set; }

    }
}
