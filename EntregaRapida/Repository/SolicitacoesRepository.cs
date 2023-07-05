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

        public void AlterarStatusSolicitacao_Aceito(int pedidoId)
        {
            var solicitacao = _context.solicitacoes.FirstOrDefault(x=>x.pedidoId == pedidoId);
            solicitacao.Status_Solicitacao = Models.Enum.Status_Solicitacao.Aceito;
            _context.SaveChanges();
        }

        public void AlterarStatusSolicitacao_Negado(int pedidoId)
        {
            var solicitacao = _context.solicitacoes.FirstOrDefault(x => x.pedidoId == pedidoId);
            solicitacao.Status_Solicitacao = Models.Enum.Status_Solicitacao.Negado;
            _context.SaveChanges();
        }

        public List<solicitacoes> Getsolicitacoes(string logistaId)
        {
             List<solicitacoes> solicitacoes = _context.solicitacoes.Where(x=> x.Status_Solicitacao == Models.Enum.Status_Solicitacao.Pendente && x.logistaId==logistaId).ToList();
            return solicitacoes;
        }

        public bool IsolicitacoesExists(int pedidoId, string Entregador)
        {
            return _context.solicitacoes.Any(x => x.pedidoId == pedidoId && x.EntregadorNome == Entregador);
        }
    }
}
