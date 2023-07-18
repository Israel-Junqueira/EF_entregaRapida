using EntregaRapida.Models.Enum;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntregaRapida.Models{

    public class Pedido 
    {
     
        public int PedidoId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Insira o numero da residência")]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Insira apenas números.")]
        [NotMapped]
        [Required(ErrorMessage = "Insira o numero da residência")]
        [Display(Name = "Numero")]
        public string numeroImovel { get; set; }
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public DateTime date { get; set; }
        [NotMapped]
        public string enderecoCompleto { get; set; }
        [Required(ErrorMessage = "Está faltando o endereço")]
        [Display(Name = "Meu endereço")]
        public string enderecoOrigem { get; set; }

        [Required(ErrorMessage ="Insira anotações importantes para auxiliar o entregador")]
        [Display(Name = "Anotações extras.. ")]
        public string descricao { get; set; }
        [Required(ErrorMessage = "Endereço invalido")]
        [Display(Name = "Endereço do cliente")]
        public string enderecoDestino { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public double distancia { get; set; }

        [EnumDataType(typeof(StatusPedido))]    
        public StatusPedido statuspedido { get; set; } //  ✓ ok
        public int? EntregadorId { get; set; }
        public string EntregadorNome { get; set; }
        public string ContextId { get; set; } //testando
        public int LojistaId { get; set; }
        public string LojistaNome { get; set; }
      

        //  public int HistoricoId { get; set; } cancelei por hora historico aqui para refazer a ligação depois
        //   public Historico historico { get; set; } //1:N  ✓ ok
        public Entregador entregador { get; set; } //1:1  ✓ ok
        public Lojista lojista { get; set; }//1:N  ✓  ok 

        //public int PagementoId { get; set; } cancelei por hora pois nao e momento de trabalhar com essa tabela

        // public int NotificacaoId { get; set; }

        // public Notificacao notificacao { get; set; }//1:1  ✓ tabela desativada

        // public Pagamento pagamento{ get; set; }//1:1  ✓  cancelei por hora pois nao e momento de trabalhar com essa tabela

    }
    
}