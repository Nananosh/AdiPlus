using Microsoft.EntityFrameworkCore.Migrations;

namespace AdiPlus.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalCards_Clients_ClientId",
                table: "MedicalCards");

            migrationBuilder.DropIndex(
                name: "IX_MedicalCards_ClientId",
                table: "MedicalCards");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "MedicalCards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "MedicalCards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCards_ClientId",
                table: "MedicalCards",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalCards_Clients_ClientId",
                table: "MedicalCards",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
