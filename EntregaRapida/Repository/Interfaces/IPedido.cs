using EntregaRapida.Models;

namespace EntregaRapida.Repository.Interfaces
{
    public interface IPedido
    {
        public List<Pedido> Lista_de_Pedidos_Do_Lojista(string UserName);
        public List<Pedido> Lista_de_Pedidos_Pendentes_Para_Entregador();
        public void Muda_Status_do_Pedido(int pedidoId);
        public void Adiciona_entregador_ao_Pedido(int entregadorId,int pedidoId);
        public Pedido BuscarPedido { get; set;}
        public Pedido GetEnderecoPedido(int PedidoId);

    }
}
