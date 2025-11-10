using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class ColumnTypeAdjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Cafe",
                table: "Agendamento",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValue: (byte)1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Cafe",
                table: "Agendamento",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)1,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
