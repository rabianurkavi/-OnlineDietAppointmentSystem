using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migaddabout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutSmallTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutLargeTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultantCount = table.Column<int>(type: "int", nullable: false),
                    ClientCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");
        }
    }
}
