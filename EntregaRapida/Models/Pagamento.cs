using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntregaRapida.Models{
    public class Pagamento{
       
        public int PagamentoId { get; set; }
        private double Preco { get; set; }
        public DateTime date { get; set; }

      //  public int PedidoId { get; set; }
       // public Pedido pedido { get; set; } //ok

    }
}