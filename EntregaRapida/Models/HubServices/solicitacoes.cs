using EntregaRapida.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace EntregaRapida.Models.HubServices
{
    public class solicitacoes
    {
        public int solicitacoesId { get; set; }
        public string logistaId { get; set; }
        public int pedidoId { get; set; }
        public string EntregadorNome { get; set; }  
        public int CorridasDoEntregador { get; set; }
        public string aspnetuseridEntregador { get; set; }

        [EnumDataType(typeof(Status_Solicitacao))]
        public Status_Solicitacao Status_Solicitacao { get; set; }

    }
}
