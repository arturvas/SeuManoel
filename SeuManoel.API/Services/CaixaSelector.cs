using SeuManoel.API.Core.Dtos;
using SeuManoel.API.Core.Models;

namespace SeuManoel.API.Services;

public class CaixaSelector
{
    public CaixaDisponivel? SelecionarCaixa(List<CaixaDisponivel> caixasDisponiveis, ProdutoDto produto)
    {
        var caixasPossiveis = caixasDisponiveis
            .Where(caixa =>
                produto.Dimensoes.Altura <= caixa.Altura &&
                produto.Dimensoes.Largura <= caixa.Largura &&
                produto.Dimensoes.Comprimento <= caixa.Comprimento)
            .ToList();
        
        if (caixasPossiveis.Count == 0)
        {
            return null;
        }

        return caixasPossiveis
            .OrderBy(caixa => caixa.Altura * caixa.Largura * caixa.Comprimento)
            .First();
    }
}
