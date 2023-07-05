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

        public void AdicionarCorrida(string Entregadorid)
        {
            var entregador = _dbanco.Entregadores.FirstOrDefault(x => x.Idaspnetuser == Entregadorid);
            entregador.CorridasIncompletas += 1;
            _dbanco.SaveChanges();

        }

        public Entregador GetCorridasIncompletas(string IdEntregador)
        {
          var entregador = _dbanco.Entregadores.FirstOrDefault(n => n.Idaspnetuser == IdEntregador);
            return entregador;
        }

        public void RemoverCorrida(string Name)
        {
            throw new NotImplementedException();
        }

        public void StatusEntregador_Ativado(string Entregadorid)
        {
            try
            {
                var entregador = _dbanco.Entregadores.FirstOrDefault(x => x.Idaspnetuser == Entregadorid);
                entregador.StatusEntregador = true;
                _dbanco.SaveChanges();

            }
            catch (Exception)
            {

                throw ;
            }
            

        }

        public void StatusEntregador_Desativado(string Entregadorid)
        {
            throw new NotImplementedException();
        }
    }    
        

}