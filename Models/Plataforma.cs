namespace EntregaRapida.Models{
    public class Plataforma{

        private int Idplataforma { get; set; }
        
        public ICollection<Entregador> entregadores { get; set; }//1:N  ✓  falta por no dbcontext
        public ICollection<Lojista> lojista { get; set; }//1:N  ✓  falta por no dbcontext
        public ICollection<Pedido> pedido { get; set; }//1:N  ✓  falta por no dbcontext
    }
}