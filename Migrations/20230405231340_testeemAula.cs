using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace EntregaRapida.Migrations
{
    /// <inheritdoc />
    public partial class testeemAula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Plataforma",
                columns: table => new
                {
                    PlataformaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plataforma", x => x.PlataformaId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Entregadores",
                columns: table => new
                {
                    EntregadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PlataformaId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Endereco = table.Column<string>(type: "longtext", nullable: false),
                    DDD = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    Celular = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    CNH = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Modalidade = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregadores", x => x.EntregadorId);
                    table.ForeignKey(
                        name: "FK_Entregadores_Plataforma_PlataformaId",
                        column: x => x.PlataformaId,
                        principalTable: "Plataforma",
                        principalColumn: "PlataformaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lojista",
                columns: table => new
                {
                    LojistaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PlataformaId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: true),
                    Endereco = table.Column<string>(type: "longtext", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    CNPJ = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    TipodeComercio = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lojista", x => x.LojistaId);
                    table.ForeignKey(
                        name: "FK_Lojista_Plataforma_PlataformaId",
                        column: x => x.PlataformaId,
                        principalTable: "Plataforma",
                        principalColumn: "PlataformaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notificação",
                columns: table => new
                {
                    NotificacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    mensagem = table.Column<string>(type: "longtext", nullable: true),
                    PlataformaId = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificação", x => x.NotificacaoId);
                    table.ForeignKey(
                        name: "FK_Notificação_Plataforma_PlataformaId",
                        column: x => x.PlataformaId,
                        principalTable: "Plataforma",
                        principalColumn: "PlataformaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EntregadorId = table.Column<int>(type: "int", nullable: false),
                    LojistaId = table.Column<int>(type: "int", nullable: false),
                    satisfacao = table.Column<string>(type: "longtext", nullable: false),
                    Mensagem = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Entregadores_EntregadorId",
                        column: x => x.EntregadorId,
                        principalTable: "Entregadores",
                        principalColumn: "EntregadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Lojista_LojistaId",
                        column: x => x.LojistaId,
                        principalTable: "Lojista",
                        principalColumn: "LojistaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Historicos",
                columns: table => new
                {
                    HistoricoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EntregadorId = table.Column<int>(type: "int", nullable: false),
                    LojistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historicos", x => x.HistoricoId);
                    table.ForeignKey(
                        name: "FK_Historicos_Entregadores_EntregadorId",
                        column: x => x.EntregadorId,
                        principalTable: "Entregadores",
                        principalColumn: "EntregadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historicos_Lojista_LojistaId",
                        column: x => x.LojistaId,
                        principalTable: "Lojista",
                        principalColumn: "LojistaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    enderecoOrigem = table.Column<string>(type: "longtext", nullable: true),
                    enderecoDestino = table.Column<string>(type: "longtext", nullable: true),
                    distancia = table.Column<double>(type: "double", nullable: false),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    statuspedido = table.Column<string>(type: "longtext", nullable: false),
                    EntregadorId = table.Column<int>(type: "int", nullable: false),
                    LojistaId = table.Column<int>(type: "int", nullable: false),
                    PagementoId = table.Column<int>(type: "int", nullable: false),
                    NotificacaoId = table.Column<int>(type: "int", nullable: false),
                    HistoricoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_pedido_Entregadores_EntregadorId",
                        column: x => x.EntregadorId,
                        principalTable: "Entregadores",
                        principalColumn: "EntregadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_Historicos_HistoricoId",
                        column: x => x.HistoricoId,
                        principalTable: "Historicos",
                        principalColumn: "HistoricoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_Lojista_LojistaId",
                        column: x => x.LojistaId,
                        principalTable: "Lojista",
                        principalColumn: "LojistaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_Notificação_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Notificação",
                        principalColumn: "NotificacaoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pagamentos",
                columns: table => new
                {
                    PagamentoId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamentos", x => x.PagamentoId);
                    table.ForeignKey(
                        name: "FK_pagamentos_pedido_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "pedido",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_EntregadorId",
                table: "Avaliacao",
                column: "EntregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_LojistaId",
                table: "Avaliacao",
                column: "LojistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregadores_PlataformaId",
                table: "Entregadores",
                column: "PlataformaId");

            migrationBuilder.CreateIndex(
                name: "IX_Historicos_EntregadorId",
                table: "Historicos",
                column: "EntregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Historicos_LojistaId",
                table: "Historicos",
                column: "LojistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lojista_PlataformaId",
                table: "Lojista",
                column: "PlataformaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificação_PlataformaId",
                table: "Notificação",
                column: "PlataformaId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_EntregadorId",
                table: "pedido",
                column: "EntregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_HistoricoId",
                table: "pedido",
                column: "HistoricoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_LojistaId",
                table: "pedido",
                column: "LojistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "pagamentos");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "Historicos");

            migrationBuilder.DropTable(
                name: "Notificação");

            migrationBuilder.DropTable(
                name: "Entregadores");

            migrationBuilder.DropTable(
                name: "Lojista");

            migrationBuilder.DropTable(
                name: "Plataforma");
        }
    }
}
