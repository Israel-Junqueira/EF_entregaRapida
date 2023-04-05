using EntregaRapida.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaRapida.Models
{
    public class Plataforma
    {
        public int PlataformaId { get; set; }
        
        public virtual List<Entregador> entregadores { get; set; }//1:N  ✓  ok
        public virtual List<Lojista> lojista { get; set; }//1:N  ✓  ok
        public virtual List<Notificacao> notificacao { get; set; }
    }
}