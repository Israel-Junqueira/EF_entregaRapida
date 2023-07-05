using EntregaRapida.Models;

namespace EntregaRapida.Repository.Interfaces{
    public interface IEntregadores{
        public List<Entregador> Lista_De_Entregadores { get;}
        public Entregador GetCorridasIncompletas(string Name);
        public void AdicionarCorrida(string IdEntregador);
        public void RemoverCorrida(string Name);

        public void StatusEntregador_Ativado(string Entregadorid);
        public void StatusEntregador_Desativado(string Entregadorid);
    }
}