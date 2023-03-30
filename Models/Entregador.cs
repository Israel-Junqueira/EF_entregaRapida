using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntregaRapida.Models.Enum;

namespace EntregaRapida.Models
{
    public class Entregador{
        
       
        public int EntregadorId { get; set; }
       [Required]
        private string _nome ;
        [Required]
        private string _endereco ;
        [Required]
        [MaxLength(3,ErrorMessage="Em que pais você mora? o ddd nao pode ter mais de 3 digitos"),MinLength(1,ErrorMessage="Em que pais você mora? Insira no minimo um ddd")]
        private string _DDD;
        [Required]
        [MaxLength(9),MinLength(8)]
        private string _telefone ;
        private int _pontuacao ;
        private int _numeroEntrega;
        [Required]
        [MaxLength(11),MinLength(11)]
        public string CNH { get; set; }
        
        //chaves estrangeitas
        [EnumDataType(typeof(Veiculo))] //1:1 OK
        public Veiculo veiculo {get;set;}
        [EnumDataType(typeof(Modalidade))] //1:1 ok
        public Modalidade modalidade {get;set;}
        public int PlataformaId { get; set; }
        //Relacionamento
        
        public Plataforma plataforma; //N:1 ok
        public virtual List<Avaliacao> avaliacao { get; set; }//1:N  falta fazer
        public virtual List<Historico> historico{get;set;} //1:N  ok
        public virtual List<Pedido> pedido { get; set; }//1:N  ok

    }


}