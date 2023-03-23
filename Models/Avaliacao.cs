using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EntregaRapida.Models.Enum{
    public class Avaliacao{
        private string mensagem;
        private int AvaliacaoId { get; set; }

        [EnumDataType(typeof(Satisfacao))]
        private Satisfacao _satisfacao { get; set; }
        private Entregador _entregador { get; set; }
        private Lojista _lojista { get; set; }

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