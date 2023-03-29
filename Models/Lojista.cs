using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EntregaRapida.Models.Enum;

namespace EntregaRapida.Models{
    public class Lojista{
        [Key]
        public int Idlojista { get; set; }
        [Required]
        private string nome { get; set; }
        [Required]
        private string endereco { get; set; }
        [Required]
        private string telefone { get; set; }
        [Required]
        private string cnpj { get; set; }
        //enums
        [EnumDataType(typeof(TipoComercio))] // 1:1 ✓  ok
        public TipoComercio tipocomercio { get; set; }

        //class relacionamentos estranjeitos
        public List<Pedido> pedido { get; set; }// 1:N ✓ ok
        
        [ForeignKey("Idproprietario")]
        public int Idproprietario { get; set; }
        public Proprietario proprietario { get; set; } //1:1  ✓  ok

        public virtual List<Historico> historico { get; set; } //1:N  ✓  ok

        private int Idnotificacao { get; set; }
        [ForeignKey("Idnotificacao")]
        public Notificacao notificacao { get; set; } //1:1  ✓  ok

        public virtual List<Avaliacao> avaliacao { get; set; }//1:N  ✓  ok

        [ForeignKey("Idplataforma")]
        public int Idplataforma { get; set; }
        public Plataforma plataforma { get; set; }//1:N  ✓  ok

    public Lojista(List<Historico> historico)
    {
        this.historico = historico;
    }
    public Lojista(string name, string endereco,string telefone,string cnpj,TipoComercio tipo, Proprietario proprietario)
    {
        this.nome = name;
        this.endereco = endereco;
        this.telefone = telefone;
        this.cnpj = cnpj;
        this.tipocomercio = tipo;
        this.proprietario = proprietario;
    }

    }
}