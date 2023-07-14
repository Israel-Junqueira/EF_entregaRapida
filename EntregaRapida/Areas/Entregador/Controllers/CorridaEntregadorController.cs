using EntregaRapida.Data;
using EntregaRapida.Models;
using EntregaRapida.Models.ClassHubs;
using EntregaRapida.Repository.Interfaces;
using EntregaRapida.ViewModel.ServicesMaps;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EntregaRapida.Areas.Entregador.Controllers
{
    [Area("Entregador")]
    [Authorize("Entregador")]
    public class CorridaEntregadorController : Controller
    {
        private readonly IPedido _Pedido;
        public CorridaEntregadorController(IPedido Pedido)
        {
            _Pedido = Pedido;
        }
        [HttpGet]
        [Route("CorridaEntregadorController/IndexCorridaEntregador/{area}/{pedidoId}/{lojistaId}")]
        public IActionResult IndexCorridaEntregador(int pedidoId, string lojistaId)
        {
            var data = new
            {
                redirectUrl = Url.Action("Maps", "CorridaEntregadorController", new { area = "Entregador", idPedido = "__idPedido__", idLojista = "__idLojista__" })
                .Replace("__idPedido__", pedidoId.ToString())
                .Replace("__idLojista__", lojistaId),
            idPedido = pedidoId,
                idLojista = lojistaId
            };

            // Retorna um JSON contendo a URL de redirecionamento
            return Json(data);
        }

        [HttpGet]
        [Route("CorridaEntregadorController/Maps")]
        public IActionResult Maps([FromQuery(Name = "idLojista")] string idLojista, [FromQuery(Name = "idPedido")] int idPedido)
        {
            var pedido = _Pedido.GetEnderecoPedido(idPedido);

            var coordenadas = new Coordenadas
            {
                EnderecoLojista = pedido.enderecoOrigem,
               EnderecoPedido = pedido.enderecoDestino,
            };

            return View(coordenadas);
        }

    }
}
