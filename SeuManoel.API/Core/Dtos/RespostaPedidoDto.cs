using System.Text.Json.Serialization;

namespace SeuManoel.API.Core.Dtos;

public class RespostaPedidoDto
{
    [JsonPropertyName("pedido_id")]
    public int PedidoId { get; set; }
    
    public List<RespostaCaixaDto> Caixas { get; set; } = [];
}
