using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Bones.Migrations
{
    /// <inheritdoc />
    public partial class fixTimestamptz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "task_processamento",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestampz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "produtos",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestampz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "pedidos",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestampz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "notificacao",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestampz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "clientes",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestampz",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "task_processamento",
                type: "timestampz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "produtos",
                type: "timestampz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "pedidos",
                type: "timestampz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "notificacao",
                type: "timestampz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "clientes",
                type: "timestampz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true);
        }
    }
}
