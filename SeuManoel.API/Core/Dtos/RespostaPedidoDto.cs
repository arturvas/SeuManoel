namespace SeuManoel.API.Core.Dtos;

public class RespostaPedidoDto(List<RespostaCaixaDto> caixas)
{
    public int PedidoId { get; set; }
    public List<RespostaCaixaDto> Caixas { get; set; } = caixas;
}
