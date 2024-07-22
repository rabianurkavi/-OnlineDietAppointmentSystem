using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class registerclientconsultanrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Consultants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DietitianStatus",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_ClientID",
                table: "Consultants",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_Clients_ClientID",
                table: "Consultants",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_Clients_ClientID",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_ClientID",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "DietitianStatus",
                table: "Clients");
        }
    }
}
