using EntregaRapida.Models.HubServices;

namespace EntregaRapida.Repository.Interfaces
{
    public interface Isolicitacoes
    {
        public List<solicitacoes> Getsolicitacoes(string logistaId);
    }
}
