using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EntregaRapida.Models.Enum;

namespace EntregaRapida.Models{
    public class Lojista{
       
        public int LojistaId { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string endereco { get; set; }
        [Required]
        public string telefone { get; set; }
        [Required]
        public string cnpj { get; set; }

        //chaves estrangeiras
        [EnumDataType(typeof(TipoComercio))] // 1:1 ✓  ok
        public TipoComercio tipocomercio { get; set; }
        public int ProprietarioId { get; set; }
        public int PlataformaId { get; set; }
        //Relacionamentos
        public Plataforma plataforma { get; set; }
        public Proprietario proprietario { get; set; } //1:1  ✓  ok
        public virtual List<Historico> historico { get; set; } //1:N  ✓  ok
        public virtual List<Avaliacao> avaliacao { get; set; }//1:N  ✓  ok
        public virtual List<Pedido> pedido { get; set; }// 1:N ✓ ok

        [NotMapped]
        public string GetNome
        {
            get { return nome; }
            set { nome = value; }
        }

        //atributos privados
        //propriedades autoimplementadas
        //Construtores
        //Propriedades customizadas
        //outros metodos da classe
        
    }
}