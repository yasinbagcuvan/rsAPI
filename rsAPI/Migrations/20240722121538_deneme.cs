using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rsAPI.Migrations
{
    /// <inheritdoc />
    public partial class deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "daireTipleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    daireTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_daireTipleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ilanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ilanBaslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ilanAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ilanFiyat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ilanResmi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ilanKategorisiId = table.Column<int>(type: "int", nullable: false),
                    ilanDaireTipiId = table.Column<int>(type: "int", nullable: false),
                    ilanKisi = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ilanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ilanlar_daireTipleri_ilanDaireTipiId",
                        column: x => x.ilanDaireTipiId,
                        principalTable: "daireTipleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ilanlar_kategoriler_ilanKategorisiId",
                        column: x => x.ilanKategorisiId,
                        principalTable: "kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_ilanDaireTipiId",
                table: "ilanlar",
                column: "ilanDaireTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_ilanKategorisiId",
                table: "ilanlar",
                column: "ilanKategorisiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ilanlar");

            migrationBuilder.DropTable(
                name: "daireTipleri");

            migrationBuilder.DropTable(
                name: "kategoriler");
        }
    }
}
