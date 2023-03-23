namespace EntregaRapida.Models.Enum{
    public class Notificacao{
         private int NotificacaoId { get; set; }
        public DateTime date { get; set; }
        public string mensagem { get; set; }

        public Lojista lojista { get; set; }

        public Pedido pedido { get; set; }
    }

}