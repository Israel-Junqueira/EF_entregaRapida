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
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
          

            //relacionamentos dos enum da classe entregador entregador
            modelBuilder.Entity<Entregador>()
            .Property(v => v.veiculo)
            .HasColumnType("int");
            modelBuilder.Entity<Entregador>()
            .Property(v => v.modalidade)
            .HasColumnType("int");

            //ligações das classes entregador
            modelBuilder.Entity<Entregador>()
            .HasMany(s=> s.historico) //Aqui estamos dizendo que a entidade Entregador tem muitos historicos.
            .WithOne(c=> c.entregador) // Aqui estamos dizendo que o historico tem apenas um entregador.
            .HasForeignKey(c=> c.Identregador)//Aqui estamos dizendo que a propriedade Identregador no historico é a chave estrangeira ligando-o à entidade de alunos.
            .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Entregador>()
            .HasMany(s=> s.pedido) 
            .WithOne(c=> c.entregador) 
            .HasForeignKey(c=> c.Identregador)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Entregador>()
            .HasMany(s=> s.avaliacao) 
            .WithOne(c=> c.entregador) 
            .HasForeignKey(c=> c.Identregador)
            .OnDelete(DeleteBehavior.Cascade);

             //ligações das classes Plataforma
            modelBuilder.Entity<Plataforma>()
            .HasMany(s=> s.entregadores) 
            .WithOne(c=> c.plataforma) 
            .HasForeignKey(c=> c.Idplataforma)
            .OnDelete(DeleteBehavior.Cascade);

             modelBuilder.Entity<Plataforma>()
            .HasMany(s=> s.lojista) 
            .WithOne(c=> c.plataforma) 
            .HasForeignKey(c=> c.Idplataforma)
            .OnDelete(DeleteBehavior.Cascade);
            
             modelBuilder.Entity<Plataforma>()
            .HasMany(s=> s.pedido) 
            .WithOne(c=> c.plataforma) 
            .HasForeignKey(c=> c.Idplataforma)
            .OnDelete(DeleteBehavior.Cascade);

             //ligações das classes Lojista
            // 1:N
            modelBuilder.Entity<Lojista>()
            .HasMany(s=> s.avaliacao) 
            .WithOne(c=> c.lojista) 
            .HasForeignKey(c=> c.Idlojista)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Lojista>()
            .HasMany(s=> s.historico) 
            .WithOne(c=> c.lojista) 
            .HasForeignKey(c=> c.Idlojista)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Lojista>()
            .HasMany(p=>p.pedido)
            .WithOne(l=>l.lojista)
            .HasForeignKey(f=>f.Idlojista)
            .OnDelete(DeleteBehavior.Cascade);
            //1:1
            modelBuilder.Entity<Lojista>()
            .HasOne(n=>n.notificacao)
            .WithOne(l=>l.lojista)
            .HasForeignKey<Notificacao>(n=>n.Idlojista)
            .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Lojista>()
            .HasOne(n=>n.proprietario)
            .WithOne(l=>l.lojista)
            .HasForeignKey<Notificacao>(n=>n.Idlojista)
            .OnDelete(DeleteBehavior.Cascade);

            //ligações dos enum das classes Lojista
            modelBuilder.Entity<Lojista>()
            .Property(v => v.tipocomercio)
            .HasColumnType("int");

             //ligações das classes Historico
             modelBuilder.Entity<Historico>()
            .HasMany(s=> s.pedido) 
            .WithOne(c=> c.historico) 
            .HasForeignKey(c=> c.Idhistorico)
            .OnDelete(DeleteBehavior.Cascade);

            //ligações das classes notificacao
            modelBuilder.Entity<Notificacao>() //Linha 1: Esta linha esta criando uma entidade chamada Pedido.
            .HasOne(n=>n.pedido)//Linha 2: Esta linha define um relacionamento de um para um entre o Pedido e a Notificação.
            .WithOne(p=>p.notificacao)//Linha 3: Esta linha define o Pedido como a chave estrangeira na Notificação.
            .HasForeignKey<Pedido>(n=>n.Idnotificacao)
            .OnDelete(DeleteBehavior.Cascade);//Linha 4: Esta linha especifica que ao excluir um pedido, a notificação associada também será excluída.

            modelBuilder.Entity<Pedido>()
            .Property(v => v.statuspedido)
            .HasColumnType("int");

            modelBuilder.Entity<Pedido>()
            .HasOne(n=> n.pagamento)
            .WithOne(p=>p.pedido)
            .HasForeignKey<Pedido>(p=>p.Idpagemento)
            .OnDelete(DeleteBehavior.Cascade);
            //avaliação
              modelBuilder.Entity<Avaliacao>()
            .Property(v => v.satisfacao)
            .HasColumnType("int");
        }
     

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