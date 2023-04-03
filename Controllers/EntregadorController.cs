using Microsoft.AspNetCore.Mvc;
using EntregaRapida.Models;
using EntregaRapida.Data;
using System.Linq;
using EntregaRapida.Repository.Interfaces;


namespace EntregaRapida.Controllers{

    public class EntregadorController : Controller{ 
        private readonly IEntregadores _IentregadoresRepositories;
        private readonly Banco _dbcontext;

        public EntregadorController(Banco banco,IEntregadores  _IentregadoresRepositories)
        {
            this._dbcontext = banco;
             this._IentregadoresRepositories = _IentregadoresRepositories;
        }


        public IActionResult Index(){
          var lanches = _IentregadoresRepositories.Lista_De_Entregadores;
            return View(lanches);
        }

        [HttpGet]
        public IActionResult Cadastro(){
          
            return View();

        }
        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(Entregador entregador)
        {
            try
            {
                if(ModelState.IsValid){
                    Console.WriteLine("______________________________________________________________");
                    Console.WriteLine($"{entregador.Nome},{entregador.modalidade},{entregador.veiculo},{entregador.PlataformaId}");
                     Console.WriteLine("______________________________________________________________");
                    _dbcontext.Add(entregador);
                   _dbcontext.SaveChanges();
                   Console.WriteLine("passou por aq tbm");
                    return RedirectToAction("Index");
    
                }
            }catch(Exception ex){
                ModelState.AddModelError("","Deu um erro aq carai: "+ex);
            }
         
            return View(entregador);
        }
    }
}