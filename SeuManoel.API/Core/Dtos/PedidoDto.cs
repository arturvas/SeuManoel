namespace SeuManoel.API.Core.Dtos;

public class PedidoDto(List<ProdutoDto> produtos)
{
    public int PedidoId { get; set; }
    public List<ProdutoDto> Produtos { get; set; } = produtos;
}
