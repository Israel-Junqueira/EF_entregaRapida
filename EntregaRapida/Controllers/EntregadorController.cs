using Microsoft.AspNetCore.Mvc;
using EntregaRapida.Models;
using EntregaRapida.Data;
using System.Linq;
using EntregaRapida.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EntregaRapida.Controllers
{

    public class EntregadorController : Controller
    {
        private readonly IEntregadores _IentregadoresRepositories;
        private readonly Banco _dbcontext;
        public UserManager<IdentityUser> UserManager { get; }

        public EntregadorController(Banco banco, IEntregadores _IentregadoresRepositories, UserManager<IdentityUser> userManager)
        {
            this.UserManager = userManager;
            this._dbcontext = banco;
            this._IentregadoresRepositories = _IentregadoresRepositories;
        }

    

        public IActionResult Index()
        {
            var entregadores = _IentregadoresRepositories.Lista_De_Entregadores;
            return View(entregadores);
        }

        [HttpGet]
        public IActionResult Cadastro()
        {

            return View();

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(Entregador entregador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var user = await UserManager.FindByNameAsync(entregador.Nome);
                   if (user == null){
                    user = new IdentityUser()
                    {
                        UserName = entregador.Nome,

                        
                    };
                   }
                    Console.WriteLine("______________________________________________________________");
                    Console.WriteLine($"{entregador.Nome},{entregador.Modalidade},{entregador.Veiculo},{entregador.PlataformaId}");
                    Console.WriteLine("______________________________________________________________");
                    _dbcontext.Add(entregador);
                    _dbcontext.SaveChanges();
                    Console.WriteLine("passou por aq tbm");
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Deu um erro aq carai: " + ex);
            }

            return View(entregador);
        }
    }
}