using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntregaRapida.Models{
    public class Pagamento{
        [Key]
         private int Idpagamento { get; set; }
        private double Preco { get; set; }
        public DateTime date { get; set; }
        public int Idpedido { get; set; }
        [ForeignKey("Idpedido")]
        public Pedido pedido { get; set; }

    }
}