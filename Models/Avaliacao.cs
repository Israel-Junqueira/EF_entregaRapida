using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaRapida.Models.Enum{
    public class Avaliacao{
        private string _mensagem;
        [Key]
        private int IdAvaliacao{ get; set; }

        [EnumDataType(typeof(Satisfacao))] // ✓  falta por no dbcontext
        private Satisfacao _satisfacao { get; set; } //1:1  ✓  falta por no dbcontext
        [ForeignKey("Identregador")]
        private Entregador _entregador { get; set; } //1:N  ✓  falta por no dbcontext

        [ForeignKey("Idlojista")]
        private Lojista _lojista { get; set; } //1:N  ✓  falta por no dbcontext

        public Avaliacao(Satisfacao satisfacao,Entregador entregador,Lojista lojista)
        {
            this._satisfacao = satisfacao;
            this._entregador = entregador;
            this._lojista = lojista;
            
        }

        
        public void Pontuacao( Satisfacao satisfacao){
           
            this._entregador.SetPontuacao(satisfacao); 

        }
        
        public void NumeroDeEntregas(int NumeroDeEntregas)
        {
                this._entregador.SetNumeroEntregas(NumeroDeEntregas);
        }
    }


}