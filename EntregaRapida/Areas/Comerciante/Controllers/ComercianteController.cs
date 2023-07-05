using EntregaRapida.Data;
using EntregaRapida.Models.ClassHubs;
using EntregaRapida.Models.HubServices;
using EntregaRapida.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace EntregaRapida.Areas.Comerciante.Controllers
{
    [Area("Comerciante")]
    [Authorize("Lojista")]
    public class ComercianteController : Controller
    {
        private readonly IPedido _pedido;
        private readonly ILojistas _lojistas;
        private readonly Isolicitacoes _isolicitacoes;
        private readonly Banco _context;
        private readonly IEntregadores _entregadores;
        private readonly IHubContext<UsersHub> _hubContext;
        public ComercianteController(IPedido pedido,ILojistas lojistas,Isolicitacoes isolicitacoes,Banco banco, IEntregadores entregadores,IHubContext<UsersHub> hubContext)
        {
            _hubContext=hubContext;
            _context = banco;
            _isolicitacoes = isolicitacoes;
            _lojistas = lojistas;
            _pedido = pedido;
            _entregadores = entregadores;
        }
        [HttpGet]
        [Route("ComercianteController/Index")]
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
            var lojistaId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<solicitacoes> solicitacoes = _isolicitacoes.Getsolicitacoes(lojistaId);
            return Json(solicitacoes);
        }


        [Route("Comerciante/Comerciante/Acceptrequest/{IdPedido}/{EntregadorNome}")]
        [HttpPost]
        public IActionResult Acceptrequest(int IdPedido, string EntregadorNome)
        {
            try
            {
                var solicitacao = _context.solicitacoes.FirstOrDefault(x => x.EntregadorNome == EntregadorNome);
                var IdEntregador = _context.Entregadores.FirstOrDefault(x => x.Idaspnetuser == solicitacao.aspnetuseridEntregador);

                _pedido.Adiciona_entregador_ao_Pedido(IdEntregador.EntregadorId, IdPedido); //Entregador é adicionado ao pedido 
                _pedido.Muda_Status_do_Pedido(IdPedido); // o Status do pedido muda para preparando
                _entregadores.StatusEntregador_Ativado(IdEntregador.Idaspnetuser); //estados do entregador muda para correndo
                _isolicitacoes.AlterarStatusSolicitacao_Aceito(IdPedido);
                _entregadores.AdicionarCorrida(IdEntregador.Idaspnetuser);

                var retorno = new
                {
                    success = true,
                    IdEntregador = IdEntregador.Idaspnetuser,
                    IdPedido = IdPedido
                };
                return Json(retorno);
            }
            catch (Exception)
            {

                throw;
            }
        
        }

    }
}
