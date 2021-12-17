using Microsoft.EntityFrameworkCore.Migrations;

namespace AdiPlus.Migrations
{
    public partial class EditService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceMeterialStandarts_Materials_MaterialId",
                table: "ServiceMeterialStandarts");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "ServiceMeterialStandarts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_DoctorId",
                table: "Services",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceMeterialStandarts_Materials_MaterialId",
                table: "ServiceMeterialStandarts",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Doctors_DoctorId",
                table: "Services",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceMeterialStandarts_Materials_MaterialId",
                table: "ServiceMeterialStandarts");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Doctors_DoctorId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_DoctorId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "ServiceMeterialStandarts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceMeterialStandarts_Materials_MaterialId",
                table: "ServiceMeterialStandarts",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
