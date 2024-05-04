using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD.Infra.Mysql.Migrations
{
    /// <inheritdoc />
    public partial class PopulationProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Product", new string[] { "id", "product_name", "product_description", "product_quantity", "product_price", "product_image", "product_data" },
                new object[] { "2bd69681-81e0-46db-bcb1-f728c13c2c7e", "Product Test", "Description Test", 12, 12.98, "", DateTime.Now } );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Truncate table Product");
        }
    }
}
