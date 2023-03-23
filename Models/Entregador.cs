using System.ComponentModel.DataAnnotations;
using EntregaRapida.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace EntregaRapida.Models
{
    public class Entregador{
    
        private int EntregadorId { get; set; }
        private string _nome ;
        private string _endereco ;
        private string _telefone ;
        private int _pontuacao ;
        private int _numeroEntrega;

        //enum veiculo
        [EnumDataType(typeof(Veiculo))]
        public Veiculo veiculo ;
       
         //enum modalidade
        [EnumDataType(typeof(Modalidade))]
        public Modalidade modalidade ;
     
        //classe historico
        public int Idhistorico { get; set; }
        public List<Historico> historico ;

        //classe avaliacao
        public int IdAvaliacao { get; set; }
        public List<Avaliacao> avaliacao { get; set; }

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