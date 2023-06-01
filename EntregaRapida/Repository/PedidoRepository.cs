using EntregaRapida.Data;
using EntregaRapida.Models;
using EntregaRapida.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EntregaRapida.Repository
{
    public class PedidoRepository : IPedido
    {
        private readonly Banco _context;
        private readonly UserManager<IdentityUser> _userManager;
        public PedidoRepository(Banco _context,UserManager<IdentityUser> userManager)
        {
            this._context = _context;
            this._userManager = userManager;
        }
        public Pedido BuscarPedido { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<Pedido> Lista_de_Pedidos_Pendentes_Para_Entregador()
        {
            return _context.Pedidos.Where(x => x.statuspedido == Models.Enum.StatusPedido.Pendente).ToList();
        }

        List<Pedido> IPedido.Lista_de_Pedidos_Pendentes_DoEntregador_logado(string UserName)
        {
            return _context.Pedidos.Where(x => x.statuspedido == Models.Enum.StatusPedido.Pendente && x.LojistaNome == UserName).ToList();
        }
    }
}
