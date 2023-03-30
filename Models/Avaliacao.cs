using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaRapida.Models.Enum{
    public class Avaliacao{
     
    
        public int AvaliacaoId { get; set; }
        public string Mensagem;

   
        // Chaves estrangeiras 
        public int EntregadorId { get; set; }
        public int LojistaId { get; set; }
        //Relacionamento
        public Entregador entregador { get; set; } //1:N  ✓  ok
        public Lojista lojista { get; set; } //1:N  ✓  ok
        [EnumDataType(typeof(Satisfacao))] 
        public Satisfacao satisfacao { get; set; } //1:1  ✓  ok

    }


}