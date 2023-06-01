using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaRapida.Models.Enum
{
    public class Historico
    {
      
        public int HistoricoId { get; set; }
        public DateTime date { get; set; }

        //chaves estrangeiras
        public int EntregadorId { get; set; }
        public int LojistaId { get; set; }
        //relacionamentos
        public Entregador entregador { get; set; } //1:N  ✓ok
        public Lojista lojista { get; set; } //1:N  ✓ ok
      //  public virtual List<Pedido> pedido { get; set; } //1:N  ✓ ok Cancelei por Hora
    }
}