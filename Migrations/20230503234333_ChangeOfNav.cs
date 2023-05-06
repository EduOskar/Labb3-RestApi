using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3_RestApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOfNav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Persons_PersonId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Interests_InterestId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Persons_PersonId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_InterestId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_PersonId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Interests_PersonId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Interests");

            migrationBuilder.CreateIndex(
                name: "IX_Links_FKinterestId",
                table: "Links",
                column: "FKinterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_FKPersonId",
                table: "Links",
                column: "FKPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_FKPerson",
                table: "Interests",
                column: "FKPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Persons_FKPerson",
                table: "Interests",
                column: "FKPerson",
                principalTable: "Persons",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Interests_FKinterestId",
                table: "Links",
                column: "FKinterestId",
                principalTable: "Interests",
                principalColumn: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Persons_FKPersonId",
                table: "Links",
                column: "FKPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Persons_FKPerson",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Interests_FKinterestId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Persons_FKPersonId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_FKinterestId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_FKPersonId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Interests_FKPerson",
                table: "Interests");

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "Links",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Links",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Interests",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 1,
                column: "PersonId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 2,
                column: "PersonId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 3,
                column: "PersonId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 4,
                column: "PersonId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 5,
                column: "PersonId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 6,
                column: "PersonId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 7,
                column: "PersonId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 1,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 2,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 3,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 4,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 5,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 6,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 7,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 8,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Links_InterestId",
                table: "Links",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId",
                table: "Links",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PersonId",
                table: "Interests",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Persons_PersonId",
                table: "Interests",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Interests_InterestId",
                table: "Links",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Persons_PersonId",
                table: "Links",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");
        }
    }
}
