using EntregaRapida.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EntregaRapida.Models;
using EntregaRapida.Data;

namespace EntregaRapida.Controllers {
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _usermaneger;
        private readonly Banco _banco;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly EntregadoresLogados _entregadoresLogados;
        public LoginController(UserManager<IdentityUser> usermaneger, SignInManager<IdentityUser> signInManager, Banco banco,EntregadoresLogados _entregadorcokkie)
        {
            _usermaneger = usermaneger;
            _signInManager = signInManager;
            _banco = banco;
            _entregadoresLogados = _entregadorcokkie;

        }

        [HttpGet]
        public IActionResult Login(string returnUrl){
            return View(new LoginViewModel(){
              ReturnUrl = returnUrl  
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel LoginVM){

            if (!ModelState.IsValid){
                 return View(LoginVM);
            }
            var user = await _usermaneger.FindByNameAsync(LoginVM.UserName);
            if(user != null){



                _entregadoresLogados.StartSession(LoginVM);
                
                var result =  await _signInManager.PasswordSignInAsync(user,LoginVM.Password,false,false);

                if(result.Succeeded){
                    if(string.IsNullOrEmpty(LoginVM.ReturnUrl)){
                        return RedirectToAction("Index","Home");
                    }
                    return Redirect(LoginVM.ReturnUrl);
                }
                return View(LoginVM);
            }
            ModelState.AddModelError("","Falha ao realizar o login!!!");
            
            return View(LoginVM);
        }
        [HttpGet]
        public  IActionResult Register( ){
            return View();
        }
        [HttpGet]
        public IActionResult Register(LoginViewModel loginViewModel){
            return View();
        }
    }
}