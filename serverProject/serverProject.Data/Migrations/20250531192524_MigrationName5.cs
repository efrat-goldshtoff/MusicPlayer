using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serverProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayListSongs");

            migrationBuilder.CreateTable(
                name: "PlayListSong",
                columns: table => new
                {
                    PlayListsId = table.Column<int>(type: "int", nullable: false),
                    SongsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayListSong", x => new { x.PlayListsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_PlayListSong_PlayLists_PlayListsId",
                        column: x => x.PlayListsId,
                        principalTable: "PlayLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayListSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$PzTDxCSplScrihGs9NChSegzT8frIR3.y19yGpvzXJDNwJevbLvym");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$JmNCTpW6kONsoL.xX03VQ.midjze9LCs1TISJAFSqsuKIFruRH3S.");

            migrationBuilder.CreateIndex(
                name: "IX_PlayListSong_SongsId",
                table: "PlayListSong",
                column: "SongsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayListSong");

            migrationBuilder.CreateTable(
                name: "PlayListSongs",
                columns: table => new
                {
                    PlayListsId = table.Column<int>(type: "int", nullable: false),
                    SongsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayListSongs", x => new { x.PlayListsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_PlayListSongs_PlayLists_PlayListsId",
                        column: x => x.PlayListsId,
                        principalTable: "PlayLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayListSongs_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$29Wu6Un4dHOtNMQco8geaOAypXwOtZmDnXMvEWM3QHFrQAPKYoPqa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$Z3v95iYMmE6b64MYqwzLWuBYU9oAZE36W8fNO.M/noAs80L1j/zoq");

            migrationBuilder.CreateIndex(
                name: "IX_PlayListSongs_SongsId",
                table: "PlayListSongs",
                column: "SongsId");
        }
    }
}
