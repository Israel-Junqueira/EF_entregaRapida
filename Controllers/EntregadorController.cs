using Microsoft.AspNetCore.Mvc;
using EntregaRapida.Models;
namespace EntregaRapida.Controllers{

    public class EntregadorController : Controller{
        public IActionResult Index(){
            List<Entregador>entregador = new List<Entregador>();
            entregador.Add(new Entregador("Rael","exemplo","14","996983584","12345678911",Models.Enum.Modalidade.Freelancer));
            return View(entregador);
        }

        [HttpGet]
        public IActionResult Cadastro(){
          
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
          public IActionResult Cadastro([Bind(include:"Nome,Endereco,DDD,Celular,CNH,modalidade")]Entregador entregador){
         
            return View();
        }
    }
}