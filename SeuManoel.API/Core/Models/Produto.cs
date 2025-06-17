namespace SeuManoel.API.Core.Models;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Dimensao Dimensao { get; set; }
    public int DimensaoId { get; set; }
}
