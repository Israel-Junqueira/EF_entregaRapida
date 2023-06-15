using EntregaRapida.Models.ClassHubs;
using EntregaRapida.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EntregaRapida.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly UserManager<IdentityUser> _usermaneger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IHubContext<UsersHub> _hubContext;

        public AccountController(UserManager<IdentityUser> usermaneger, SignInManager<IdentityUser> signInManager, IHubContext<UsersHub> hubContext)
        {
            _usermaneger = usermaneger;
            _signInManager = signInManager;
            this._hubContext = hubContext;

        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel LoginVM)
        {


            if (!ModelState.IsValid)
            {
                return View(LoginVM);
            }
            var user = await _usermaneger.FindByNameAsync(LoginVM.UserName);
            if (user != null)
            {
                
                var result = await _signInManager.PasswordSignInAsync(user, LoginVM.Password, false, false);
                if (result.Succeeded)
                {

                    var ususario = await _usermaneger.FindByNameAsync(LoginVM.UserName);
                    var roles = await _usermaneger.GetRolesAsync(ususario);

                    if (string.IsNullOrEmpty(LoginVM.ReturnUrl))
                    {
                        var httpContext = HttpContext;
                        var hubContext = this._hubContext;

                        if (roles.Contains("Lojista"))
                        {
                            return RedirectToAction("Index", "Comerciante", new { area = "Comerciante" });
                        }
                        else if (roles.Contains("Entregador"))
                        {
                            await hubContext.Groups.AddToGroupAsync(httpContext.Connection.Id, "EntregadoresOnline");

                            return RedirectToAction("Index", "Entregador", new { area = "Entregador" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Admin", new { area = "Admin" });
                        }

                    }
                    return Redirect(LoginVM.ReturnUrl);

                    
                  
                 
                }
                return View(LoginVM);
            }
            ModelState.AddModelError("", "Verifique o usuario ou senha e tente novamente");

            return View(LoginVM);
        }

        public IActionResult Register()
        {
            return View();
        }

    }
}
