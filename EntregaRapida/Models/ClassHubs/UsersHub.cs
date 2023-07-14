using EntregaRapida.Data;
using EntregaRapida.Models.Enum;
using EntregaRapida.Repository.Interfaces;
using EntregaRapida.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;


namespace EntregaRapida.Models.ClassHubs
{
    public class UsersHub : Hub
    {
        private readonly IHubContext<UsersHub> _hubContext;
        private readonly IMemoryCache _cache;
        private readonly IPedido _pedido;
        private readonly ComercianteService _comercianteService;
        private readonly UserManager<IdentityUser> _usermaneger;
        private readonly Banco _banco;
        public UsersHub(IHubContext<UsersHub> hubContext, IMemoryCache cache,IPedido pedido, ComercianteService comerciante, UserManager<IdentityUser> usermaneger,Banco banco)
        {
            _banco = banco;
            _hubContext = hubContext;
            _cache = cache;
            _pedido = pedido;
            _comercianteService = comerciante;
            _usermaneger = usermaneger;

            if (!_cache.TryGetValue("EntregadoresConectados", out List<EntregadorConectado> entregadoresConectados))
            {
                entregadoresConectados = new List<EntregadorConectado>();
                _cache.Set("EntregadoresConectados", entregadoresConectados);
            }
        }
        // Métodos para gerenciar a conexão e desconexão dos clientes
        public async override Task OnConnectedAsync()
        {

            // Adicionar o cliente a um grupo "Entregadores"
            var userName = Context.User.Identity.Name;
            var ususario = await _usermaneger.FindByNameAsync(userName);
            var roles = await _usermaneger.GetRolesAsync(ususario);
            if (roles.Contains("Entregador"))
            {
                var connectionId = Context.ConnectionId;
                var entregador = new EntregadorConectado { Nome = userName, ConnectionId = connectionId };

                var entregadoresConectados = _cache.Get<List<EntregadorConectado>>("EntregadoresConectados");
                entregadoresConectados.Add(entregador);
                _cache.Set("EntregadoresConectados", entregadoresConectados);
                await Groups.AddToGroupAsync(connectionId, "EntregadoresOnline");


            }
           
            await Clients.Caller.SendAsync("ObterPedidosPendentes");
            await base.OnConnectedAsync();
            await GetEntregadoresOnline();

        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            var entregadoresConectados = _cache.Get<List<EntregadorConectado>>("EntregadoresConectados");
            var entregadoresDesconectados = entregadoresConectados.FirstOrDefault(e => e.ConnectionId == Context.ConnectionId);

            if (entregadoresDesconectados != null)
            {
                // remove o entregador desconectado da lista
                entregadoresConectados.Remove(entregadoresDesconectados);
                _cache.Set("EntregadoresConectados", entregadoresConectados);

                // remove o entregador do grupo EntregadoresOnline
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "EntregadoresOnline");

                // envia a lista atualizada de entregadores online para os clientes
                await GetEntregadoresOnline();
            }

            await base.OnDisconnectedAsync(exception);
        }
        public async Task GetEntregadoresOnline()
        {
            var entregadoresConectados = _cache.Get<List<EntregadorConectado>>("EntregadoresConectados");
            var entregadores = entregadoresConectados.Select(e => e.Nome).ToList();
            await Clients.All.SendAsync("EntregadoresOnline", entregadores);
        }

        public async Task ObterPedidosPendentes()
        {
             List<Pedido> pedidosPendetes = _pedido.Lista_de_Pedidos_Pendentes_Para_Entregador();
            await Clients.Group("EntregadoresOnline").SendAsync("ReceberPedidosPendentes", pedidosPendetes);
          
        }

        public async Task AvisaEntregadorPedidoAceito(string idEntregador, int idPedido, string idLojista)
        {
            string mensagem = $"Solicitação do pedido[{idPedido}] foi aceita, Iniciar Corrida com google maps ?";
             await Clients.User(idEntregador).SendAsync("solicitacaoAceita", mensagem ,idLojista, idPedido);
        }

        public async Task ReceberPedido(Pedido pedido)
        {
            await Clients.Group("EntregadoresOnline").SendAsync("ReceberPedido", pedido);
        }

     
        public async Task EnviarSolicitacaoEntrega(string Entregador, string lojista, string mensagem, int pedidoId)
        {
            try
            {
                var solicitacao = _banco.solicitacoes.FirstOrDefault(x => x.EntregadorNome == Entregador && x.pedidoId == pedidoId);
                await Clients.User(lojista).SendAsync("RecebeParametros", Entregador, lojista, mensagem, pedidoId, solicitacao);
            }
            catch (Exception)
            {

                throw;
            }
            

           
        }
    }
}
