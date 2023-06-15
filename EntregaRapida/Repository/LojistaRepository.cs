using EntregaRapida.Data;
using EntregaRapida.Repository.Interfaces;
using EntregaRapida.Models;
using Microsoft.AspNetCore.Identity;

namespace EntregaRapida.Repository{
    public class LojistaRepository:ILojistas {
        private readonly Banco _dbBanco;
        private readonly UserManager<IdentityUser> _userManager;
        public LojistaRepository(Banco banco, UserManager<IdentityUser> usermaneger )
        {
            this._dbBanco = banco;
            this._userManager = usermaneger;
        }

        public List<Lojista> Lista_de_Lojistas =>_dbBanco.Lojistas.OrderBy(x=>x).ToList();

        public  string GetTipoComercio(string idUser)
        {
            try
            {
                var   Lojista_com_id_correspondente =  _dbBanco.Lojistas.FirstOrDefault(x => x.Idaspnetuser == idUser);
                return Lojista_com_id_correspondente.TipoComercio.ToString();
            }
            catch (Exception ex)
            {

                return "ouve um erro ao buscar o tipo do comercio" + ex;
            }
          
            

        }

        public Lojista Endereco_lojista(string lojista)
        {
            var user = _userManager.FindByNameAsync(lojista);
            var usuario= _dbBanco.Lojistas.FirstOrDefault(x=> x.Idaspnetuser == user.Result.Id);
            return usuario;
        }

    }

}