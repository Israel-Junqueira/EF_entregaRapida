using EntregaRapida.Data;
using EntregaRapida.Repository.Interfaces;
using EntregaRapida.ViewModel;
using Microsoft.AspNetCore.Identity;
// using System.Web;

namespace  EntregaRapida.Models {


public class EntregadoresLogados
{

        public string EntregadorId { get; set; }
        public List<Entregador> Entregadores { get; set; }

        private readonly UserManager<IdentityUser> _userManager;
        private readonly Banco _dbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EntregadoresLogados(Banco banco, UserManager<IdentityUser> userManager, IHttpContextAccessor _httpContextAccessor)
        {
            this._userManager = userManager;
            this._dbcontext = banco;
            this._httpContextAccessor = _httpContextAccessor;
        }
        
    public async void  StartSession(LoginViewModel LoginVm)
    {
           

       var userName = await _userManager.FindByNameAsync(LoginVm.UserName);
        if (userName != null){
            var idUsuario = userName.Id;
                using (var db = _dbcontext)
                {
                    var Entregador = db.Entregadores.Where(c => c.Idaspnetuser == idUsuario).FirstOrDefault();
                    Entregador.StatusEntregador = true;
                    _httpContextAccessor.HttpContext.Session.SetString("IdEntregador",idUsuario);
                    _httpContextAccessor.HttpContext.Session.SetString("NomeEntregador", LoginVm.UserName);
                    var status = Entregador.StatusEntregador;
                    var statusString="";
                    if (status == true)
                    {
                        statusString = "Online";
                    }
                    else
                    {
                        statusString = "Offline";
                    }
                    _httpContextAccessor.HttpContext.Session.SetString("StatusEntregador",statusString);
                    db.SaveChanges();
                }
          
        }
    }
  
}
}