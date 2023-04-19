using EntregaRapida.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EntregaRapida.Controllers {
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _usermaneger;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(UserManager<IdentityUser> usermaneger, SignInManager<IdentityUser> signInManager)
        {
            _usermaneger = usermaneger;
            _signInManager = signInManager;
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