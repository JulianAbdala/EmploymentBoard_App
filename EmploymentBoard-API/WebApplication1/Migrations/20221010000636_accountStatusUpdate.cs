using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeTrabajoAPI.Migrations
{
    public partial class accountStatusUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enterprise_AccountStatus",
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e77d151a-7c7f-44e0-b8cc-5ef1b44e4a5b", "AQAAAAEAACcQAAAAEBKC0n5IbUBNhWO/X9LizHtNpnASCqsY5gYr6Cv+yMNkSGE+FA82D/KctzoMOam+Ag==", "91819172-b153-45d4-93fb-8e1afc39b1f6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Enterprise_AccountStatus",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6679c507-5be9-4630-8100-7f8414e7815e", "AQAAAAEAACcQAAAAEHRN3J9fdXZDW9L1QkCGOkyw37vWXc/8Mm5SmJ8u7Xspm5k0zrOr0J+AHQmS+Rlhgg==", "4cac6f7c-d8a8-4ed9-88ee-9148413f50bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6057533-f445-484d-9fba-55d31c733ae2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d166023b-d505-4e59-ba55-fb518d7a90a8", "AQAAAAEAACcQAAAAEGbJRR5Jw88Gux+SCSKMbuxPdAXXuwE0gTlfw9c5iFqHSOwG5rgcPb0UhVUu2RLo6Q==", "e75bc664-4f42-41eb-99cb-6d0662c2def8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4503440-7d6f-46f5-b821-24764fe03398", "AQAAAAEAACcQAAAAENpFeZXvc1usSKRt6v/S25MY8PJfq1cdfd9T0rfwcWRo7HWTwBsOnT5VNA0ghOvhsQ==", "00cde47f-d630-4a8f-a45a-16cc93e8852b" });
        }
    }
}
