

using Microsoft.AspNetCore.Mvc;
using QuickBuy.dominio.Contratos;
using QuickBuy.dominio.Entidades;

namespace Quickbuy.Web.Controllers
{
    [Route("api/[Controller]")]
    public class PedidoController: Controller
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            try
            {
                _pedidoRepositorio.Adicionar(pedido);
                return Ok(pedido.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());
                throw;
            }
        }
    }
}
