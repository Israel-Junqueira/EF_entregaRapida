using EntregaRapida.Models;

namespace EntregaRapida.Repository.Interfaces
{
    public interface IPedido
    {
        public List<Pedido> Lista_de_Pedidos { get; }
        public Pedido BuscarPedido { get; set;}

    }
}
