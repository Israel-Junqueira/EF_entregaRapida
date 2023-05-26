using EntregaRapida.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntregaRapida.Models{

    public class Pedido{
       
        public int PedidoId { get; set; }
        public string enderecoOrigem { get; set; }
        public string enderecoDestino { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public double distancia { get; set; }
        public DateTime date { get; set; }



        [EnumDataType(typeof(StatusPedido))]    
        public StatusPedido statuspedido { get; set; } //  ✓ ok
        public int EntregadorId { get; set; }
        public int LojistaId { get; set; }    
        public int PagementoId { get; set; }
        public int NotificacaoId { get; set; }
        public int HistoricoId { get; set; }
        public Historico historico { get; set; } //1:N  ✓ ok
        public Entregador entregador { get; set; } //1:1  ✓ ok
        public Notificacao notificacao { get; set; }//1:1  ✓ ok
        public Pagamento pagamento{ get; set; }//1:1  ✓  ok
        public Lojista lojista { get; set; }//1:N  ✓  ok 
    }
    
}