using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeTrabajoAPI.Migrations
{
    public partial class addEnterpriseCuit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Enterprise_AccountStatus",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Enterprise_Cuit",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Field",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "Enterprise_Cuit", "Field", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0b18490-9b57-4b67-811a-68db976f831b", "3024502563", "IT", "AQAAAAEAACcQAAAAEBFFjd/FBiQaeN6o1DjDs1rYI2a+tT0HvIDuwAZ0ip2cLXRV/+QQa2dRrY1c0tBlwA==", "1aaa2985-23db-4758-8482-abc5e3add85e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "Cuit", "PasswordHash", "PersonalId", "SecurityStamp" },
                values: new object[] { "87e9032b-9807-434e-94e2-8928398723de", "", "AQAAAAEAACcQAAAAEE8l3xTWIohOWTlxSXWpvuHY8KywCglNcKKJGrDdg7yik2ba05gFpWN1bzK8oXm5aQ==", "", "5c5b429b-9b0e-4ef4-a9be-a36f524471f0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enterprise_AccountStatus",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Enterprise_Cuit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Field",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e67ead4-2f09-4a12-b977-9e7d5415b91a", "AQAAAAEAACcQAAAAEIIL0qkEmZ54TGeyk+P6RZRx+wTNZrZtB+YuayS7iP6elc876ArBHQfN3YhVNcnJYA==", "34d7788c-ba46-4c39-979b-e2e1d2aba4ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6057533-f445-484d-9fba-55d31c733ae2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e8d36a2-af2a-4b88-8e7c-8646b911e394", "AQAAAAEAACcQAAAAEN6Q6KY4he1Ykqv4VU8PuQ1CWcRc5iC3qb513aBGYif44JetIXuBtSl1x0umK1tlrg==", "b1e75012-3f55-4ce5-ad44-be2c27ee2ac2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "Cuit", "PasswordHash", "PersonalId", "SecurityStamp" },
                values: new object[] { "e77d151a-7c7f-44e0-b8cc-5ef1b44e4a5b", "21354565457", "AQAAAAEAACcQAAAAEBKC0n5IbUBNhWO/X9LizHtNpnASCqsY5gYr6Cv+yMNkSGE+FA82D/KctzoMOam+Ag==", "35456545", "91819172-b153-45d4-93fb-8e1afc39b1f6" });
        }
    }
}
