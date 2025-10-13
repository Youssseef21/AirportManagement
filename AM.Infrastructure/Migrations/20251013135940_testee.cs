using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    NumTicket = table.Column<int>(type: "int", nullable: false),
                    Passengerfk = table.Column<int>(type: "int", nullable: false),
                    Flightfk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false),
                    Siege = table.Column<int>(type: "int", nullable: false),
                    DateAchat = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.NumTicket, x.Passengerfk, x.Flightfk });
                    table.ForeignKey(
                        name: "FK_Tickets_Flights_Flightfk",
                        column: x => x.Flightfk,
                        principalTable: "Flights",
                        principalColumn: "flightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_Passengerfk",
                        column: x => x.Passengerfk,
                        principalTable: "Passengers",
                        principalColumn: "PassengerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Flightfk",
                table: "Tickets",
                column: "Flightfk");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Passengerfk",
                table: "Tickets",
                column: "Passengerfk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
