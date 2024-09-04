using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspProjekat.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class @fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFile_Customers_CustomerId",
                table: "CustomerFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerFile",
                table: "CustomerFile");

            migrationBuilder.RenameTable(
                name: "CustomerFile",
                newName: "CustomerFiles");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerFile_CustomerId",
                table: "CustomerFiles",
                newName: "IX_CustomerFiles_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerFiles",
                table: "CustomerFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFiles_Customers_CustomerId",
                table: "CustomerFiles",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFiles_Customers_CustomerId",
                table: "CustomerFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerFiles",
                table: "CustomerFiles");

            migrationBuilder.RenameTable(
                name: "CustomerFiles",
                newName: "CustomerFile");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerFiles_CustomerId",
                table: "CustomerFile",
                newName: "IX_CustomerFile_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerFile",
                table: "CustomerFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFile_Customers_CustomerId",
                table: "CustomerFile",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
