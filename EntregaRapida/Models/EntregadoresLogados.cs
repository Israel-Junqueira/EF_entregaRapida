using EntregaRapida.Data;
using EntregaRapida.Repository.Interfaces;
using EntregaRapida.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace  EntregaRapida.Models {


public class EntregadoresLogados
{

        public string EntregadorId { get; set; }
        public List<Entregador> Entregadores { get; set; }
        private readonly UserManager<IdentityUser> _userManager;

        private readonly Banco _dbcontext;

        public EntregadoresLogados(Banco banco)
        {
            
           
            this._dbcontext = banco;
      
        }
        public EntregadoresLogados(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }
    public async void  StartSession(string nome)
    {
     
       var userName = await _userManager.FindByNameAsync(nome);
        if (userName != null){
            var idUsuario = userName.Id;
            var Entregador = _dbcontext.Entregadores.Where(x => x.Idaspnetuser == idUsuario);

            if(Entregador != null){
               

              // HttpContext.Current.Session["UserId"] = idUsuario;
            }
        }
    }
  
}
}