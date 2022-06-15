using Microsoft.EntityFrameworkCore.Migrations;

namespace Bazar_App.Migrations
{
    public partial class addImgPropToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imgurl",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Imgurl",
                value: "https://bazartest.blob.core.windows.net/img/BeautyCategory.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Imgurl",
                value: "https://bazartest.blob.core.windows.net/img/ClothesCategorys.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Imgurl",
                value: "https://bazartest.blob.core.windows.net/img/Mobile-Category.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imgurl",
                table: "Categories");
        }
    }
}
