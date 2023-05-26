using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaRapida.Areas.Comerciante.Controllers
{
    [Area("Comerciante")]
    [Authorize("Lojista")]
    public class ComercianteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
