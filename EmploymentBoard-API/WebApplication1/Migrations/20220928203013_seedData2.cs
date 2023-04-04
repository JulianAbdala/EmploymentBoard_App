using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeTrabajoAPI.Migrations
{
    public partial class seedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84bf5280-a4ad-4c5b-b7bd-4f563bd693d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                column: "ConcurrencyStamp",
                value: "196a6af5-6773-4df2-a51b-5e552904ff7a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46425ade-698f-4e8e-8086-f4d86808ced9", "AQAAAAEAACcQAAAAEJKOaVvtnws890GiwTdC47uJ9SkE+9IJLge6jtH7io4vWLlaGz7dnVBkdV+Vsr4wmA==", "1af80dac-ccaa-4d1a-a3ac-dcb55ff33dc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dc3e0e04-a3a1-4374-b101-b8683f3ae595", "3a3c0fd1-2894-4f25-be12-d1989133197b" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountStatus", "CareerId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FileNumber", "FirstName", "LastName", "LinkCV", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "582301ab-1737-4440-863a-6431105995f3", 0, 0, 2, "2f6b8fc2-1e63-4867-879e-11e95e25d4c8", "Student", "jp@mail.com", true, 456872, "Juan", "Perez", "", false, null, "JP@MAIL.COM", null, "123456789", "", false, "9d56963e-aee0-4cad-9973-6afbb58bef21", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "582301ab-1737-4440-863a-6431105995f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                column: "ConcurrencyStamp",
                value: "341743f0-asd2–42de-afbf-59kmkkmk72cf6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6bceb47-c4f9-426a-b05c-ead2337923a6", "AQAAAAEAACcQAAAAEIl6IVsQT30pQu0Mi85Hya+C3hWh+i8nz+mmX3jaLRIxkeON5eyj31S0+EfNOUryfA==", "849f7dd3-eddb-4d69-9323-6f7adffe02a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e1d8042d-e024-4598-ba5a-6eead457816d", "756a5c63-1a30-4346-9218-2c5ef8cbb946" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountStatus", "CareerId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FileNumber", "FirstName", "LastName", "LinkCV", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "84bf5280-a4ad-4c5b-b7bd-4f563bd693d8", 0, 0, 2, "4dd975f6-58ea-4878-ba88-a6981d1f2e04", "Student", "jp@mail.com", true, 456872, "Juan", "Perez", "", false, null, "JP@MAIL.COM", null, "123456789", "", false, "a1437a13-ee05-423e-bc6f-f6b15932bdb4", false, null });
        }
    }
}
