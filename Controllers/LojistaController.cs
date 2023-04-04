using Microsoft.AspNetCore.Mvc;

namespace EntregaRapida.Controllers{

    public class LojistaController :Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }

}