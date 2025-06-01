using System.Text.Json.Serialization;

namespace SeuManoel.API.Core.Dtos;

public class RespostaCaixaDto
{
    [JsonPropertyName("caixa_id")]
    public string? CaixaId { get; set; }
    
    public List<string> Produtos { get; set; } = [];
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Observacao { get; set; }
}
