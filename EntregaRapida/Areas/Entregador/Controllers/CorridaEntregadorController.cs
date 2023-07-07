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
    public class CorridaEntregadorController : Controller
    {
        [HttpGet]
        [Route("CorridaEntregadorController/IndexCorridaEntregador")]
        public IActionResult IndexCorridaEntregador()
        {
            var data = new
            {
                redirectUrl = Url.Action("Maps", "CorridaEntregadorController", new { area = "Entregador" })
               
            };

            // Retorna um JSON contendo a URL de redirecionamento
            return Json(data);
        }

        [HttpGet]
        [Route("CorridaEntregadorController/Maps")]
        public IActionResult Maps()
        {
            return View();
        }

    }
}
