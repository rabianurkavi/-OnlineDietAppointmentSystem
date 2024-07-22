using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_update_admin_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Admins",
                newName: "AdminPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "AdminName",
                table: "Admins",
                newName: "AdminLastName");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AdminFirstName",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "Admins",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_RoleID",
                table: "Admins",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Role_RoleID",
                table: "Admins",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Role_RoleID",
                table: "Admins");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Admins_RoleID",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AdminFirstName",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "AdminPhoneNumber",
                table: "Admins",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "AdminLastName",
                table: "Admins",
                newName: "AdminName");
        }
    }
}
