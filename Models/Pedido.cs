using EntregaRapida.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntregaRapida.Models{

    public class Pedido{
        [Key]
        private int Idpedido { get; set; }
        public string enderecoOrigem { get; set; }
        public string enderecoDestino { get; set; }
        public double distancia { get; set; }
        public DateTime date { get; set; }

        //chaves estrangeiras 

        [ForeignKey("Identregador")]
        public int Identregador { get; set; }
        public Entregador entregador { get; set; } //1:1  ✓ ok

        [ForeignKey("Idlojista")]
        public int Idlojista { get; set; }    
        public Lojista lojista { get; set; }//1:N  ✓ ok

        [ForeignKey("Idpagamento")]
        public int Idpagemento { get; set; }
        public Pagamento pagamento{ get; set; }//1:1  ✓ ok

        public int Idnotificacao { get; set; }
        [ForeignKey("Idnotificacao")]
        public Notificacao notificacao { get; set; }//1:1  ✓ ok

        [ForeignKey("Idplataforma")]
        public int Idplataforma { get; set; }
        public Plataforma plataforma  { get; set; }//1:N  ✓  ok
        //fim

        //enums
        [EnumDataType(typeof(StatusPedido))]    
        public StatusPedido statuspedido { get; set; } //  ✓ ok

        [ForeignKey("Idhistorico")]
        public int Idhistorico { get; set; }
        public Historico historico { get; set; }   //1:N  ✓ ok
        
    

       
       
    }
    
}