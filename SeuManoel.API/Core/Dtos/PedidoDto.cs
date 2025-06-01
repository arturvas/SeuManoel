namespace SeuManoel.API.Core.Dtos;

public class PedidoDto
{
    public PedidoDto(List<ProdutoDto> produtos)
    {
        Produtos = produtos;
    }

    public int PedidoId { get; set; }
    public List<ProdutoDto> Produtos { get; set; }
}
