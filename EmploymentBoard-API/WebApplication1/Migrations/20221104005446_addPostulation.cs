using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeTrabajoAPI.Migrations
{
    public partial class addPostulation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postulation_AspNetUsers_StudentId",
                table: "Postulation");

            migrationBuilder.DropForeignKey(
                name: "FK_Postulation_JobOffers_JobOfferId",
                table: "Postulation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Postulation",
                table: "Postulation");

            migrationBuilder.RenameTable(
                name: "Postulation",
                newName: "Postulations");

            migrationBuilder.RenameIndex(
                name: "IX_Postulation_StudentId",
                table: "Postulations",
                newName: "IX_Postulations_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Postulation_JobOfferId",
                table: "Postulations",
                newName: "IX_Postulations_JobOfferId");

            migrationBuilder.AlterColumn<string>(
                name: "Presentation",
                table: "Postulations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "LinkCV",
                table: "Postulations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Postulations",
                table: "Postulations",
                column: "Id");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fa600eb-27f0-44bc-8bcf-96add41a275f", "AQAAAAEAACcQAAAAEPtw5ypFQhLszAWPSXJOAhsjdWVD+QAMbNav8w2DltMGpQ51bIGOzSw1e9Q0gHq4sA==", "fca88f36-ae25-4d6d-865e-d6e1ed4b0d5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bfb048d-3227-4a5d-b382-84498ec2a557", "AQAAAAEAACcQAAAAEJ7sN4b0OsGwwcmT+E0Mixp8O+d+oq+lHhlFbH+JHUas/YlDzcXMOwSsZeUwy+JC5w==", "bc5a1bc0-2ded-49eb-858d-1a169c69bd60" });

            migrationBuilder.InsertData(
                table: "Postulations",
                columns: new[] { "Id", "CreationDate", "JobOfferId", "LinkCV", "Presentation", "StudentId" },
                values: new object[] { 1, new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Link a CV", "Voy con la mejor de las ondas", "76895656-8a86-4562-8007-f494db986a04" });

            migrationBuilder.AddForeignKey(
                name: "FK_Postulations_AspNetUsers_StudentId",
                table: "Postulations",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Postulations_JobOffers_JobOfferId",
                table: "Postulations",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postulations_AspNetUsers_StudentId",
                table: "Postulations");

            migrationBuilder.DropForeignKey(
                name: "FK_Postulations_JobOffers_JobOfferId",
                table: "Postulations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Postulations",
                table: "Postulations");

            migrationBuilder.DeleteData(
                table: "Postulations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Postulations",
                newName: "Postulation");

            migrationBuilder.RenameIndex(
                name: "IX_Postulations_StudentId",
                table: "Postulation",
                newName: "IX_Postulation_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Postulations_JobOfferId",
                table: "Postulation",
                newName: "IX_Postulation_JobOfferId");

            migrationBuilder.AlterColumn<string>(
                name: "Presentation",
                table: "Postulation",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkCV",
                table: "Postulation",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Postulation",
                table: "Postulation",
                column: "Id");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27d7861f-1d6a-427a-96e7-92b9299f9863", "AQAAAAEAACcQAAAAEKtLIt2MIaz8+SdfqKyR6WOVIpvzLrPiegms2v2a6rKydSQ+O762aLdwdGYsT9WhNQ==", "db19125d-64f6-4f30-86d3-ca815703c922" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76895656-8a86-4562-8007-f494db986a04",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2da799f-16d3-4b0d-9d70-a15208c1fe3f", "AQAAAAEAACcQAAAAEPOxi4F0DX414kD2D5pOJFL1Mw6OH3MCKzJ+pV3VY315nIQ7Sgi2hlBBSLvji0kmxA==", "eaeaddc4-7f36-4f74-ae14-371ed6b3fcaa" });

            migrationBuilder.AddForeignKey(
                name: "FK_Postulation_AspNetUsers_StudentId",
                table: "Postulation",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Postulation_JobOffers_JobOfferId",
                table: "Postulation",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
