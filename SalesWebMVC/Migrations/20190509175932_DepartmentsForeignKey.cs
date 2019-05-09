using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMVC.Migrations
{
    public partial class DepartmentsForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Departments_DepartmentId",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Sellers_DepartmentId",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Sellers");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentsId",
                table: "Sellers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_DepartmentsId",
                table: "Sellers",
                column: "DepartmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Departments_DepartmentsId",
                table: "Sellers",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Departments_DepartmentsId",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Sellers_DepartmentsId",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "DepartmentsId",
                table: "Sellers");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Sellers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_DepartmentId",
                table: "Sellers",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Departments_DepartmentId",
                table: "Sellers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
