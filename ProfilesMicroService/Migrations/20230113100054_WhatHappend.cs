using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfilesMicroService.Api.Migrations
{
    /// <inheritdoc />
    public partial class WhatHappend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isLinkedToAccount",
                table: "Patients",
                newName: "IsLinkedToAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsLinkedToAccount",
                table: "Patients",
                newName: "isLinkedToAccount");
        }
    }
}
