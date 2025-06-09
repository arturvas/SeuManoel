using SeuManoel.API.Services;
using SeuManoel.API.Core.Dtos;

namespace Service.Tests;

public class EmpacotamentoServiceTests
{
    [Fact]
    public void Empacotar_DeveRetornarCaixa1_QuandoProdutoPequeno()
    {
        // Arrange - prepara os dados
        var service = new EmpacotamentoService(); // Cria o serviço que vamos testar

        var pedidos = new List<PedidoDto>
        {
            new PedidoDto
            {
                PedidoId = 1,
                Produtos = new List<ProdutoDto>
                {
                    new ProdutoDto
                    {
                        ProdutoId = "PS5",
                        Dimensoes = new DimensaoDto
                        {
                            Altura = 10,
                            Largura = 20,
                            Comprimento = 30
                        }
                    }
                }
            }
        };
        // Act - chama o método que queremos testar
        var resposta = service.Empacotar(pedidos);

        // Assert - confere se a respossta está como esperamos
        Assert.Single(resposta); // Só deve haver UM pedido de resposta
        var pedidoResposta = resposta.First();
        Assert.Equal(1, pedidoResposta.PedidoId); // Confere se o pedido_id bate
        
        // Confere se só tem UMA caixa nesse pedido
        Assert.Single(pedidoResposta.Caixas);
        var caixa = pedidoResposta.Caixas.First();
        
        // Espera que a caixa seja a Caixa 1
        Assert.Equal("Caixa 1", caixa.CaixaId);
        
        // Confere se o produto está lá dentro
        Assert.Contains("PS5", caixa.Produtos);
    }

    [Fact]
    public void Empacotar_DeveAlojarProdutosJuntos_QuandoPossivel()
    {
        // Arrange
        var service = new EmpacotamentoService();

        var pedidos = new List<PedidoDto>
        {
            new PedidoDto
            {
                PedidoId = 4,
                Produtos = new List<ProdutoDto>
                {
                    new ProdutoDto
                    {
                        ProdutoId = "Mouse Gamer",
                        Dimensoes = new DimensaoDto
                        {
                            Altura = 5,
                            Largura = 5,
                            Comprimento = 5
                        }
                    },
                    new ProdutoDto
                    {
                        ProdutoId = "Teclado Mecânico",
                        Dimensoes = new DimensaoDto
                        {
                            Altura = 10,
                            Largura = 10,
                            Comprimento = 10
                        }
                    }
                }
            }
        };
        
        // Act
        var resposta = service.Empacotar(pedidos);
        
        // Assert
        var pedidoResposta = resposta.First();
        
        // Espera que só haja 1 caixa no pedido, e que tenha os 2 produtos juntos
        Assert.Single(pedidoResposta.Caixas);
        var caixa = pedidoResposta.Caixas.First();
        Assert.Contains("Mouse Gamer", caixa.Produtos);
        Assert.Contains("Teclado Mecânico", caixa.Produtos);
    }

    [Fact]
    public void Empacotar_DeveAgruparProdutosEmCaixasCorretas_Pedido6()
    {
        // Arrange
        var service = new EmpacotamentoService();

        var pedidos = new List<PedidoDto>
        {
            new PedidoDto
            {
                PedidoId = 6,
                Produtos = new List<ProdutoDto>
                {
                    new ProdutoDto
                    {
                        ProdutoId = "Notebook",
                        Dimensoes = new DimensaoDto
                        {
                            Altura = 10,
                            Largura = 30,
                            Comprimento = 40
                        }
                    },
                    new ProdutoDto
                    {
                        ProdutoId = "Monitor",
                        Dimensoes = new DimensaoDto
                        {
                            Altura = 20,
                            Largura = 30,
                            Comprimento = 50
                        }
                    },
                    new ProdutoDto
                    {
                        ProdutoId = "Webcam",
                        Dimensoes = new DimensaoDto
                        {
                            Altura = 5,
                            Largura = 5,
                            Comprimento = 5
                        }
                    },
                    new ProdutoDto
                    {
                        ProdutoId = "Microfone",
                        Dimensoes = new DimensaoDto
                        {
                            Altura = 5,
                            Largura = 5,
                            Comprimento = 5
                        }
                    }
                }
            }
        };
        
        // Act
        var resposta = service.Empacotar(pedidos);
        
        // Assert
        var pedidoReposta = resposta.First(p => p.PedidoId == 6);
        
        // Espera que o pedido tenha 2 caixas
        Assert.Equal(2, pedidoReposta.Caixas.Count);
        
        // Verifica quais produtos estão em quais caixas
        var caixa1 = pedidoReposta.Caixas.First(c => c.CaixaId == "Caixa 1");
        Assert.Contains("Notebook", caixa1.Produtos);
        Assert.Contains("Microfone", caixa1.Produtos);
        
        var caixa3 = pedidoReposta.Caixas.First(c => c.CaixaId == "Caixa 3");
        Assert.Contains("Notebook", caixa3.Produtos);
        Assert.Contains("Monitor", caixa3.Produtos);
    }
}
