using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rsAPI.Migrations
{
    /// <inheritdoc />
    public partial class deneme1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ilanlar_daireTipleri_ilanDaireTipiId",
                table: "ilanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_ilanlar_kategoriler_ilanKategorisiId",
                table: "ilanlar");

            migrationBuilder.DropIndex(
                name: "IX_ilanlar_ilanDaireTipiId",
                table: "ilanlar");

            migrationBuilder.DropIndex(
                name: "IX_ilanlar_ilanKategorisiId",
                table: "ilanlar");

            migrationBuilder.DropColumn(
                name: "ilanDaireTipiId",
                table: "ilanlar");

            migrationBuilder.DropColumn(
                name: "ilanKategorisiId",
                table: "ilanlar");

            migrationBuilder.AlterColumn<string>(
                name: "ilanResmi",
                table: "ilanlar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ilanDaireTipi",
                table: "ilanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ilanKategorisi",
                table: "ilanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ilanDaireTipi",
                table: "ilanlar");

            migrationBuilder.DropColumn(
                name: "ilanKategorisi",
                table: "ilanlar");

            migrationBuilder.AlterColumn<string>(
                name: "ilanResmi",
                table: "ilanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ilanDaireTipiId",
                table: "ilanlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ilanKategorisiId",
                table: "ilanlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_ilanDaireTipiId",
                table: "ilanlar",
                column: "ilanDaireTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_ilanlar_ilanKategorisiId",
                table: "ilanlar",
                column: "ilanKategorisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_ilanlar_daireTipleri_ilanDaireTipiId",
                table: "ilanlar",
                column: "ilanDaireTipiId",
                principalTable: "daireTipleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ilanlar_kategoriler_ilanKategorisiId",
                table: "ilanlar",
                column: "ilanKategorisiId",
                principalTable: "kategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
