using EntregaRapida.Data;
using EntregaRapida.Models.ClassHubs;
using EntregaRapida.Models.HubServices;
using EntregaRapida.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

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
        private readonly Isolicitacoes _isolicitacoes;
        private readonly IEntregadores _entregadores;
        public EntregarPedidoController(Banco context,UserManager<IdentityUser> identityUser,IPedido pedido, IHubContext<UsersHub> pedidoHubContext,Isolicitacoes isolicitacoes,IEntregadores entregadores)
        {
            _entregadores = entregadores;
            _isolicitacoes = isolicitacoes;
            _context = context;
            _UserManager = identityUser;
            _pedido = pedido;
            _hubContext = pedidoHubContext;
        }

       
        [Route("EntregarPedidoController/SolicitarEntrega/{pedidoId}/{lojistaId}")]
        [HttpPost]
        public  IActionResult SolicitarEntrega(int pedidoId, string lojistaId)
        {
            try
            {
                var entregador = User.Identity.Name;
                var idEntregador = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var verify = _isolicitacoes.IsolicitacoesExists(pedidoId, entregador);

                if (verify == false)
                {
                    try
                    {
                        var Entregador = _entregadores.GetCorridasIncompletas(idEntregador);

                        var solicitacao = new solicitacoes
                        {
                            logistaId = lojistaId,
                            pedidoId = pedidoId,
                            EntregadorNome = User.Identity.Name,
                            Status_Solicitacao = Models.Enum.Status_Solicitacao.Pendente,
                            CorridasDoEntregador = Entregador.CorridasIncompletas,
                            aspnetuseridEntregador = idEntregador
                        };


                        _context.AddAsync(solicitacao);
                        _context.SaveChanges();
                        return Json(entregador);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                   
                }
                else
                {
                    return new ObjectResult(new { Error = "Você já solicitou uma entrega" })
                    {
                        StatusCode = 406
                    };
                }
            }
            catch (Exception ex )
            {

                return Json(new { Error = ex.ToString() });
            }
          
            
            
        }
    }
}
