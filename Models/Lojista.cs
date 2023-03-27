using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EntregaRapida.Models.Enum;

namespace EntregaRapida.Models{
    public class Lojista{
        [Key]
        private int Idlojista { get; set; }
        [Required]
        private string nome { get; set; }
        [Required]
        private string endereco { get; set; }
        [Required]
        private string telefone { get; set; }
        [Required]
        private string cnpj { get; set; }

        //class relacionamentos estranjeitos
        [ForeignKey("Idpedido")] // 1:1 ✓ falta por no dbContext
        public Pedido pedido { get; set; }

        [EnumDataType(typeof(TipoComercio))] // 1:1 ✓  falta por no dbContext
        public TipoComercio tipocomercio { get; set; }
        
        [ForeignKey("Idproprietario")]
        public Proprietario proprietario { get; set; } //1:1  ✓  falta por no dbcontext

        public virtual List<Historico> historico { get; set; } //1:N  ✓  falta por no dbcontext

        [ForeignKey("Idnotificacao")]
        public Notificacao notificacao { get; set; } //1:1  ✓  falta por no dbcontext

        public virtual List<Avaliacao> avaliacao { get; set; }//1:N  ✓  falta por no dbcontext

        [ForeignKey("Idplataforma")]
        public Plataforma plataforma { get; set; }//1:N  ✓  falta por no dbcontext

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