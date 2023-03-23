namespace EntregaRapida.Models{
    public class Plataforma{
         private int PlataformaId { get; set; }
        public Entregador entregadores { get; set; }
        public Lojista lojista { get; set; }
        public Pedido pedido { get; set; }
    }
}