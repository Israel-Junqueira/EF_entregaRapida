using EntregaRapida.Data;
using EntregaRapida.Models;
using EntregaRapida.Repository.Interfaces;
using EntregaRapida.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EntregaRapida.Controllers
{

    public class RegistroEntregadorController : Controller
    {
        private readonly UserManager<IdentityUser> _usermaneger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEntregadores _IentregadoresRepositories;
        private readonly Banco _dbcontext;

        public RegistroEntregadorController(Banco banco, IEntregadores _IentregadoresRepositories, UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            
            this._usermaneger = userManager;
            this._dbcontext = banco;
            this._IentregadoresRepositories = _IentregadoresRepositories;
            this._signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult CadastroEntregadorUsers()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
          public async Task<IActionResult> CadastroEntregadorUsers(EntregadorUsersViewModel entregadorUsersView)
        {
            if(ModelState.IsValid){
                var user = new EntregadorUsersViewModel(){ UserName = entregadorUsersView.NomeUsuario,Email = entregadorUsersView.Email};

                var verifica = _dbcontext.Entregadores.Any(c => c.Nome.Equals(entregadorUsersView.NomeUsuario));
                
                if(verifica != true ){
                      var result = await _usermaneger.CreateAsync(user,entregadorUsersView.Senha);
                    if (result.Succeeded){
                        await _usermaneger.AddToRoleAsync(user, "Entregador");
                        var userName = await _usermaneger.FindByNameAsync(user.UserName);
                        var UserId = await _usermaneger.GetUserIdAsync(userName);

                        var Entregador = new Entregador() { Celular = entregadorUsersView.Celular, CNH = entregadorUsersView.CNH, DDD = entregadorUsersView.DDD, Endereco = entregadorUsersView.Endereco, Nome = entregadorUsersView.Nome, Modalidade = entregadorUsersView.Modalidade, Veiculo = entregadorUsersView.Veiculo, PlataformaId = entregadorUsersView.PlataformaId, Idaspnetuser = UserId };
                        _dbcontext.Add(Entregador);
                        _dbcontext.SaveChanges();

                      return RedirectToAction("Login", "Account");
                    }
                    else{
                        this.ModelState.AddModelError("Registro","Falha ao realizar registro");
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                       
                    }
                    return View(entregadorUsersView);

                }
                else
                {
                    ModelState.AddModelError("NomeUsuario", "Este nome de usuário já está em uso. Por favor, escolha outro.");
                }

            }
            return View(entregadorUsersView);

        }
         public IActionResult Index()
        {

            return View();

        }
      
    }
}
