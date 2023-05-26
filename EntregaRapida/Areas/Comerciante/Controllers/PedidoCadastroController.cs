using EntregaRapida.Data;
using EntregaRapida.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EntregaRapida.Repository.Interfaces;

namespace EntregaRapida.Areas.Comerciante.Controllers
{
    [Area("Comerciante")]
    [Authorize("Lojista")]
    public class PedidoCadastroController : Controller
    {
        private readonly Banco _context;
        private readonly ILojistas _lojistas;
        public PedidoCadastroController(Banco context,ILojistas lojista)
        {
            _context = context;
            _lojistas = lojista;
            
        }
        [HttpGet]
        [Route("PedidoCadastroController/")]
        [Route("PedidoCadastroController/Index")]
        public IActionResult Index()
        {
            var usuarioLogado = User.Identity.Name;
            var usuarioTotal = _lojistas.Endereco_lojista(usuarioLogado);
            ViewData["UsuarioEndereco"] = usuarioTotal.Endereco;
            ViewData["LojistaId"] = usuarioTotal.LojistaId;
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarPedido(Pedido pedido)
        {
            
            return View();
        }
    }
}
