using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DKShopDb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingDetails",
                columns: table => new
                {
                    BillingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    City = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    State = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Postcode = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    MobileNo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OrderNotes = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BillingD__F1656DF356B3676F", x => x.BillingId);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categorie_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__55E5113F818BF7DB", x => x.categorie_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    image = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    images = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<decimal>(type: "numeric(10,0)", nullable: false),
                    short_desc = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    categorie_id = table.Column<int>(type: "int", nullable: true),
                    category = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    tags = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK__products__catego__25869641",
                        column: x => x.categorie_id,
                        principalTable: "categories",
                        principalColumn: "categorie_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_categorie_id",
                table: "products",
                column: "categorie_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingDetails");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
