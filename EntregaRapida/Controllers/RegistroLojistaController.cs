using Microsoft.AspNetCore.Mvc;
using EntregaRapida.Repository.Interfaces;
using EntregaRapida.Data;
using EntregaRapida.Models;
namespace EntregaRapida.Controllers{

    public class RegistroLojistaController :Controller
    {
        private readonly ILojistas _Ilojista;
        private readonly Banco _dbBanco;

        public RegistroLojistaController(Banco banco,ILojistas lojista)
        {
            _Ilojista = lojista;
            _dbBanco = banco;
        }
        public IActionResult Index(){
            var lojistas = _Ilojista.Lista_de_Lojistas;
            return View(lojistas);
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(Lojista lojista)
        {
             try
            {
                if(ModelState.IsValid){
                    _dbBanco.Add(lojista);
                    _dbBanco.SaveChanges();
                   Console.WriteLine("passou por aq tbm");
                    return RedirectToAction("Index");
    
                }
            }catch(Exception ex){
                ModelState.AddModelError("","Deu um erro aq carai: "+ex);
            }
         
            return View(lojista);
        }

      
    }

}