using EntregaRapida.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntregaRapida.Models{

    public class Pedido{

        [NotMapped]
        [Required]
        [Display(Name = "Numero")]
        public int numeroImovel { get; set; }

        [NotMapped]
        public string enderecoCompleto { get; set; }
        public int PedidoId { get; set; }

        [Display(Name = "Meu endereço")]
        public string enderecoOrigem { get; set; }

        [Display(Name = "Anotações extras.. ")]
        public string descricao { get; set; }
        [Display(Name = "Endereço do cliente")]
        public string enderecoDestino { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public double distancia { get; set; }
        [Display(Name = "Data ")]
        public DateTime date { get; set; }

        [EnumDataType(typeof(StatusPedido))]    
        public StatusPedido statuspedido { get; set; } //  ✓ ok
        public int? EntregadorId { get; set; }
        public string? EntregadorNome { get; set; }
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