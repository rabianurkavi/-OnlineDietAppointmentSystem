using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_update_admin_pro_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdminStatus",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_ClientID",
                table: "Admins",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Clients_ClientID",
                table: "Admins",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Clients_ClientID",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_ClientID",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "AdminStatus",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Admins");
        }
    }
}
