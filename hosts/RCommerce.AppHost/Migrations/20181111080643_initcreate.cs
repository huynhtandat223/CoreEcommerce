using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RCommerce.AppHost.Migrations
{
    public partial class initcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Core_AppSetting",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Module = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_AppSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products_Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 350, nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    ParentName = table.Column<string>(maxLength: 350, nullable: true),
                    SKUPrefix = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products_Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 350, nullable: true),
                    Alt = table.Column<string>(maxLength: 500, nullable: true),
                    Position = table.Column<int>(maxLength: 350, nullable: false),
                    SourceUrl = table.Column<string>(maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products_Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    SKU = table.Column<string>(maxLength: 50, nullable: true),
                    RegularPrice = table.Column<double>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    QtyOnHand = table.Column<int>(nullable: true),
                    OriginalPrice = table.Column<double>(nullable: true),
                    IsInStock = table.Column<bool>(nullable: true),
                    OriginalUrl = table.Column<string>(maxLength: 1000, nullable: true),
                    ProductNote = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    UpdatedUser = table.Column<string>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products_ProductOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_ProductOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products_ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_Products_ProductCategory_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Products_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategory_Products_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products_ProductImage",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_ProductImage", x => new { x.ProductId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_Products_ProductImage_Products_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Products_Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductImage_Products_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products_ProductOptionValue",
                columns: table => new
                {
                    OptionId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ProductOptionValudeDefaultId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_ProductOptionValue", x => new { x.ProductId, x.OptionId, x.ProductOptionValudeDefaultId });
                    table.ForeignKey(
                        name: "FK_Products_ProductOptionValue_Products_ProductOption_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Products_ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductOptionValue_Products_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products_ProductOptionValueDefault",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OptionId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_ProductOptionValueDefault", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductOptionValueDefault_Products_ProductOption_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Products_ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products_Category",
                columns: new[] { "Id", "Name", "ParentId", "ParentName", "SKUPrefix" },
                values: new object[,]
                {
                    { 1, "Category 1", 0, null, "C1" },
                    { 2, "Category 2", 0, null, "C2" },
                    { 3, "Category 3", 1, "Category 1", "C3" },
                    { 4, "Category 4", 1, "Category 1", "C4" },
                    { 5, "Category 5", 2, "Category 2", "C5" },
                    { 6, "Category 6", 3, "Category 3", "C6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategory_CategoryId",
                table: "Products_ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductImage_ImageId",
                table: "Products_ProductImage",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductOptionValue_OptionId",
                table: "Products_ProductOptionValue",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductOptionValueDefault_OptionId",
                table: "Products_ProductOptionValueDefault",
                column: "OptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Core_AppSetting");

            migrationBuilder.DropTable(
                name: "Products_ProductCategory");

            migrationBuilder.DropTable(
                name: "Products_ProductImage");

            migrationBuilder.DropTable(
                name: "Products_ProductOptionValue");

            migrationBuilder.DropTable(
                name: "Products_ProductOptionValueDefault");

            migrationBuilder.DropTable(
                name: "Products_Category");

            migrationBuilder.DropTable(
                name: "Products_Image");

            migrationBuilder.DropTable(
                name: "Products_Product");

            migrationBuilder.DropTable(
                name: "Products_ProductOption");
        }
    }
}
