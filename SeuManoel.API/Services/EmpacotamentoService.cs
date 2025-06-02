using SeuManoel.API.Core.Dtos;
using SeuManoel.API.Core.Models;
using SeuManoel.API.Services.Helpers;

namespace SeuManoel.API.Services;

public class EmpacotamentoService
{
    public List<RespostaPedidoDto> Empacotar(List<PedidoDto>? pedidos)
    {
        var listaFinalRespostas = new List<RespostaPedidoDto>();
        if (pedidos == null) return listaFinalRespostas;

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

                // … dentro do foreach(produto) …
                bool encaixado = false;

                // 2) tenta da última caixa aberta para a primeira
                for (int i = caixasDoPedido.Count - 1; i >= 0; i--)
                {
                    var rc = caixasDoPedido[i];
                    if (rc.CaixaId == null) continue;
                    var def = caixasDisponiveis.First(c => c.CaixaId == rc.CaixaId);
                    if (EmpacotamentoHelper.CabeNaCaixa(alturaProduto, larguraProduto, comprimentoProduto, def))
                    {
                        rc.Produtos.Add(produto.ProdutoId);
                        encaixado = true;
                        break;
                    }
                }
                if (encaixado) continue;

                // 3) se não coube em nenhuma aberta, escolhe nova menor que o comporte
                var possiveis = caixasDisponiveis
                .Where(c => EmpacotamentoHelper.CabeNaCaixa(alturaProduto, larguraProduto, comprimentoProduto, c))
                    .OrderBy(c => c.Altura * c.Largura * c.Comprimento)
                    .ToList();
                if (!possiveis.Any())
                {
                    caixasDoPedido.Add(new RespostaCaixaDto
                    {
                        CaixaId = null,
                        Produtos = new List<string> { produto.ProdutoId },
                        Observacao = "Produto não cabe em nenhuma caixa disponível."
                    });
                }
                else
                {
                    var menor = possiveis.First();
                    caixasDoPedido.Add(new RespostaCaixaDto
                    {
                        CaixaId = menor.CaixaId,
                        Produtos = new List<string> { produto.ProdutoId }
                    });
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