using EntregaRapida.Models;
using EntregaRapida.Data;
using EntregaRapida.Repository.Interfaces;

namespace EntregaRapida.Repository{
    public class EntregadoresRepository : IEntregadores
    {
        private readonly Banco _dbanco;
        public EntregadoresRepository(Banco banco)
        {
            _dbanco = banco;
        }
       
       public List<Entregador> Lista_De_Entregadores => _dbanco.Entregadores.OrderBy(x=>x).ToList(); //expression bodied member

        public List<Entregador> Tras_Lista_Entregadores_online { get => _dbanco.Entregadores.Where(e => e.StatusEntregador == true).ToList();}

        public void AtualizarEstadoEntregador(int entregadorID, bool estado)
        {
            using (var db = _dbanco)
            {
                var entregador = db.Entregadores.Find(entregadorID);
                entregador.StatusEntregador = estado;
                db.SaveChanges();
            }
        }
    }    
        

}