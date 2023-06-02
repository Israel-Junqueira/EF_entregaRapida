using EntregaRapida.Data;
using EntregaRapida.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EntregaRapida.Areas.Entregador.Controllers
{
    [Area("Entregador")]
    [Authorize("Entregador")]
    public class EntregarPedidoController : Controller
    {
        private readonly Banco _context;
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly IPedido _pedido;
        public EntregarPedidoController(Banco context,UserManager<IdentityUser> identityUser,IPedido pedido)
        {
            _context = context;
            _UserManager = identityUser;
            _pedido = pedido;
        }

        [Route("EntregarPedidoController/Entregar/{IdPedido}")]
        [HttpPost]
        public IActionResult Entregar(int IdPedido)
        {
            var EntregadorOnline = User.Identity.Name;
            var IdEntregador = _context.Entregadores.FirstOrDefault(x => x.Nome == EntregadorOnline);
            _pedido.Adiciona_entregador_ao_Pedido(IdEntregador.EntregadorId,IdPedido);
            _pedido.Muda_Status_do_Pedido(IdPedido);

          return Json(new {success = true});
        }
    }
}
