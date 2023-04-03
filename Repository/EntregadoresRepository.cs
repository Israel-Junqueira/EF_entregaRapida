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
       
       
       }    
        

}