using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeTrabajoAPI.Migrations
{
    public partial class addEnterpriseName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnterpriseName",
                table: "JobOffers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40bedbcc-5866-4f3d-a177-03c25be5343e", "AQAAAAEAACcQAAAAEOj6itbfvYPQz+TulyrzTjsncrmTX8jeIsk3MNVT5CcAJkRZ9oPvU/21taFACiUcSw==", "c6fd3bf4-f393-4bab-9055-2170da07333b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d87cdce2-ba77-4c3a-8cad-b278d1c72e8e", "AQAAAAEAACcQAAAAEDw6zczgJhgaFN97abAVN57CrjKg1Q98xpUizaWqHC57Tp06f4L/Y6EJs0xNVEp0LQ==", "2bb627d9-6e08-4562-bb75-b91b5d24d23f" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "EnterpriseName",
                value: "Soluciones SA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnterpriseName",
                table: "JobOffers");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb3b087e-a77e-474d-ade4-30da6eba859f", "AQAAAAEAACcQAAAAENgMsO6DOOUwWqBLs40fbT880W6RxjF+DJestMR6pDmNFsHO7RYvLI0XmQHBFZyKAQ==", "a183a913-a800-451c-a2cd-40d447b8652b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dd6b887-d37a-4906-b79a-ed1e2c13d918", "AQAAAAEAACcQAAAAEPRWmfxWb2/Px0lbJVw03vDEGI0SvYG4NcskDpdRWO4MS7xQmuiavCbrlnp56r4aNw==", "f2131e01-ee27-422a-a4be-797fe5b1555b" });
        }
    }
}
