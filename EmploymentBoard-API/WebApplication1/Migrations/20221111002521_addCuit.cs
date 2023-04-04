using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeTrabajoAPI.Migrations
{
    public partial class addCuit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Enterprise_Cuit",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0efe278-4a9e-413c-91c8-ba39fcf8e587", "AQAAAAEAACcQAAAAEIUx9DLEqvdygUzqg1X36dZqMYhVEbJMjiwBphf5A2sAfvJeji6vfZpOxv3l1huvGA==", "5ba4dfe6-ab6f-49c2-8d98-508b850aa229" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6057533-f445-484d-9fba-55d31c733ae2",
                columns: new[] { "ConcurrencyStamp", "Enterprise_Cuit", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb9d6d29-828a-4754-9eeb-46ec106351e4", "3024502563", "AQAAAAEAACcQAAAAELV3VTeP/ifMFRQi0iwlI0/a5Vvm6Odm5p3sbcWRKFNO0O6FSN0rYqbe3U8EFyo93A==", "d324328f-91a1-471c-b693-bed0f0a094c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "Cuit", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35561a2f-0a78-44e1-9a5d-19444d8521ae", "23382255021", "AQAAAAEAACcQAAAAEHAB4aAvqW3wNzodGkuuj1LKcOcvSwmKJWuSiuDYbrm3cwcj0P5IdZuVWMo4k4+ebA==", "5c5c5e75-13ca-4c1a-aae8-1b5d2889365c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enterprise_Cuit",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73340e90-fabc-4ebf-b4e9-fd86213ef3ab", "AQAAAAEAACcQAAAAEDZ+4zUVrrQCzaUdPAgFNFe+p1IGZe/3TCGIoJ+6KAHUXa7FpC/0Zl7JLJkKKqjZ0w==", "62d29698-6487-4347-b003-07d864bdf587" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6057533-f445-484d-9fba-55d31c733ae2",
                columns: new[] { "ConcurrencyStamp", "Cuit", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fa600eb-27f0-44bc-8bcf-96add41a275f", "3024502563", "AQAAAAEAACcQAAAAEPtw5ypFQhLszAWPSXJOAhsjdWVD+QAMbNav8w2DltMGpQ51bIGOzSw1e9Q0gHq4sA==", "fca88f36-ae25-4d6d-865e-d6e1ed4b0d5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bfb048d-3227-4a5d-b382-84498ec2a557", "AQAAAAEAACcQAAAAEJ7sN4b0OsGwwcmT+E0Mixp8O+d+oq+lHhlFbH+JHUas/YlDzcXMOwSsZeUwy+JC5w==", "bc5a1bc0-2ded-49eb-858d-1a169c69bd60" });
        }
    }
}
