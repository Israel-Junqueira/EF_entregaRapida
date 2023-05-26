
using EntregaRapida.Models;
using EntregaRapida.Models.Enum;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;



namespace EntregaRapida.Data
{
    public class Banco : DbContext
    {
    public Banco(DbContextOptions<Banco>options): base(options){}
   
  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=projetoef;Uid=root;Pwd=;");
           
    }

        public DbSet<Avaliacao>Avaliacoes { get; set; }
        public DbSet<Entregador>Entregadores { get; set; }
        public DbSet<Historico>Historicos { get; set; }
        public DbSet<Lojista>Lojistas { get; set; }
        public DbSet<Notificacao>Notificacoes { get; set; }
        public DbSet<Pagamento> pagamentos  { get; set; }
        public DbSet<Pedido>Pedidos { get; set; }
        public DbSet<Plataforma>Plataformas { get; set; }
       // public DbSet<IdentityUser> IdentityUser { get; set; }
        
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            

            modelBuilder.Entity<Entregador>()
            .ToTable("Entregadores")
            .HasKey(p => p.EntregadorId);   
            modelBuilder.Entity<Entregador>()
            .Property(n => n.Nome)
            .HasColumnName("Nome");
            modelBuilder.Entity<Entregador>()
            .Property(n => n.Endereco)
            .HasColumnName("Endereco");
            modelBuilder.Entity<Entregador>()
            .Property(n => n.Celular)
            .HasColumnName("Celular");
             modelBuilder.Entity<Entregador>()
            .Property(n => n.DDD)
            .HasColumnName("DDD");
             modelBuilder.Entity<Entregador>()
            .Property(n => n.CNH)
            .HasColumnName("CNH");
            modelBuilder.Entity<Entregador>()
            .Property(n => n.Pontuacao)
            .HasColumnName("Pontuacao");
            modelBuilder.Entity<Entregador>()
            .Property(n => n.Numero_De_Entregas)
            .HasColumnName("Numero_de_Entregas");
               modelBuilder.Entity<Entregador>()
            .Property(n => n.StatusEntregador)
            .HasColumnName("StatusEntregador");
            //ligações das classes entregador
            modelBuilder.Entity<Entregador>()
            .HasMany(s=> s.historico) //Aqui estamos dizendo que a entidade Entregador tem muitos historicos.
            .WithOne(c=> c.entregador) // Aqui estamos dizendo que o historico tem apenas um entregador.
            .HasForeignKey(c=> c.EntregadorId)//Aqui estamos dizendo que a propriedade Identregador no historico é a chave estrangeira ligando-o à entidade de alunos.
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Entregador>()
            .HasMany(s=> s.pedido) 
            .WithOne(c=> c.entregador) 
            .HasForeignKey(c=> c.EntregadorId)
            .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Entregador>()
            .HasMany(s=> s.avaliacao) 
            .WithOne(c=> c.entregador) 
            .HasForeignKey(c=> c.EntregadorId)
            .OnDelete(DeleteBehavior.Cascade);
            //ligação com enum
            modelBuilder.Entity<Entregador>()
            .Property(p=>p.Modalidade)
            .HasConversion(v => v.ToString(),v=>(Modalidade)Enum.Parse(typeof(Modalidade),v));
           
            //ligações das classes Plataforma
            modelBuilder.Entity<Plataforma>()
            .ToTable("Plataforma")
            .HasKey(k=>k.PlataformaId);

            modelBuilder.Entity<Plataforma>()
            .HasMany(s=> s.entregadores) 
            .WithOne(c=> c.plataforma) 
            .HasForeignKey(k=> k.PlataformaId)
            .OnDelete(DeleteBehavior.Cascade);

             modelBuilder.Entity<Plataforma>()
            .HasMany(s=> s.lojista) 
            .WithOne(c=> c.plataforma) 
            .HasForeignKey(c=> c.PlataformaId)
            .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Plataforma>()
            .HasMany(n=> n.notificacao)
            .WithOne(p=>p.Plataforma)
            .HasForeignKey(k=> k.PlataformaId);

            // Mapeando Lojista
            modelBuilder.Entity<Lojista>()
            .ToTable("Lojista")
            .HasKey(k=> k.LojistaId);
            modelBuilder.Entity<Lojista>()
            .Property(n => n.Nome)
            .HasColumnName("Nome");
            modelBuilder.Entity<Lojista>()
            .Property(n => n.Endereco)
            .HasColumnName("Endereco");
            modelBuilder.Entity<Lojista>()
            .Property(n => n.Telefone)
            .HasColumnName("Telefone");
            modelBuilder.Entity<Lojista>()
            .Property(n => n.CNPJ)
            .HasColumnName("CNPJ");
            //Relacionamento Lojista
            //O método HasForeignKey está especificando a chave estrangeira na relação entre as entidades Lojista e Proprietário. A chave estrangeira é definida como o campo ProprietarioId na entidade Proprietario. Isso informa ao Entity Framework que as entidades estão relacionadas e que o ProprietarioId na entidade Proprietario é usado para ligar a entidade Lojista ao proprietário.
            modelBuilder.Entity<Lojista>()
            .HasMany(s=> s.avaliacao) 
            .WithOne(c=> c.lojista) 
            .HasForeignKey(c=> c.LojistaId)
            .OnDelete(DeleteBehavior.Cascade);//O método HasForeignKey é diferente na relação 2 porque estamos lidando com uma relação de muitos para um. Ao especificar o método HasForeignKey, estamos informando ao Entity Framework que cada registro de Histórico tem uma chave estrangeira para a entidade Lojista específica. Esta chave estrangeira é definida como o campo LojistaId no Histórico. Isso informa ao Entity Framework que cada registro de Histórico está relacionado a uma única entidade Lojista.

            modelBuilder.Entity<Lojista>()
            .HasMany(s=> s.historico) 
            .WithOne(c=> c.lojista) 
            .HasForeignKey(k=> k.LojistaId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Lojista>()
            .HasMany(p=>p.pedido)
            .WithOne(l=>l.lojista)
            .HasForeignKey(k=>k.LojistaId)
            .OnDelete(DeleteBehavior.Cascade);   
             modelBuilder.Entity<Lojista>()
            .Property(p=>p.TipoComercio)
            .HasConversion(v => v.ToString(),v=>(TipoComercio)Enum.Parse(typeof(TipoComercio),v));

             //ligações das classes Historico
             modelBuilder.Entity<Historico>()
             .ToTable("Historicos")
             .HasKey(k=> k.HistoricoId);
             
             modelBuilder.Entity<Historico>()
            .HasMany(s=> s.pedido) 
            .WithOne(c=> c.historico) 
            .HasForeignKey(c=> c.HistoricoId)
            .OnDelete(DeleteBehavior.Cascade);

            //ligações das classes notificacao
            modelBuilder.Entity<Notificacao>()
            .ToTable("Notificação")
            .HasKey(k=>k.NotificacaoId);
            modelBuilder.Entity<Notificacao>() //Linha 1: Esta linha esta criando uma entidade chamada Pedido.
            .HasMany(n=>n.pedido)//Linha 2: Esta linha define um relacionamento de um para um entre o Pedido e a Notificação.
            .WithOne(p=>p.notificacao)//Linha 3: Esta linha define o Pedido como a chave estrangeira na Notificação.
            .HasForeignKey(n=>n.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);//Linha 4: Esta linha especifica que ao excluir um pedido, a notificação associada também será excluída.

            //relações da classe pedido
            modelBuilder.Entity<Pedido>()
            .ToTable("pedido")
            .HasKey(k=> k.PedidoId);
            modelBuilder.Entity<Pedido>()
            .HasOne(n=> n.pagamento)
            .WithOne(p=>p.pedido)
            .HasForeignKey<Pagamento>(p=>p.PagamentoId)
            .OnDelete(DeleteBehavior.Cascade);

             modelBuilder.Entity<Pedido>()
            .Property(p=>p.statuspedido)
            .HasConversion(v => v.ToString(),v=>(StatusPedido)Enum.Parse(typeof(StatusPedido),v));
            
            //avaliação
            modelBuilder.Entity<Avaliacao>()
            .ToTable("Avaliacao")
            .HasKey(p => p.AvaliacaoId);
             modelBuilder.Entity<Avaliacao>()
            .Property(p=>p.satisfacao)
            .HasConversion(v => v.ToString(),v=>(Satisfacao)Enum.Parse(typeof(Satisfacao),v));
            modelBuilder.Entity<Avaliacao>()
            .Property(n => n.Mensagem)
            .HasColumnName("Mensagem");
            //Proprietario
        }
     
    
        
    }
}