using Microsoft.EntityFrameworkCore.Migrations;

namespace Pro_cat.Migrations
{
    public partial class mymigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Associations_AssociationId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AssociationId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AssociationId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssociationId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AssociationId",
                table: "Products",
                column: "AssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Associations_AssociationId",
                table: "Products",
                column: "AssociationId",
                principalTable: "Associations",
                principalColumn: "AssociationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
