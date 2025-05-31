using SeuManoel.API.Core.Dtos;

namespace SeuManoel.API.Services;

public class EmpacotamentoService
{
    public static List<RespostaPedidoDto> Empacotar(List<PedidoDto> pedidos)
    {
        foreach (var pedido in pedidos)
        {
            var caixasDoPedido = new List<RespostaCaixaDto>();

            foreach (var produto in pedido.Produtos)
            {
                var alturaProduto = produto.Dimensoes.Altura;
                var larguraProduto = produto.Dimensoes.Largura;
                var comprimentoProduto = produto.Dimensoes.Comprimento;
                
                var caixasPossiveis = new List<RespostaCaixaDto>();
            }
        }
    }
}
