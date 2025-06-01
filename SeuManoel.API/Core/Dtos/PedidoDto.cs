using System.Text.Json.Serialization;

namespace SeuManoel.API.Core.Dtos;

public class PedidoDto
{
    public PedidoDto(List<ProdutoDto> produtos)
    {
        Produtos = produtos;
    }

    [JsonPropertyName("pedido_id")]
    public int PedidoId { get; set; }
    
    public List<ProdutoDto> Produtos { get; set; }
}
