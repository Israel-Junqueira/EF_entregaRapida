using EntregaRapida.Data;
using EntregaRapida.Models.ClassHubs;
using EntregaRapida.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EntregaRapida.Areas.Entregador.Controllers
{
    [Area("Entregador")]
    [Authorize("Entregador")]
    public class EntregarPedidoController : Controller
    {
        private readonly Banco _context;
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly IPedido _pedido;
        private readonly IHubContext<UsersHub> _hubContext;
        public EntregarPedidoController(Banco context,UserManager<IdentityUser> identityUser,IPedido pedido, IHubContext<UsersHub> pedidoHubContext)
        {
            _context = context;
            _UserManager = identityUser;
            _pedido = pedido;
            _hubContext = pedidoHubContext;
        }

     //   [Route("EntregarPedidoController/Entregar/{IdPedido}")]
        [HttpPost]
        public IActionResult Entregar(int IdPedido)
        {
            var EntregadorOnline = User.Identity.Name;
            var IdEntregador = _context.Entregadores.FirstOrDefault(x => x.Nome == EntregadorOnline);
            _pedido.Adiciona_entregador_ao_Pedido(IdEntregador.EntregadorId,IdPedido);
            _pedido.Muda_Status_do_Pedido(IdPedido);

          return Json(new {success = true});
        }
       
        [Route("EntregarPedidoController/Entregar/{comercianteId}/{IdPedido}")]
        [HttpPost]
        public async Task<IActionResult> SolicitarEntrega(string comercianteId, int pedidoId)
        {
            var entregador = User.Identity.Name;
            string mensagem = "O entregador "+entregador+" selecionou o pedido #" + pedidoId + ". Deseja aceitá-lo?";
            // await _hubContext.Clients.Group(comercianteId).SendAsync("ReceberNotificacao", mensagem);
            // await _hubContext.Clients.Group(comercianteId).SendAsync("ReceberSolicitacaoEntrega", mensagem);
           await _hubContext.Clients.Group(comercianteId).SendAsync("ReceberSolicitacaoEntrega", mensagem);
           return RedirectToAction("Index", "Entregador", new { area = "Entregador" });
           // return Json(new { success = true });
        }
    }
}
