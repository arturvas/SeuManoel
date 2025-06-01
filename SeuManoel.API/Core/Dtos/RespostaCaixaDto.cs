namespace SeuManoel.API.Core.Dtos;

public class RespostaCaixaDto
{
    public string? CaixaId { get; set; }
    public List<string> Produtos { get; set; } = [];
    public string? Observacao { get; set; } = string.Empty;
}
