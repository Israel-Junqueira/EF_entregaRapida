using System.ComponentModel.DataAnnotations;
namespace EntregaRapida.Models{
    public class Plataforma{

        [Key]
        private int Idplataforma { get; set; }
        
        public virtual ICollection<Entregador> entregadores { get; set; }//1:N  ✓  falta por no dbcontext
        public virtual ICollection<Lojista> lojista { get; set; }//1:N  ✓  falta por no dbcontext
        public virtual ICollection<Pedido> pedido { get; set; }//1:N  ✓  falta por no dbcontext
    }
}