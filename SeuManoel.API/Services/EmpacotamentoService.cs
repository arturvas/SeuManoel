using SeuManoel.API.Core.Dtos;
using SeuManoel.API.Core.Models;

namespace SeuManoel.API.Services;

public class EmpacotamentoService
{
    public List<RespostaPedidoDto> Empacotar(List<PedidoDto>? pedidos)
    {
        var listaFinalRespostas = new List<RespostaPedidoDto>();

        if (pedidos == null)
        {
            return listaFinalRespostas;
        }

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
                var alturaProduto = produto.Dimensoes.Altura;
                var larguraProduto = produto.Dimensoes.Largura;
                var comprimentoProduto = produto.Dimensoes.Comprimento;
                var caixasPossiveis = new List<CaixaDisponivel>();

                foreach (var caixa in caixasDisponiveis)
                {
                    if (alturaProduto <= caixa.Altura &&
                        larguraProduto <= caixa.Largura &&
                        comprimentoProduto <= caixa.Comprimento)
                    {
                        caixasPossiveis.Add(caixa);
                    }
                }

                if (caixasPossiveis.Count == 0)
                {
                    var caixaNaoDisponivel = new RespostaCaixaDto
                    {
                        CaixaId = null,
                        Produtos = new List<string> { produto.ProdutoId },
                        Observacao = "Produto não cabe em nenhuma caixa disponível."
                    };
                    caixasDoPedido.Add(caixaNaoDisponivel);
                }
                else
                {
                    var menorCaixa = caixasPossiveis
                        .OrderBy(caixa => caixa.Altura * caixa.Largura * caixa.Comprimento)
                        .First();

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

            var respostaPedido = new RespostaPedidoDto
            {
                PedidoId = pedido.PedidoId,
                Caixas = caixasDoPedido
            };
            listaFinalRespostas.Add(respostaPedido);
        }

        return listaFinalRespostas;
    }
}
