namespace EntregaRapida.Models.Enum
{
       public class Historico{
            private int Idhistorico { get; set; }
            public DateTime date { get; set; }
            private Pedido pedido { get; set; }
            private Entregador entregador;
       } 
}