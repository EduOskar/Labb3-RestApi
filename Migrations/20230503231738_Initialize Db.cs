using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3_RestApi.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKPerson = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKPersonId = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    FKinterestId = table.Column<int>(type: "int", nullable: true),
                    InterestId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId");
                    table.ForeignKey(
                        name: "FK_Links_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Description", "FKPerson", "PersonId", "Title" },
                values: new object[,]
                {
                    { 1, "Ultimate competition combined of all martial arts in the world", 1, null, "MMA" },
                    { 2, "There is plethora of games that i like, but i prefer competetive once", 1, null, "Gaming" },
                    { 3, "Coding holds a huge intrest considering its my potential future", 1, null, "Muaythai" },
                    { 4, "Reality shows are very fun because i like to see drama", 2, null, "RealityShows" },
                    { 5, "Killing younglings for the good of the future", 3, null, "DarkSide" },
                    { 6, "I like rebellions and kissing siblings", 4, null, "Rebellions" },
                    { 7, "Star constelations are beautiful", 2, null, "Stargazing" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "FKPersonId", "FKinterestId", "InterestId", "PersonId", "Title", "URL" },
                values: new object[,]
                {
                    { 1, 1, 1, null, null, "MMA clip", "https://www.youtube.com/watch?v=LNySNc76NNU" },
                    { 2, 2, 2, null, null, "Gaming", "https://eu.shop.battle.net/en-gb?from=root" },
                    { 3, 3, 3, null, null, "Muaythai", "https://www.facebook.com/Drakstadenmuaythai/?locale=sv_SE" },
                    { 4, 4, 4, null, null, "RealityShows", "" },
                    { 5, 1, 3, null, null, "", "" },
                    { 6, 1, 5, null, null, "DarkSide", "https://www.youtube.com/watch?v=Ogcd-etnFLw" },
                    { 7, 2, 7, null, null, "Rebellions", "https://www.youtube.com/watch?v=m8drjLtX1Wc" },
                    { 8, 4, 6, null, null, "Rebellion", "https://www.youtube.com/watch?v=Ogcd-etnFLw" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Oskar", "Åhling", "070-2138149" },
                    { 2, "Ina", "Nilsson", "074-2251267" },
                    { 3, "Anakin", "Skywalker", "076-7643267" },
                    { 4, "Leia", "Solo", "072-1234567" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PersonId",
                table: "Interests",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_InterestId",
                table: "Links",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId",
                table: "Links",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
