using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeTrabajoAPI.Migrations
{
    public partial class cvfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enterprise_Cuit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LinkCV",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "Curriculum",
                table: "AspNetUsers",
                type: "BLOB",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "Cuit", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2e40b61-6f7d-44d3-ae0e-ba0cbcc12a59", "3024502563", "AQAAAAEAACcQAAAAEA2kOKUpqSWUHLvHhmUiwv9f82DES8vinTkUr35t+HjAGuyMUGIp2H1SptvSp8mTdw==", "2614b722-709c-41b1-9c71-880534b25a55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "184b5d5e-ce2b-49ba-822d-a7360394aea9", "AQAAAAEAACcQAAAAEGZj0jNl8nvTHw3A0jx4QHxMgWbuyJpk3NBZreIBbBl633H8uAkKeL5xCXFYd+w9SA==", "13663cbd-6710-49eb-986d-df9b3230319d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Curriculum",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Enterprise_Cuit",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkCV",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62da02a4-c1fd-40bf-8e09-075104344ba9", "AQAAAAEAACcQAAAAEDQLPibGVr+O8hNzZkeCnxQLS5lLrdSiNgR7SFas+xGMTb+tdX2muQ/vaLCw1n+gkQ==", "48c88fa1-3494-473d-b57f-e5e8ab402b6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6057533-f445-484d-9fba-55d31c733ae2",
                columns: new[] { "ConcurrencyStamp", "Enterprise_Cuit", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40bedbcc-5866-4f3d-a177-03c25be5343e", "3024502563", "AQAAAAEAACcQAAAAEOj6itbfvYPQz+TulyrzTjsncrmTX8jeIsk3MNVT5CcAJkRZ9oPvU/21taFACiUcSw==", "c6fd3bf4-f393-4bab-9055-2170da07333b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "Cuit", "LinkCV", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d87cdce2-ba77-4c3a-8cad-b278d1c72e8e", "", "", "AQAAAAEAACcQAAAAEDw6zczgJhgaFN97abAVN57CrjKg1Q98xpUizaWqHC57Tp06f4L/Y6EJs0xNVEp0LQ==", "2bb627d9-6e08-4562-bb75-b91b5d24d23f" });
        }
    }
}
