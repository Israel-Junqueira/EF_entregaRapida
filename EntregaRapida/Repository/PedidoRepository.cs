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

        public void Adiciona_entregador_ao_Pedido(int entregadorId,int pedidoId)
        {
            try
            {
                var Pedido = _context.Pedidos.FirstOrDefault(x => x.PedidoId == pedidoId);
                var Entregador = _context.Entregadores.FirstOrDefault(x => x.EntregadorId == entregadorId);

                Pedido.EntregadorId = entregadorId;
                Pedido.EntregadorNome = Entregador.Nome;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
            
            
        }
        public void Muda_Status_do_Pedido(int pedidoId)
        {

            try
            {
                var Pedido = _context.Pedidos.FirstOrDefault(x => x.PedidoId == pedidoId);
                Pedido.statuspedido = Models.Enum.StatusPedido.Preparado;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
          
        }

        public List<Pedido> Lista_de_Pedidos_Pendentes_Para_Entregador()
        {
            return _context.Pedidos.Where(x => x.statuspedido == Models.Enum.StatusPedido.Pendente).ToList();
        }

       

        List<Pedido> IPedido.Lista_de_Pedidos_Do_Lojista(string UserId)
        {
            // var LojistaId = _context.Lojistas.FirstOrDefault(x => x.Idaspnetuser == UserId);
            try
            {
                return _context.Pedidos.Where(x => x.ContextId == UserId && (x.statuspedido == Models.Enum.StatusPedido.Preparado ||
                  x.statuspedido == Models.Enum.StatusPedido.Acaminho || x.statuspedido == Models.Enum.StatusPedido.Paralizado || x.statuspedido == Models.Enum.StatusPedido.Entregue ||
                   x.statuspedido == Models.Enum.StatusPedido.Pendente)).ToList();
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public Pedido GetEnderecoPedido(int PedidoId)
        {
            return _context.Pedidos.FirstOrDefault(x => x.PedidoId == PedidoId);
        }
    }
}
