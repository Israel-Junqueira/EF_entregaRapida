namespace EntregaRapida.Services
{
    public class ComercianteService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ComercianteService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string ObterComercianteIdDoHttpContext()
        {
            // Lógica para obter o ID do comerciante do HttpContext
            string comercianteId = _httpContextAccessor.HttpContext.User.FindFirst("ComercianteId")?.Value;

            return comercianteId;
        }
    }
}
