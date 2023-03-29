using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntregaRapida.Models.Enum{
    public class Notificacao{
        [Key]
        private int Idnotificacao { get; set; }
        public DateTime date { get; set; }
        public string mensagem { get; set; }
        public int Idlojista { get; set; }
        [ForeignKey("Idlojista")]
        public Lojista lojista { get; set; } //1:1  ✓ ok

        public int Idpedido { get; set; }
        [ForeignKey("Idpedido")]
        public Pedido pedido { get; set; }  //1:1  ✓ ok
    }

}