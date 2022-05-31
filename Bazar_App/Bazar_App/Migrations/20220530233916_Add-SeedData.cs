using Microsoft.EntityFrameworkCore.Migrations;

namespace Bazar_App.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Beauty" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Clothes" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Mobiles" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Maybelline New York Colossal Bold Liner & Colossal Kajal - EYE KIT COMBO (Pack Of 2), 0.35 gm + 3 ml", "Liner & Colossal Kajal", 15.5 },
                    { 2, 1, "URBANMAC Premium Synthetic Kabuki Foundation Face Powder Blush Eyeshadow Brush Makeup Brush Kit with Blender Sponge and Brush Cleaner - Makeup Brushes Set", "Blushes", 20.0 },
                    { 3, 1, "Coloressence Full Coverage Waterproof Lightweight Matte Formula Opaque Lotion High Definition Foundation (HDF-2) with Set of 2 Blending Sponge", "Foundation ", 50.0 },
                    { 4, 2, "HIKIPO Presents 100% Cotton Born Baby Summer Wear Baby Clothes Sets For Gift", "Cotton Born Baby", 15.0 },
                    { 5, 2, "Babyblossom Baby Kid's Cotton Combo Pack Of 3 Clothing Set ( 3 Top And 3 Bottom) (1112,Multicolor,0-3 Months)", "Kid's Cotton Combo Pack Of 3 Clothing Set", 243.0 },
                    { 6, 2, "Scott International Men's Regular Fit T-Shirt (Pack of 3)", "Men's Regular Fit T-Shirt", 120.0 },
                    { 7, 3, "Oppo A54 (Starry Blue, 6GB RAM, 128GB Storage) with No Cost EMI & Additional Exchange Offers", "Oppo A54", 123.0 },
                    { 8, 3, "Tecno Spark 8 Pro (Turquoise Cyan, 7GB Expandable RAM 64GB Storage) 33W Fast Charger | Helio G85 Gaming Processor", "Tecno Spark 8 Pro", 432.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
