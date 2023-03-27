using EntregaRapida.Models;
using EntregaRapida.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace EFENTREGARAPIDA.Data
{
    public class Banco : DbContext
    {
     public Banco(DbContextOptions<Banco> options) : base(options)
    {
        //o restando das configurações estao na appsettings que é a string de conexao e o na program
    }
        public DbSet<Avaliacao>Avaliacoes { get; set; }
        public DbSet<Entregador>Entregadores { get; set; }
        public DbSet<Historico>Historicos { get; set; }
        public DbSet<Lojista>Lojistas { get; set; }
        public DbSet<Notificacao>Notificacoes { get; set; }
        public DbSet<Pagamento> pagamentos  { get; set; }
        public DbSet<Pedido>Pedidos { get; set; }
        public DbSet<Plataforma>Plataformas { get; set; }
        public DbSet<Proprietario>Proprietarios { get; set; }
        
        /*
        preciso colocar os enums aq ??

        public DbSet<Modalidade>Modalidades { get; set; }
        public DbSet<Satisfacao>Satisfacao { get; set; }
        public DbSet<StatusPedido>StatusPedidos { get; set; }
        public DbSet<TipoComercio>TipoComercios { get; set; }        
        public DbSet<Veiculo>Veiculos { get; set; }
        */
        
    }
}