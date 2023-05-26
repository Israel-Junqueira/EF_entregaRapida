using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;

namespace EntregaRapida.Models.ClassHubs
{
    public class UsersHub : Hub
    {
        private readonly IHubContext<UsersHub> _hubContext;
        private readonly IMemoryCache _cache;
        public UsersHub(IHubContext<UsersHub> hubContext, IMemoryCache cache)
        {
            _hubContext = hubContext;
            _cache = cache;
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
            var connectionId = Context.ConnectionId;
            var entregador = new EntregadorConectado { Nome = userName,ConnectionId = connectionId };

            var entregadoresConectados = _cache.Get<List<EntregadorConectado>>("EntregadoresConectados");
            entregadoresConectados.Add(entregador);
            _cache.Set("EntregadoresConectados", entregadoresConectados);
            await Groups.AddToGroupAsync(connectionId, "EntregadoresOnline");
            await GetEntregadoresOnline();

            await base.OnConnectedAsync();
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


    }
}
