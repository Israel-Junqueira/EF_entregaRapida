using Microsoft.AspNetCore.Mvc;
using EntregaRapida.Repository.Interfaces;
using EntregaRapida.Data;
using EntregaRapida.Models;
using EntregaRapida.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace EntregaRapida.Controllers{

    public class RegistroLojistaController :Controller
    {
        private readonly UserManager<IdentityUser> _usermaneger;
        private readonly SignInManager<IdentityUser> _signInManager;
        
        private readonly ILojistas _ILojistaRepository;
        private readonly Banco _dbcontext;

        public RegistroLojistaController(Banco banco, ILojistas _ILojistaRepository, UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            
            this._usermaneger = userManager;
            this._dbcontext = banco;
            this._ILojistaRepository = _ILojistaRepository;
            this._signInManager = signInManager;
        }

        private readonly ILojistas _Ilojista;
        private readonly Banco _dbBanco;

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
       public async Task<IActionResult> Cadastro(RegistroLojistaViewModel LojistaUsersView)
        {
            if(ModelState.IsValid){
                var user = new RegistroLojistaViewModel(){ UserName = LojistaUsersView.NomeUsuario ,Email = LojistaUsersView.Email};

                var verifica = _dbcontext.Lojistas.Any(c=> c.Nome.Equals(LojistaUsersView.NomeUsuario));
                
                if(verifica != true ){
                  
                      var result = await _usermaneger.CreateAsync(user,LojistaUsersView.Senha);
                    if (result.Succeeded){
                        await _usermaneger.AddToRoleAsync(user, "Lojista");
                        var userName = await _usermaneger.FindByNameAsync(user.UserName);
                        var UserId = await _usermaneger.GetUserIdAsync(userName);

                        var Lojista = new Lojista() {  Idaspnetuser = UserId, CNPJ = LojistaUsersView.CNPJ,Endereco = LojistaUsersView.Endereco,Nome = LojistaUsersView.NomeComercio,PlataformaId = LojistaUsersView.PlataformaId,Telefone = LojistaUsersView.Telefone,TipoComercio= LojistaUsersView.TipoComercio};
                        _dbcontext.Add(Lojista);
                        _dbcontext.SaveChanges();

                        return RedirectToAction("Login","Account");
                    }else{
                        this.ModelState.AddModelError("Registro","Falha ao realizar registro");
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("NomeUsuario", "Este nome de usuário já está em uso. Por favor, escolha outro.");
                }



            }
            return View(LojistaUsersView);

        }

      
    }

}