using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeTrabajoAPI.Migrations
{
    public partial class addName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Enterprise_Name",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "564adb4f-63b4-408c-9cd2-4534347faca6", "AQAAAAEAACcQAAAAEGGGd0DYsbv7tbspY+qqfm775IfLtr116sgF9cJ6KEbVM3zJBCBOVdG21vprQuDp0g==", "9130fcbf-9ab1-4b08-96c8-1f52beb15d93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6057533-f445-484d-9fba-55d31c733ae2",
                columns: new[] { "ConcurrencyStamp", "Enterprise_Name", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27d7861f-1d6a-427a-96e7-92b9299f9863", "Soluciones SA", "AQAAAAEAACcQAAAAEKtLIt2MIaz8+SdfqKyR6WOVIpvzLrPiegms2v2a6rKydSQ+O762aLdwdGYsT9WhNQ==", "db19125d-64f6-4f30-86d3-ca815703c922" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2da799f-16d3-4b0d-9d70-a15208c1fe3f", "jp@mail.com", "AQAAAAEAACcQAAAAEPOxi4F0DX414kD2D5pOJFL1Mw6OH3MCKzJ+pV3VY315nIQ7Sgi2hlBBSLvji0kmxA==", "eaeaddc4-7f36-4f74-ae14-371ed6b3fcaa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enterprise_Name",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7861e286-a356-4636-977d-4d08c4d8025e", "AQAAAAEAACcQAAAAEKNEb9Hvwn3R9LhgwtEawJ91e5MsjmY5wPl2HEu86Xc/Tv5jnXle43Y9Le7H1CuVVg==", "d3c4864c-33e9-4a34-9289-b57a85a0bd99" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6057533-f445-484d-9fba-55d31c733ae2",
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2e40b61-6f7d-44d3-ae0e-ba0cbcc12a59", "Soluciones SA", "AQAAAAEAACcQAAAAEA2kOKUpqSWUHLvHhmUiwv9f82DES8vinTkUr35t+HjAGuyMUGIp2H1SptvSp8mTdw==", "2614b722-709c-41b1-9c71-880534b25a55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "184b5d5e-ce2b-49ba-822d-a7360394aea9", "AQAAAAEAACcQAAAAEGZj0jNl8nvTHw3A0jx4QHxMgWbuyJpk3NBZreIBbBl633H8uAkKeL5xCXFYd+w9SA==", "13663cbd-6710-49eb-986d-df9b3230319d" });
        }
    }
}
