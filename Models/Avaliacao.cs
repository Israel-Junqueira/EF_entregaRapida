using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaRapida.Models.Enum{
    public class Avaliacao{
        public string _mensagem;
        [Key]
        public int IdAvaliacao{ get; set; }

        [EnumDataType(typeof(Satisfacao))] // ✓  ok
        public Satisfacao satisfacao { get; set; } //1:1  ✓  ok

        
        public int Identregador { get; set; }
        [ForeignKey("Identregador")]
        public Entregador entregador { get; set; } //1:N  ✓  ok


      
        public int Idlojista { get; set; }
        [ForeignKey("Idlojista")]
        public Lojista lojista { get; set; } //1:N  ✓  ok

        public Avaliacao()
        {
            
        }
        public Avaliacao(Satisfacao satisfacao,Entregador entregador,Lojista lojista)
        {
            this.satisfacao = satisfacao;
            this.entregador = entregador;
            this.lojista = lojista;
            
        }

        
        public void Pontuacao( Satisfacao satisfacao){
           
            this.entregador.SetPontuacao(satisfacao); 

        }
        
        public void NumeroDeEntregas(int NumeroDeEntregas)
        {
                this.entregador.SetNumeroEntregas(NumeroDeEntregas);
        }
    }


}