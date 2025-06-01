using System.Text.Json.Serialization;

namespace SeuManoel.API.Core.Dtos;

public class ProdutoDto
{
    public ProdutoDto(string produtoId, DimensaoDto dimensoes)
    {
        ProdutoId = produtoId;
        Dimensoes = dimensoes;
    }

    [JsonPropertyName("produto_id")]
    public string ProdutoId { get; set; }
    
    public DimensaoDto Dimensoes { get; set; }
}
