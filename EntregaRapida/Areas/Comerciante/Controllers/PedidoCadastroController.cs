using EntregaRapida.Data;
using EntregaRapida.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EntregaRapida.Repository.Interfaces;
using Microsoft.AspNetCore.SignalR;
using EntregaRapida.Models.ClassHubs;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Forms;

namespace EntregaRapida.Areas.Comerciante.Controllers
{
    [Area("Comerciante")]
    [Authorize("Lojista")]
    public class PedidoCadastroController : Controller
    {
        private readonly Banco _context;
        private readonly ILojistas _lojistas;
        private readonly IHubContext<UsersHub> _hubContext;
        private readonly IPedido _pedido;
        public PedidoCadastroController(Banco context, ILojistas lojista, IHubContext<UsersHub> pedidoHubContext, IPedido pedido)
        {
            _hubContext = pedidoHubContext;
            _context = context;
            _lojistas = lojista;
            _pedido = pedido;

        }
        [HttpGet]
        [Route("PedidoCadastroController/")]
        [Route("PedidoCadastroController/Index")]
        public IActionResult Index()
        {
            var usuarioLogado = User.Identity.Name;
            var usuarioTotal = _lojistas.Endereco_lojista(usuarioLogado);
            ViewData["UsuarioEndereco"] = usuarioTotal.Endereco;
            ViewData["LojistaId"] = usuarioTotal.LojistaId;
            ViewData["LojistaNome"] = usuarioTotal.Nome;


            return View();
        }

        [HttpPost]
        [Route("PedidoCadastroController/CadastrarPedido")]
        public IActionResult CadastrarPedido(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
             
                return View("Index", pedido);
            }
            try
            {
                var httpcontext = HttpContext;
                var Novopedido = new Pedido
                {
                    Bairro = pedido.Bairro,
                    Cidade = pedido.Cidade,
                    date = pedido.date,
                    descricao = pedido.descricao,
                    distancia = pedido.distancia,
                    enderecoOrigem = pedido.enderecoOrigem,
                    enderecoDestino = pedido.enderecoCompleto,
                    LojistaId = pedido.LojistaId,
                    EntregadorId = pedido.EntregadorId,
                    LojistaNome = pedido.LojistaNome,
                    ContextId = httpcontext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                    
                  

                };
                _context.AddAsync(Novopedido);
                _context.SaveChangesAsync();
                _hubContext.Clients.Group("EntregadoresOnline").SendAsync("ReceberPedido", Novopedido);
                return RedirectToAction("Index", "Comerciante", new { area = "Comerciante" });
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            };
        }
        [HttpGet]
        [Route("PedidoCadastroController/HistoricoPedido")]
        public IActionResult HistoricoPedido()
        {
            var pedidos = _pedido.Lista_de_Pedidos_Do_Lojista(User.Identity.Name);
            return View(pedidos);
        }
    }
}
