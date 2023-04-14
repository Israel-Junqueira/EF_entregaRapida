using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TabelasIdentity.Identity.Data
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext>options):base(options){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=projetoef;Uid=root;Pwd=;", b => b.MigrationsAssembly("EntregaRapida"));
        }
                  
    }
}