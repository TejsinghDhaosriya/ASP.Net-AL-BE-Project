using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Meter_API.Migrations
{
    public partial class MigrationV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Citiesid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.id);
                    table.ForeignKey(
                        name: "FK_Facilities_cities_Citiesid",
                        column: x => x.Citiesid,
                        principalTable: "cities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "buildings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Facilitiesid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildings", x => x.id);
                    table.ForeignKey(
                        name: "FK_buildings_Facilities_Facilitiesid",
                        column: x => x.Facilitiesid,
                        principalTable: "Facilities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "floors",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Buildingsid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_floors", x => x.id);
                    table.ForeignKey(
                        name: "FK_floors_buildings_Buildingsid",
                        column: x => x.Buildingsid,
                        principalTable: "buildings",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "zones",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Floorsid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zones", x => x.id);
                    table.ForeignKey(
                        name: "FK_zones_floors_Floorsid",
                        column: x => x.Floorsid,
                        principalTable: "floors",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "meters",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Zonesid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meters", x => x.id);
                    table.ForeignKey(
                        name: "FK_meters_zones_Zonesid",
                        column: x => x.Zonesid,
                        principalTable: "zones",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_buildings_Facilitiesid",
                table: "buildings",
                column: "Facilitiesid");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_Citiesid",
                table: "Facilities",
                column: "Citiesid");

            migrationBuilder.CreateIndex(
                name: "IX_floors_Buildingsid",
                table: "floors",
                column: "Buildingsid");

            migrationBuilder.CreateIndex(
                name: "IX_meters_Zonesid",
                table: "meters",
                column: "Zonesid");

            migrationBuilder.CreateIndex(
                name: "IX_zones_Floorsid",
                table: "zones",
                column: "Floorsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "meters");

            migrationBuilder.DropTable(
                name: "zones");

            migrationBuilder.DropTable(
                name: "floors");

            migrationBuilder.DropTable(
                name: "buildings");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
