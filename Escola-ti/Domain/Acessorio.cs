using System.Text.Json.Serialization;

namespace Escola_ti.Domain
{
    public class Acessorio
    {
        public required Guid Id { get; set; } = Guid.NewGuid();
        public required string Nome { get; set; }

        public required Guid VeiculoId { get; set; }
        [JsonIgnore]
        public Veiculo? Veiculo { get; set; }
    }
}
