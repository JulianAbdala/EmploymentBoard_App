using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeTrabajoAPI.Migrations
{
    public partial class addEnterpriseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhoneNumber",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPosition",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

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
                columns: new[] { "Address", "ConcurrencyStamp", "ContactEmail", "ContactName", "ContactPhoneNumber", "ContactPosition", "PasswordHash", "SecurityStamp", "Website" },
                values: new object[] { "", "71d93dce-2e65-41ca-8a8f-b2d432b5021a", "", "", "", "", "AQAAAAEAACcQAAAAEHnqu7GvG+T5BmBINPCmXcFlrQo4xYoB8U5hC1Ixb8TCrOlaNzpgNgi5N/5fhRGhfA==", "581435d1-3f16-43de-92fd-32987503034a", "www.megaempresa.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ce734bb-25c2-4f03-8610-5bb96f609c2a", "AQAAAAEAACcQAAAAEDvDiyNETTOt+VG+Dtjy6bD46IEv6K8yUZ0xBHiSFOgM28nXrVVK12qo1xgLjrR9+A==", "9eb490e0-d66a-441a-b0ad-4bceda88537b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactPhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactPosition",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59f83327-45da-45e6-b787-047bcf59f876", "AQAAAAEAACcQAAAAEIH4/myQ0Rrh7vI6BigJ/v1i3YMCpqBGZn0OzvusM8fongsbcatOPgBB5PGcBJNWDA==", "e039b84c-8be7-4afc-aba0-e51a0e17d2f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6057533-f445-484d-9fba-55d31c733ae2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0b18490-9b57-4b67-811a-68db976f831b", "AQAAAAEAACcQAAAAEBFFjd/FBiQaeN6o1DjDs1rYI2a+tT0HvIDuwAZ0ip2cLXRV/+QQa2dRrY1c0tBlwA==", "1aaa2985-23db-4758-8482-abc5e3add85e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87e9032b-9807-434e-94e2-8928398723de", "AQAAAAEAACcQAAAAEE8l3xTWIohOWTlxSXWpvuHY8KywCglNcKKJGrDdg7yik2ba05gFpWN1bzK8oXm5aQ==", "5c5b429b-9b0e-4ef4-a9be-a36f524471f0" });
        }
    }
}
