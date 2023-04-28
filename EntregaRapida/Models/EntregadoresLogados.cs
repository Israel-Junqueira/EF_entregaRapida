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
        public IHttpContextAccessor HttpContext { get; set; }
        private Timer _timer;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly Banco _dbcontext;

        public EntregadoresLogados(Banco banco, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContext)
        {
            this._userManager = userManager;
            this._dbcontext = banco;
            this.HttpContext = httpContext;
            this._timer = new Timer(TimerCallback,null,TimeSpan.Zero,TimeSpan.FromMinutes(1));
           
        }
        public void TimerCallback(Object state)
        {
            if (HttpContext.HttpContext.Session.IsAvailable == true)
            {
                // verifica se a sessão do usuário ainda está ativa
                if (HttpContext.HttpContext.Session.IsAvailable == true)
                {
                    // se estiver ativa, então continua o processo
                    Console.WriteLine("Usuario Ainda logado");

                }
                else
                {

                    // se não estiver ativa, então desconecta o usuário
                    // Desconecta o usuário
                    var UserId = HttpContext.HttpContext.Session.GetString("IdEntregador");
                    var Entregador = _dbcontext.Entregadores.Where(c => c.Idaspnetuser == UserId).FirstOrDefault();
                    Entregador.StatusEntregador = false;
                    Console.WriteLine("usuario disconectado");
                }
            }
            else
            {
                Console.WriteLine("Off");
            }

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
                    HttpContext.HttpContext.Session.SetString("IdEntregador",idUsuario);
                    HttpContext.HttpContext.Session.SetString("NomeEntregador", LoginVm.UserName);
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
                    HttpContext.HttpContext.Session.SetString("StatusEntregador",statusString);
                    db.SaveChanges();
                }
          
        }
    }
  
}
}