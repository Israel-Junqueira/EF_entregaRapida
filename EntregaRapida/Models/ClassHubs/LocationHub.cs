using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EntregaRapida.Models.ClassHubs
{
    public class LocationHub : Hub
    {
        public async Task SendLocationUpdate(double latitude, double longitude)
        {
           
            await Clients.All.SendAsync("UpdateLocation", latitude, longitude);
        }
    }
}
