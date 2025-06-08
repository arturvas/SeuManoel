using SeuManoel.API.Core.Dtos;
using SeuManoel.API.Core.Models;

namespace SeuManoel.API.Services;

public class EmpacotamentoService
{
    private readonly CaixaSelector _caixaSelector = new CaixaSelector();
    
    public List<RespostaPedidoDto> Empacotar(List<PedidoDto>? pedidos)
    {
        var listaFinalRespostas = new List<RespostaPedidoDto>();

        if (pedidos == null)
            return listaFinalRespostas;

        var caixasDisponiveis = new List<CaixaDisponivel>
        {
            new CaixaDisponivel("Caixa 1", 30, 40, 80),
            new CaixaDisponivel("Caixa 2", 80, 50, 40),
            new CaixaDisponivel("Caixa 3", 50, 80, 60)
        };

        foreach (var pedido in pedidos)
        {
            var caixasDoPedido = new List<RespostaCaixaDto>();

            foreach (var produto in pedido.Produtos)
            {
                var menorCaixa = _caixaSelector.SelecionarCaixa(caixasDisponiveis, produto);

                if (menorCaixa == null)
                {
                    caixasDoPedido.Add(new RespostaCaixaDto
                    {
                        CaixaId = null,
                        Produtos = new List<string>{ produto.ProdutoId },
                        Observacao = "Produto não cabe em nenhuma caixa disponível."
                    });
                }
                else
                {
                    var respostaCaixa = caixasDoPedido
                        .FirstOrDefault(c => c.CaixaId == menorCaixa.CaixaId);

                    if (respostaCaixa == null)
                    {
                        respostaCaixa = new RespostaCaixaDto
                        {
                            CaixaId = menorCaixa.CaixaId,
                            Produtos = new List<string> { produto.ProdutoId }
                        };
                        caixasDoPedido.Add(respostaCaixa);
                    }
                    else
                    {
                        respostaCaixa.Produtos.Add(produto.ProdutoId);
                    }
                }
            }
            
            listaFinalRespostas.Add(new RespostaPedidoDto
            {
                PedidoId = pedido.PedidoId,
                Caixas = caixasDoPedido
            });
        }
        
        return listaFinalRespostas;
    }
}
