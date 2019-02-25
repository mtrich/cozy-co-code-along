using Microsoft.EntityFrameworkCore.Migrations;

namespace Cozy.Data.Migrations
{
    public partial class identityrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84f95e49-cb30-4224-957f-5f6d0799b625", "7474ab69-dff2-42ea-b61d-50bd9e719420", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f05e08d-6757-47ac-a7ed-229a5cff51a5", "5e898da3-5bf7-40cf-97ec-16747dfca2a3", "Tenant", "TENANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6f05e08d-6757-47ac-a7ed-229a5cff51a5", "5e898da3-5bf7-40cf-97ec-16747dfca2a3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "84f95e49-cb30-4224-957f-5f6d0799b625", "7474ab69-dff2-42ea-b61d-50bd9e719420" });
        }
    }
}
