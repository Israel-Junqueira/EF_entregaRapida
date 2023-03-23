using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntregaRapida.Models;

namespace EntregaRapida.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
       Entregador e1 = new Entregador();
       e1.GetNome = "dimi";
        return View(e1);
    }

    public IActionResult Privacy()
    {
        return View();
    }



}
