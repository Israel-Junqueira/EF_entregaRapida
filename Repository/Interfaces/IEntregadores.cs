using EntregaRapida.Models;

namespace EntregaRapida.Repository.Interfaces{
    public interface IEntregadores{
        public List<Entregador> Lista_De_Entregadores { get;}

        public List<Entregador> Tras_Lista_Entregadores_online{get;}
    }
}