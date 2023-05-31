using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask.Persistance.Migrations
{
    public partial class AddUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Login_OrganizationId",
                table: "Users",
                columns: new[] { "Login", "OrganizationId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Login_OrganizationId",
                table: "Users");
        }
    }
}
