using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedingCompanyDataToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Patna", "SupShiv IT Solution", "+91-9304961453", 801105, "Bihar", "Danapur, Khagual" },
                    { 2, "Kolkata", "RF Solutions", "+91-9955983347", 700001, "West Bengal", "Dum Dum, Kolata" },
                    { 3, "Arwal", "S.K IT Master", "+91-7250694584", 8034505, "Bihar", "Amara, Arwal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
