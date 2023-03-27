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
        public Entregador entregador { get; set; } //1:1  ✓ Falta o dbContext

        [ForeignKey("Idlojista")]
        public Lojista lojista { get; set; }//1:1  ✓ Falta o dbContext

        [ForeignKey("Idpagamento")]
        public Pagamento pagamento{ get; set; }//1:1  ✓ Falta o dbContext

        [ForeignKey("Idnotificacao")]
        public Notificacao notificacao { get; set; }//1:1  ✓ Falta o dbContext

        [ForeignKey("Idplataforma")]
        public Plataforma plataforma  { get; set; }//1:N  ✓  falta por no dbcontext
        //fim

        //enums
        [EnumDataType(typeof(StatusPedido))]    
        public StatusPedido statuspedido { get; set; } //  ✓ Falta o dbContext

        [ForeignKey("Idhistorico")]
        public Historico historico { get; set; }   //1:1  ✓ Falta o dbContext
        
    

       
       
    }
    
}