using EntregaRapida.Models;
using EntregaRapida.Models.ClassHubs;
using EntregaRapida.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EntregaRapida.Areas.Entregador.Controllers
{

    [Area("Entregador")]
    [Authorize("Entregador")]
    public class EntregadorController : Controller
    {
        private readonly IPedido _pedido;
        private readonly IHubContext<UsersHub> _hubContext;
        public EntregadorController(IPedido pedido,IHubContext<UsersHub> userhub)
        {
            _pedido = pedido;
            _hubContext = userhub;
        }
        [Route("EntregadorController/")]
        [Route("EntregadorController/Index")]
        public IActionResult Index()
        {
           
            List<Pedido> pedidosPendentes = _pedido.Lista_de_Pedidos_Pendentes_Para_Entregador();
            // Envia os pedidos pendentes aos entregadores online
            _hubContext.Clients.Group("EntregadoresOnline").SendAsync("ReceberPedidosPendentes", pedidosPendentes); //SIGNALR

            return View();
        }
    }
}
