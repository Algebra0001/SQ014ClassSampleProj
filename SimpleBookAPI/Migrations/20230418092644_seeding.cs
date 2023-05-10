using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleBookAPI.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Books (Id, Name, ISBN, DatePublished, Publisher, Author, TotalPages, Portrait)" +
                "VALUES('1', 'Jungle Book', '333-555-AB', '2000', 'Mogli', 'Mogli', 250, 'Null')");

            migrationBuilder.Sql("INSERT INTO Books (Id, Name, ISBN, DatePublished, Publisher, Author, TotalPages, Portrait)" +
                "VALUES('2', 'Dragon Fish', '303-155-CC', '2003', 'Mogli', 'Mogli', 550, 'Null')");

            migrationBuilder.Sql("INSERT INTO Books (Id, Name, ISBN, DatePublished, Publisher, Author, TotalPages, Portrait)" +
                "VALUES('3', 'Bee Hive', '031-556-AD', '2010', 'Samuel', 'Mogli', 300, 'Null')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
