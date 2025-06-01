namespace SeuManoel.API.Core.Models;

public class CaixaDisponivel
{
    public string CaixaId { get; set; }
    public int Altura { get; set; }
    public int Largura { get; set; }
    public int Comprimento { get; set; }

    public CaixaDisponivel(string caixaId, int altura, int largura, int comprimento)
    {
        CaixaId = caixaId;
        Altura = altura;
        Largura = largura;
        Comprimento = comprimento;
    }
}
