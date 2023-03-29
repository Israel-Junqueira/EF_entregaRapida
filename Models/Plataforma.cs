using System.ComponentModel.DataAnnotations;
namespace EntregaRapida.Models{
    public class Plataforma{

        [Key]
        public int Idplataforma { get; set; }
        
        public virtual ICollection<Entregador> entregadores { get; set; }//1:N  ✓  ok
        public virtual ICollection<Lojista> lojista { get; set; }//1:N  ✓  ok
        public virtual ICollection<Pedido> pedido { get; set; }//1:N  ✓  ok
    }
}