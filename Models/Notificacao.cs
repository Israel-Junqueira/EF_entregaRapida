using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntregaRapida.Models{
    public class Notificacao{
       
        public int NotificacaoId { get; set; }
        public DateTime date { get; set; }
        public string mensagem { get; set; }
        //chaves estrangeiras
        public int PlataformaId { get; set; }
        public int PedidoId { get; set; }
        public List<Pedido> pedido { get; set; }  //1:1  ✓ ok
        public Plataforma Plataforma { get; set; } //1:N ok
    }

}