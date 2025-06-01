namespace SeuManoel.API.Core.Dtos;

public class ProdutoDto
{
    public ProdutoDto(string produtoId, DimensaoDto dimensoes)
    {
        ProdutoId = produtoId;
        Dimensoes = dimensoes;
    }

    public string ProdutoId { get; set; }
    public DimensaoDto Dimensoes { get; set; }
}
