using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeTrabajoAPI.Migrations
{
    public partial class addRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnterpriseRelation",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34df2dc9-d3ba-4f3f-bb75-080600303a08", "AQAAAAEAACcQAAAAEFZgnUkGk0nKJzSp5dH/Qv7bN1D9VmKU7fBF8AxrQqK4zG5QtQX+mYRQsrBED/1ndQ==", "a9c60409-a234-46ad-9634-14304be226f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6057533-f445-484d-9fba-55d31c733ae2",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Website" },
                values: new object[] { "cb3b087e-a77e-474d-ade4-30da6eba859f", "Empresa", "Soluciones", "AQAAAAEAACcQAAAAENgMsO6DOOUwWqBLs40fbT880W6RxjF+DJestMR6pDmNFsHO7RYvLI0XmQHBFZyKAQ==", "", true, "a183a913-a800-451c-a2cd-40d447b8652b", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dd6b887-d37a-4906-b79a-ed1e2c13d918", "AQAAAAEAACcQAAAAEPRWmfxWb2/Px0lbJVw03vDEGI0SvYG4NcskDpdRWO4MS7xQmuiavCbrlnp56r4aNw==", "f2131e01-ee27-422a-a4be-797fe5b1555b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnterpriseRelation",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f752d1f2-fda1-4f6d-a4b7-30497db934cb", "AQAAAAEAACcQAAAAELrr4hRM2K0isIFsLdBAtIubJv3SXGIXo7m9WUdeEkeCjPoTFx4gnjGERWSHEA19IA==", "9fbfb3ff-b539-4b25-a15d-853b0e25c0f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6057533-f445-484d-9fba-55d31c733ae2",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Website" },
                values: new object[] { "71d93dce-2e65-41ca-8a8f-b2d432b5021a", "", "", "AQAAAAEAACcQAAAAEHnqu7GvG+T5BmBINPCmXcFlrQo4xYoB8U5hC1Ixb8TCrOlaNzpgNgi5N/5fhRGhfA==", null, false, "581435d1-3f16-43de-92fd-32987503034a", "www.megaempresa.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ce734bb-25c2-4f03-8610-5bb96f609c2a", "AQAAAAEAACcQAAAAEDvDiyNETTOt+VG+Dtjy6bD46IEv6K8yUZ0xBHiSFOgM28nXrVVK12qo1xgLjrR9+A==", "9eb490e0-d66a-441a-b0ad-4bceda88537b" });
        }
    }
}
