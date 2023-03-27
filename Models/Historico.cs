using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaRapida.Models.Enum
{
       public class Historico{
            [Key]
            private int Idhistorico { get; set; }
            public DateTime date { get; set; }
           
            [ForeignKey("Idpedido")]
            private Pedido pedido { get; set; } //1:1  ✓ falta fazer o dbContext
            
            [ForeignKey("Identregador")]
            private Entregador entregador; //1:N  ✓ falta fazer o dbContext
            
            [ForeignKey("Idlojista")]
            private Lojista lojista { get; set; } //1:1  ✓ falta fazer o dbContext
       } 
}