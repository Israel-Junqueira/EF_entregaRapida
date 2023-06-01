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


        public Lojista Endereco_lojista(string lojista)
        {
            var user = _userManager.FindByNameAsync(lojista);
            var usuario= _dbBanco.Lojistas.FirstOrDefault(x=> x.Idaspnetuser == user.Result.Id);
            return usuario;
        }

    }

}