using EntregaRapida.Data;
using EntregaRapida.Repository.Interfaces;
using EntregaRapida.Models;

namespace EntregaRapida.Repository{
    public class LojistaRepository:ILojistas {
        private readonly Banco _dbBanco;
        public LojistaRepository(Banco banco)
        {
            this._dbBanco = banco;
        }

        public List<Lojista> Lista_de_Lojistas =>_dbBanco.Lojistas.OrderBy(x=>x).ToList();
    }

}