using EntregaRapida.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaRapida.Areas.Comerciante.Controllers
{
    [Area("Comerciante")]
    [Authorize("Lojista")]
    public class ComercianteController : Controller
    {
        private readonly IPedido _pedido;
        public ComercianteController(IPedido pedido)
        {
            _pedido = pedido;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var PedidosPendentes = _pedido.Lista_de_Pedidos_Do_Lojista(User.Identity.Name);

            return View(PedidosPendentes);
        }
    }
}
