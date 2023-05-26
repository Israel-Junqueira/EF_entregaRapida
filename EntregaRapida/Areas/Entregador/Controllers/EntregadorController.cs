using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaRapida.Areas.Entregador.Controllers
{
    [Area("Entregador")]
    [Authorize("Entregador")]
    public class EntregadorController : Controller
    {
        [Route("EntregadorController/")]
        [Route("EntregadorController/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
