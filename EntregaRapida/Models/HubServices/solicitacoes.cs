using EntregaRapida.Models.Enum;

namespace EntregaRapida.Models.HubServices
{
    public class solicitacoes
    {
        public int solicitacoesId { get; set; }
        public string logistaId { get; set; }
        public int pedidoId { get; set; }
        public Status_Solicitacao Status_Solicitacao { get; set; }
    }
}
