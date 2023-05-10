using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCSQ014_RazorViews.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var roles = new[] { "regular", "editor", "admin" };
            migrationBuilder.Sql("INSERT INTO AspNetRoles(Id, Name, NormalizedName, ConcurrencyStamp) " +
                $"VALUES('{Guid.NewGuid().ToString()}', '{roles[0]}', '{roles[0].ToUpper()}', '{DateTime.Now}')");

            migrationBuilder.Sql("INSERT INTO AspNetRoles(Id, Name, NormalizedName, ConcurrencyStamp) " +
                $"VALUES('{Guid.NewGuid().ToString()}', '{roles[1]}', '{roles[1].ToUpper()}', '{DateTime.Now}')");

            migrationBuilder.Sql("INSERT INTO AspNetRoles(Id, Name, NormalizedName, ConcurrencyStamp) " +
                $"VALUES('{Guid.NewGuid().ToString()}', '{roles[2]}', '{roles[2].ToUpper()}', '{DateTime.Now}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
