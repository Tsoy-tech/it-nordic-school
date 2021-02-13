using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorrespondenceEF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostalItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contractors_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sendings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderPassportNumberId = table.Column<int>(type: "int", nullable: true),
                    SenderOfficeIdId = table.Column<int>(type: "int", nullable: true),
                    ReceiverPassportNumberId = table.Column<int>(type: "int", nullable: true),
                    ReceiverOfficeIdId = table.Column<int>(type: "int", nullable: true),
                    PostalItemIdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sendings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sendings_Contractors_ReceiverPassportNumberId",
                        column: x => x.ReceiverPassportNumberId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sendings_Contractors_SenderPassportNumberId",
                        column: x => x.SenderPassportNumberId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sendings_Offices_ReceiverOfficeIdId",
                        column: x => x.ReceiverOfficeIdId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sendings_Offices_SenderOfficeIdId",
                        column: x => x.SenderOfficeIdId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sendings_PostalItems_PostalItemIdId",
                        column: x => x.PostalItemIdId,
                        principalTable: "PostalItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendingIdId = table.Column<int>(type: "int", nullable: true),
                    StatusIdId = table.Column<int>(type: "int", nullable: true),
                    UpdateStatusDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flows_Sendings_SendingIdId",
                        column: x => x.SendingIdId,
                        principalTable: "Sendings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flows_Statuses_StatusIdId",
                        column: x => x.StatusIdId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_PositionId",
                table: "Contractors",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Flows_SendingIdId",
                table: "Flows",
                column: "SendingIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Flows_StatusIdId",
                table: "Flows",
                column: "StatusIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CityId",
                table: "Offices",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Sendings_PostalItemIdId",
                table: "Sendings",
                column: "PostalItemIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Sendings_ReceiverOfficeIdId",
                table: "Sendings",
                column: "ReceiverOfficeIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Sendings_ReceiverPassportNumberId",
                table: "Sendings",
                column: "ReceiverPassportNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Sendings_SenderOfficeIdId",
                table: "Sendings",
                column: "SenderOfficeIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Sendings_SenderPassportNumberId",
                table: "Sendings",
                column: "SenderPassportNumberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flows");

            migrationBuilder.DropTable(
                name: "Sendings");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Contractors");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "PostalItems");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
