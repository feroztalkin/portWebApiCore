using Microsoft.EntityFrameworkCore.Migrations;

namespace portWebApiCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dynamicPort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    uniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    httpport = table.Column<int>(type: "INTEGER", nullable: false),
                    httpsport = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dynamicPort", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "dynamicPort",
                columns: new[] { "Id", "httpport", "httpsport", "uniqueCode" },
                values: new object[] { 1, 11101, 22201, "Caliber01" });

            migrationBuilder.InsertData(
                table: "dynamicPort",
                columns: new[] { "Id", "httpport", "httpsport", "uniqueCode" },
                values: new object[] { 2, 11102, 22202, "Caliber02" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dynamicPort");
        }
    }
}
