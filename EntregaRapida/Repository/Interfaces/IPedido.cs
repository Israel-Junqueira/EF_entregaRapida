using EntregaRapida.Models;

namespace EntregaRapida.Repository.Interfaces
{
    public interface IPedido
    {
        public List<Pedido> Lista_de_Pedidos_Pendentes_DoEntregador_logado(string UserName);
        public List<Pedido> Lista_de_Pedidos_Pendentes_Para_Entregador();
        public Pedido BuscarPedido { get; set;}

    }
}
