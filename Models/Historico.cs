using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaRapida.Models.Enum
{
    public class Historico
    {
        [Key]
        private int Idhistorico { get; set; }
        public DateTime date { get; set; }

        public ICollection<Pedido> pedido { get; set; } //1:N  ✓ ok


        [ForeignKey("Identregador")]
        public int Identregador { get; set; }
        public Entregador entregador { get; set; } //1:N  ✓ok


        public int Idlojista { get; set; }
        [ForeignKey("Idlojista")]
        public Lojista lojista { get; set; } //1:1  ✓ ok
    }
}