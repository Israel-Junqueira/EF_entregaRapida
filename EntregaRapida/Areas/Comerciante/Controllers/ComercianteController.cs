using EntregaRapida.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EntregaRapida.Areas.Comerciante.Controllers
{
    [Area("Comerciante")]
    [Authorize("Lojista")]
    public class ComercianteController : Controller
    {
        private readonly IPedido _pedido;
        private readonly ILojistas _lojistas;
        public ComercianteController(IPedido pedido,ILojistas lojistas)
        {
            _lojistas = lojistas;
            _pedido = pedido;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var PedidosPendentes = _pedido.Lista_de_Pedidos_Do_Lojista(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            return View(PedidosPendentes);

        }

        [HttpGet]
        [Route("ComercianteController/GetTipoNegocio")]
        public IActionResult GetTipoNegocio()
        {
            var userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var TipoComercio =  _lojistas.GetTipoComercio(userid);
            return Json(TipoComercio );
        }
        [HttpGet]
        [Route("ComercianteController/GetSolicitacoes")]
        public IActionResult GetSolicitacoes()
        {

        }
    }
}
