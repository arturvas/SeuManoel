using Microsoft.AspNetCore.Mvc;
using SeuManoel.API.Core.Dtos;
using SeuManoel.API.Services;

namespace SeuManoel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly EmpacotamentoService _empacotamentoService;
    
    public PedidosController(EmpacotamentoService empacotamentoService)
    {
        _empacotamentoService = empacotamentoService;
    }
    
    [HttpPost("empacotar")]
    public IActionResult EmpacotarPedidos([FromBody] PedidosRequestDto request)
    {
        var listaDePedidos = request.Pedidos;
        var resposta = _empacotamentoService.Empacotar(listaDePedidos);
        var respostaFinal = new RespostaEmpacotamentoDto{ Pedidos = resposta};
        
        return Ok(respostaFinal);
    }
}
