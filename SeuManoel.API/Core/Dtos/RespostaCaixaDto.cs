namespace SeuManoel.API.Core.Dtos;

public class RespostaCaixaDto(string caixaId, List<string> produtos)
{
    public string CaixaId { get; set; } = caixaId;
    public List<string> Produtos { get; set; } = produtos; // < ProdutoId>
    public string? Observacao { get; set; } = string.Empty;
}
