namespace SeuManoel.API.Core.Dtos;

public class RespostaPedidoDto
{
    public int PedidoId { get; set; }
    public List<RespostaCaixaDto> Caixas { get; set; } = [];
}
