using EntregaRapida.Data;
using EntregaRapida.Models.HubServices;
using EntregaRapida.Repository.Interfaces;

namespace EntregaRapida.Repository
{
    public class SolicitacoesRepository : Isolicitacoes
    {
        private readonly Banco _context;

        public SolicitacoesRepository(Banco context)
        {
            _context = context;
        }

        public List<solicitacoes> Getsolicitacoes(string logistaId)
        {
            return _context.Solicitacoes.Where(x=>x.logistaId == logistaId).ToList();
        }
    }
}
