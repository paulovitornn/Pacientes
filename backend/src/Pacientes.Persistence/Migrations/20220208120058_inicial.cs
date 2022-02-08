using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pacientes.Persistence.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RG = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CNS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Sexo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeMae = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CEP = table.Column<int>(type: "int", nullable: false),
                    UF = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DDD = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefones_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "Bairro", "CEP", "CNS", "CPF", "Cidade", "DataNascimento", "Endereco", "Nome", "NomeMae", "RG", "Sexo", "UF" },
                values: new object[] { 1, "Maysa 1", 75380000, "123456", "79341014069", "Trindade", new DateTime(1989, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua Aliança, QD XX LT XX", "Paulo Vitor Nunes do Nascimento", "Maria Nunes", "123456", "m", "GO" });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "Bairro", "CEP", "CNS", "CPF", "Cidade", "DataNascimento", "Endereco", "Nome", "NomeMae", "RG", "Sexo", "UF" },
                values: new object[] { 2, "Maysa 1", 75380000, "987654", "20202126099", "Trindade", new DateTime(1989, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rua Aliança, QD XX LT XX", "Ariane Tabata", "Ana Rita", "987654", "f", "GO" });

            migrationBuilder.InsertData(
                table: "Telefones",
                columns: new[] { "Id", "DDD", "Numero", "PacienteId", "Tipo" },
                values: new object[] { 1, 62, 992929292, 1, "Celular" });

            migrationBuilder.InsertData(
                table: "Telefones",
                columns: new[] { "Id", "DDD", "Numero", "PacienteId", "Tipo" },
                values: new object[] { 2, 62, 991919191, 2, "Celular" });

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_PacienteId",
                table: "Telefones",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
