using SeuManoel.API.Core.Models;

namespace SeuManoel.API.Services.Helpers
{
    public static class EmpacotamentoHelper
    {
        public static bool CabeNaCaixa(
            int altura, int largura, int comprimento,
            CaixaDisponivel caixa)
        {
            var produto = new[] { altura, largura, comprimento };
            var caixaDims = new[] { caixa.Altura, caixa.Largura, caixa.Comprimento };

            var permutacoes = new[]
            {
                new[] { produto[0], produto[1], produto[2] },
                new[] { produto[0], produto[2], produto[1] },
                new[] { produto[1], produto[0], produto[2] },
                new[] { produto[1], produto[2], produto[0] },
                new[] { produto[2], produto[0], produto[1] },
                new[] { produto[2], produto[1], produto[0] },
            };

            foreach (var p in permutacoes)
            {
                if (p[0] <= caixaDims[0] &&
                    p[1] <= caixaDims[1] &&
                    p[2] <= caixaDims[2])
                {
                    return true;
                }
            }

            return false;
        }
    }
}