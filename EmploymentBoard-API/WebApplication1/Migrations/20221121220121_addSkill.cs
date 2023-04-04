using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeTrabajoAPI.Migrations
{
    public partial class addSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillName = table.Column<string>(type: "TEXT", nullable: true),
                    Level = table.Column<string>(type: "TEXT", nullable: false),
                    StudentId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b13f4dc-9570-4487-9b30-5b53b1539b12", "AQAAAAEAACcQAAAAEJ4smsNEkWUMl/CKupWhsrG5z1f2ykcKRmAYMpCofDu/NB9AfvU6jD9hSiQ3I3ohlg==", "fe0f2892-ffa8-4c75-8600-7a0518f4f5bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6057533-f445-484d-9fba-55d31c733ae2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "558241e7-6b6a-4b02-bb77-933ed221dd31", "AQAAAAEAACcQAAAAEGmuxm978UBHsnaQk9lPXsI610F71APU+dMlw7PkD0hLYCte7uQx1P4UoDNEuQgnlA==", "7b96f6dc-b453-4ad6-8b1d-c99df2a98104" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e685784-5f40-408c-95f9-57675153453f", "AQAAAAEAACcQAAAAECgf1gCyNJY+xqaTj2Pdecz7iHntZQ9oyAR7HYLpBzEbLepWoHKWLv8cPxKEL78NJw==", "e25498bc-5f47-45fe-875a-5e8156120f3f" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Level", "SkillName", "StudentId" },
                values: new object[] { 1, "0", "C#", "76895656-8a86-4562-8007-f494db986a04" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Level", "SkillName", "StudentId" },
                values: new object[] { 2, "0", "React", "76895656-8a86-4562-8007-f494db986a04" });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_StudentId",
                table: "Skills",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb9d6d29-828a-4754-9eeb-46ec106351e4", "AQAAAAEAACcQAAAAELV3VTeP/ifMFRQi0iwlI0/a5Vvm6Odm5p3sbcWRKFNO0O6FSN0rYqbe3U8EFyo93A==", "d324328f-91a1-471c-b693-bed0f0a094c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35561a2f-0a78-44e1-9a5d-19444d8521ae", "AQAAAAEAACcQAAAAEHAB4aAvqW3wNzodGkuuj1LKcOcvSwmKJWuSiuDYbrm3cwcj0P5IdZuVWMo4k4+ebA==", "5c5c5e75-13ca-4c1a-aae8-1b5d2889365c" });
        }
    }
}
