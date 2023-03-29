using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntregaRapida.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace EntregaRapida.Models
{
    public class Entregador{
        
        [Key]
        private int Identregador { get; set; }
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
        

        //enum 
        //1:1 fata por no dbContext
        [EnumDataType(typeof(Veiculo))] //1:1 OK
        public Veiculo veiculo {get;set;}

        [EnumDataType(typeof(Modalidade))] //1:1 ok
        public Modalidade modalidade {get;set;}
        //fim enuns 

        //classe 
        public List<Historico> historico{get;set;} //1:N  ok

        [ForeignKey("IdAvaliacao")] //1:N  falta fazer
        public virtual ICollection<Avaliacao> avaliacao { get; set; }

        public List<Pedido> pedido { get; set; }//1:N  ok
        //fim classes
        
        public int Idplataforma { get; set; }
        [ForeignKey("Idplataforma")]
        public Plataforma plataforma; //1:N ok
        public Entregador()
        {
            
        }

        public int NumeroEntrega //propriedades custumizadas
        {
            get { return NumeroEntrega; }
           
        } 

        public string GetNome{
             get {return _nome;}
             set {_nome = value;}
        }

        
        
        public int GetNumeroPontuacao{
            get {return _pontuacao;} 
        }
        
      
        public int GetNumeroEntregas
        {
            get { return _numeroEntrega; }
        }
        
      
        //metodos
        public void SetNome(string nome){
            this._nome = nome;
        }

        public void SetPontuacao(Satisfacao satisfacao){
            this._pontuacao = Convert.ToInt32(satisfacao);
        }

        public void SetNumeroEntregas(int NumEntregas){
            this._numeroEntrega = NumEntregas;
        }
        

    }


}