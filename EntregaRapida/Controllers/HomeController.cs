using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntregaRapida.Models;
using Microsoft.AspNetCore.SignalR;
using EntregaRapida.Models.ClassHubs;
using Microsoft.Extensions.Caching.Memory;

namespace EntregaRapida.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHubContext<UsersHub> _hubContext;
    private readonly IMemoryCache _cache;
    private readonly List<EntregadorConectado> _entregadoresConectados;
    public HomeController(ILogger<HomeController> logger, IHubContext<UsersHub> hubContext, IMemoryCache cache)
    {
        _logger = logger;
        _hubContext = hubContext;
        _cache = cache;
        _entregadoresConectados = new List<EntregadorConectado>();
    }

    public async Task<IActionResult> Index()
     {
        var entregadoresConectados = _entregadoresConectados;

        return View(entregadoresConectados);
    }


    public IActionResult Privacy()
    {
        return View();
    }



}
