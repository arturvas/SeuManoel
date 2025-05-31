namespace SeuManoel.API.Core.Dtos;

public class ProdutoDto(string produtoId, DimensaoDto dimensoes)
{
    public string ProdutoId { get; set; } = produtoId;
    public DimensaoDto Dimensoes { get; set; } = dimensoes;
}
