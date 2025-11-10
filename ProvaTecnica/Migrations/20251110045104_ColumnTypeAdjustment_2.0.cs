using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class ColumnTypeAdjustment_20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Responsavel",
                table: "Sala");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Sala",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<bool>(
                name: "Cafe",
                table: "Agendamento",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsavel",
                table: "Agendamento",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Responsavel",
                table: "Agendamento");

            migrationBuilder.AlterColumn<byte>(
                name: "Ativo",
                table: "Sala",
                type: "tinyint",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsavel",
                table: "Sala",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<bool>(
                name: "Cafe",
                table: "Agendamento",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
