using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfilesMicroService.Api.Migrations
{
    /// <inheritdoc />
    public partial class newInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Statuss_StatusId",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuss",
                table: "Statuss");

            migrationBuilder.RenameTable(
                name: "Statuss",
                newName: "Status");

            migrationBuilder.AddColumn<bool>(
                name: "isLinkedToAccount",
                table: "Patients",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Status_StatusId",
                table: "Doctors",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Status_StatusId",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "isLinkedToAccount",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Statuss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuss",
                table: "Statuss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Statuss_StatusId",
                table: "Doctors",
                column: "StatusId",
                principalTable: "Statuss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
