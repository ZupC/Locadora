﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClassificacaoIndicativa = table.Column<int>(type: "int", nullable: false),
                    Lancamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "Date", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "CPF", "DataNascimento", "Nome" },
                values: new object[,]
                {
                    { 1, "11111111111", new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Germano Pereira" },
                    { 2, "11111111111", new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro Teixeira" },
                    { 3, "11111111111", new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduardo Silva" },
                    { 4, "11111111111", new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Alberto" },
                    { 5, "11111111111", new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fernanda Costa" },
                    { 6, "11111111111", new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lethicia Menez" }
                });

            migrationBuilder.InsertData(
                table: "Filme",
                columns: new[] { "Id", "ClassificacaoIndicativa", "Lancamento", "Titulo" },
                values: new object[,]
                {
                    { 1, 14, 1, "harry potter" },
                    { 2, 16, 0, "Senhor dos aneis" },
                    { 3, 18, 0, "O alto da compadecida" }
                });

            migrationBuilder.InsertData(
                table: "Locacao",
                columns: new[] { "Id", "ClienteId", "DataDevolucao", "DataLocacao", "FilmeId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 3, new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 5, new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 6, new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Locacao");
        }
    }
}