using EntregaRapida.Models.HubServices;

namespace EntregaRapida.Repository.Interfaces
{
    public interface Isolicitacoes
    {
        public List<solicitacoes> Getsolicitacoes(string logistaId);
        public bool IsolicitacoesExists(int pedidoId,string Entregador);

        public void AlterarStatusSolicitacao_Aceito(int pedidoId);
        public void AlterarStatusSolicitacao_Negado(int pedidoId);
        
    }
}
