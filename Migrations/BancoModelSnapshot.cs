﻿// <auto-generated />
using System;
using EntregaRapida.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntregaRapida.Migrations
{
    [DbContext(typeof(Banco))]
    partial class BancoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntregaRapida.Models.Entregador", b =>
                {
                    b.Property<int>("EntregadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CNH")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("CNH");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Celular");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)")
                        .HasColumnName("DDD");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Endereco");

                    b.Property<string>("Modalidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Nome");

                    b.Property<int>("Numero_De_Entregas")
                        .HasColumnType("int")
                        .HasColumnName("Numero_de_Entregas");

                    b.Property<int>("PlataformaId")
                        .HasColumnType("int");

                    b.Property<int>("Pontuacao")
                        .HasColumnType("int")
                        .HasColumnName("Pontuacao");

                    b.Property<bool>("StatusEntregador")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("StatusEntregador");

                    b.HasKey("EntregadorId");

                    b.HasIndex("PlataformaId");

                    b.ToTable("Entregadores", (string)null);
                });

            modelBuilder.Entity("EntregaRapida.Models.Enum.Avaliacao", b =>
                {
                    b.Property<int>("AvaliacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EntregadorId")
                        .HasColumnType("int");

                    b.Property<int>("LojistaId")
                        .HasColumnType("int");

                    b.Property<string>("Mensagem")
                        .HasColumnType("longtext")
                        .HasColumnName("Mensagem");

                    b.Property<string>("satisfacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AvaliacaoId");

                    b.HasIndex("EntregadorId");

                    b.HasIndex("LojistaId");

                    b.ToTable("Avaliacao", (string)null);
                });

            modelBuilder.Entity("EntregaRapida.Models.Enum.Historico", b =>
                {
                    b.Property<int>("HistoricoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EntregadorId")
                        .HasColumnType("int");

                    b.Property<int>("LojistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("HistoricoId");

                    b.HasIndex("EntregadorId");

                    b.HasIndex("LojistaId");

                    b.ToTable("Historicos", (string)null);
                });

            modelBuilder.Entity("EntregaRapida.Models.Lojista", b =>
                {
                    b.Property<int>("LojistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CNPJ")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("CNPJ");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext")
                        .HasColumnName("Endereco");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext")
                        .HasColumnName("Nome");

                    b.Property<int>("PlataformaId")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("Telefone");

                    b.Property<string>("TipoComercio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("LojistaId");

                    b.HasIndex("PlataformaId");

                    b.ToTable("Lojista", (string)null);
                });

            modelBuilder.Entity("EntregaRapida.Models.Notificacao", b =>
                {
                    b.Property<int>("NotificacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("PlataformaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("mensagem")
                        .HasColumnType("longtext");

                    b.HasKey("NotificacaoId");

                    b.HasIndex("PlataformaId");

                    b.ToTable("Notificação", (string)null);
                });

            modelBuilder.Entity("EntregaRapida.Models.Pagamento", b =>
                {
                    b.Property<int>("PagamentoId")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PagamentoId");

                    b.ToTable("pagamentos");
                });

            modelBuilder.Entity("EntregaRapida.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("EntregadorId")
                        .HasColumnType("int");

                    b.Property<int>("HistoricoId")
                        .HasColumnType("int");

                    b.Property<int>("LojistaId")
                        .HasColumnType("int");

                    b.Property<int>("NotificacaoId")
                        .HasColumnType("int");

                    b.Property<int>("PagementoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("distancia")
                        .HasColumnType("double");

                    b.Property<string>("enderecoDestino")
                        .HasColumnType("longtext");

                    b.Property<string>("enderecoOrigem")
                        .HasColumnType("longtext");

                    b.Property<string>("statuspedido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PedidoId");

                    b.HasIndex("EntregadorId");

                    b.HasIndex("HistoricoId");

                    b.HasIndex("LojistaId");

                    b.ToTable("pedido", (string)null);
                });

            modelBuilder.Entity("EntregaRapida.Models.Plataforma", b =>
                {
                    b.Property<int>("PlataformaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("PlataformaId");

                    b.ToTable("Plataforma", (string)null);
                });

            modelBuilder.Entity("EntregaRapida.Models.Entregador", b =>
                {
                    b.HasOne("EntregaRapida.Models.Plataforma", "plataforma")
                        .WithMany("entregadores")
                        .HasForeignKey("PlataformaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plataforma");
                });

            modelBuilder.Entity("EntregaRapida.Models.Enum.Avaliacao", b =>
                {
                    b.HasOne("EntregaRapida.Models.Entregador", "entregador")
                        .WithMany("avaliacao")
                        .HasForeignKey("EntregadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntregaRapida.Models.Lojista", "lojista")
                        .WithMany("avaliacao")
                        .HasForeignKey("LojistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("entregador");

                    b.Navigation("lojista");
                });

            modelBuilder.Entity("EntregaRapida.Models.Enum.Historico", b =>
                {
                    b.HasOne("EntregaRapida.Models.Entregador", "entregador")
                        .WithMany("historico")
                        .HasForeignKey("EntregadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntregaRapida.Models.Lojista", "lojista")
                        .WithMany("historico")
                        .HasForeignKey("LojistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("entregador");

                    b.Navigation("lojista");
                });

            modelBuilder.Entity("EntregaRapida.Models.Lojista", b =>
                {
                    b.HasOne("EntregaRapida.Models.Plataforma", "plataforma")
                        .WithMany("lojista")
                        .HasForeignKey("PlataformaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plataforma");
                });

            modelBuilder.Entity("EntregaRapida.Models.Notificacao", b =>
                {
                    b.HasOne("EntregaRapida.Models.Plataforma", "Plataforma")
                        .WithMany("notificacao")
                        .HasForeignKey("PlataformaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plataforma");
                });

            modelBuilder.Entity("EntregaRapida.Models.Pagamento", b =>
                {
                    b.HasOne("EntregaRapida.Models.Pedido", "pedido")
                        .WithOne("pagamento")
                        .HasForeignKey("EntregaRapida.Models.Pagamento", "PagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pedido");
                });

            modelBuilder.Entity("EntregaRapida.Models.Pedido", b =>
                {
                    b.HasOne("EntregaRapida.Models.Entregador", "entregador")
                        .WithMany("pedido")
                        .HasForeignKey("EntregadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntregaRapida.Models.Enum.Historico", "historico")
                        .WithMany("pedido")
                        .HasForeignKey("HistoricoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntregaRapida.Models.Lojista", "lojista")
                        .WithMany("pedido")
                        .HasForeignKey("LojistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntregaRapida.Models.Notificacao", "notificacao")
                        .WithMany("pedido")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("entregador");

                    b.Navigation("historico");

                    b.Navigation("lojista");

                    b.Navigation("notificacao");
                });

            modelBuilder.Entity("EntregaRapida.Models.Entregador", b =>
                {
                    b.Navigation("avaliacao");

                    b.Navigation("historico");

                    b.Navigation("pedido");
                });

            modelBuilder.Entity("EntregaRapida.Models.Enum.Historico", b =>
                {
                    b.Navigation("pedido");
                });

            modelBuilder.Entity("EntregaRapida.Models.Lojista", b =>
                {
                    b.Navigation("avaliacao");

                    b.Navigation("historico");

                    b.Navigation("pedido");
                });

            modelBuilder.Entity("EntregaRapida.Models.Notificacao", b =>
                {
                    b.Navigation("pedido");
                });

            modelBuilder.Entity("EntregaRapida.Models.Pedido", b =>
                {
                    b.Navigation("pagamento");
                });

            modelBuilder.Entity("EntregaRapida.Models.Plataforma", b =>
                {
                    b.Navigation("entregadores");

                    b.Navigation("lojista");

                    b.Navigation("notificacao");
                });
#pragma warning restore 612, 618
        }
    }
}
