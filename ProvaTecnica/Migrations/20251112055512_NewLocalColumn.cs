using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class NewLocalColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Local",
                table: "Sala",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Local",
                table: "Sala");
        }
    }
}
