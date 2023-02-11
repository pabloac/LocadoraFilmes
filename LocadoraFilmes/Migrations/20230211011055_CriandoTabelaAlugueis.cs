using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace LocadoraFilmes.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaAlugueis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alugueis",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<string>(type: "bigint", nullable: false),
                    FilmeId = table.Column<string>(type: "bigint", nullable: false),
                    DtAluguel = table.Column<DateTime>(type: "datetime", nullable: true),
                    DtPrevisaoEntrega = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alugueis", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Alugueis_Clientes",
                table: "Alugueis",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Alugueis_Filmes",
                table: "Alugueis",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alugueis");
        }
    }
}
