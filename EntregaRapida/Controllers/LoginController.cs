using EntregaRapida.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EntregaRapida.Models;
using EntregaRapida.Data;
using EntregaRapida.Models.ClassHubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.Extensions.Caching.Memory;

namespace EntregaRapida.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHubContext<UsersHub> _hubContext;
        private readonly UserManager<IdentityUser> _usermaneger;
        private readonly Banco _banco;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly EntregadoresLogados _entregadoresLogados;
        private readonly HttpContextAccessor _HttpContextAccessor1;

        public LoginController(UserManager<IdentityUser> usermaneger, SignInManager<IdentityUser> signInManager, Banco banco, IHubContext<UsersHub> hubContext,HttpContextAccessor httpContextAccessor)
        {
            _usermaneger = usermaneger;
            _signInManager = signInManager;
            _banco = banco;
            this._hubContext = hubContext;
            _HttpContextAccessor1 = httpContextAccessor;

        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            var http = _HttpContextAccessor1.HttpContext;
            http.Session.Clear();
            HttpContext.User = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register(LoginViewModel loginViewModel)
        {
            return View();
        }
    }
}