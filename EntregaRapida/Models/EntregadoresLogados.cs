using EntregaRapida.Data;
using EntregaRapida.Repository.Interfaces;
using EntregaRapida.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace  EntregaRapida.Models {


public class EntregadoresLogados 
{

        public string EntregadorId { get; set; }
        public List<Entregador> Entregadores { get; set; }
        public IHttpContextAccessor HttpContext { get; set; }
        private Timer _timer;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Banco _dbcontext;
        private readonly object _state;

        public EntregadoresLogados(Banco banco, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("O objeto IHttpContextAccessor não pode ser nulo.");
            }
         
            this._userManager = userManager;
            this._dbcontext = banco;
            this.HttpContext = httpContext;

            StartTimer(this.HttpContext);
        }
        public void StartTimer(IHttpContextAccessor httpContext)
        {
          
            this._timer = new Timer(TimerCallback, this, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }
        public void TimerCallback(Object state)
       {
            var entregadores = (EntregadoresLogados)state;
            var httpcontext = entregadores.HttpContext.HttpContext;
            var http = httpcontext;

        
          if (http == null)
           {
              throw new ArgumentNullException("O objeto HttpContext no IHttpContextAccessor não pode ser nulo.");
            }
            if (http.Session.GetString("NomeEntregador") == null )
            {
                    Console.WriteLine("Usuario nao existe");
            }
            else
            {
                // se não estiver ativa, então desconecta o usuário
                // Desconecta o usuário
                var UserId = HttpContext.HttpContext.Session.GetString("IdEntregador");
                var Entregador = _dbcontext.Entregadores.Where(c => c.Idaspnetuser == UserId).FirstOrDefault();
                Entregador.StatusEntregador = false;
                _dbcontext.SaveChanges();
                Console.WriteLine("usuario disconectado");
            }

        }
       
    public async Task StartSession(LoginViewModel LoginVm)
    {
            var _session = HttpContext.HttpContext.Session;

       var userName = await _userManager.FindByNameAsync(LoginVm.UserName);
        if (userName != null){
            var idUsuario = userName.Id;
                using (var db = _dbcontext)
                {
                    var Entregador = db.Entregadores.Where(c => c.Idaspnetuser == idUsuario).FirstOrDefault();
                    Entregador.StatusEntregador = true;
                    _session.SetString("IdEntregador",idUsuario);
                    _session.SetString("NomeEntregador", LoginVm.UserName);
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
                    _session.SetString("StatusEntregador",statusString);
                    db.SaveChanges();

                }
          
        }
    }
  
}
}