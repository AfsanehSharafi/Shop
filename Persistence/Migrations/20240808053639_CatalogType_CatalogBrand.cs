using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CatalogType_CatalogBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogType_CatalogType_ParentCatalogTypeId",
                table: "CatalogType");

            migrationBuilder.DropColumn(
                name: "ParetCatalogTypeId",
                table: "CatalogType");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCatalogTypeId",
                table: "CatalogType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "CatalogType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogType_CatalogType_ParentCatalogTypeId",
                table: "CatalogType",
                column: "ParentCatalogTypeId",
                principalTable: "CatalogType",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogType_CatalogType_ParentCatalogTypeId",
                table: "CatalogType");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "CatalogType");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "CatalogType");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "CatalogType");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "CatalogType");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCatalogTypeId",
                table: "CatalogType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParetCatalogTypeId",
                table: "CatalogType",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogType_CatalogType_ParentCatalogTypeId",
                table: "CatalogType",
                column: "ParentCatalogTypeId",
                principalTable: "CatalogType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
