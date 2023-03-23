using EntregaRapida.Models.Enum;
namespace EntregaRapida.Models{

    public class Pedido{
        private int PedidoId { get; set; }
        public string enderecoOrigem { get; set; }
        public string enderecoDestino { get; set; }
        public double distancia { get; set; }
        public DateTime date { get; set; }
        public StatusPedido statuspedido { get; set; }

        public Entregador entregador { get; set; }
        public Lojista lojista { get; set; }

        public Pagamento pagamento{ get; set; }
        public Notificacao notificacao { get; set; }

    }
    
}