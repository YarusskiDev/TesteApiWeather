using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteWeatherApi.Migrations
{
    /// <inheritdoc />
    public partial class bd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseWeather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Base = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    Dt = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timezone = table.Column<int>(type: "int", nullable: false),
                    Cod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseWeather", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clouds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseWeatherEntityId = table.Column<int>(type: "int", nullable: false),
                    All = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clouds_BaseWeather_BaseWeatherEntityId",
                        column: x => x.BaseWeatherEntityId,
                        principalTable: "BaseWeather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseWeatherEntityId = table.Column<int>(type: "int", nullable: false),
                    Lon = table.Column<float>(type: "real", nullable: false),
                    Lat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coord_BaseWeather_BaseWeatherEntityId",
                        column: x => x.BaseWeatherEntityId,
                        principalTable: "BaseWeather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseWeatherEntityId = table.Column<int>(type: "int", nullable: false),
                    Temp = table.Column<float>(type: "real", nullable: false),
                    Feels_like = table.Column<float>(type: "real", nullable: false),
                    Temp_min = table.Column<float>(type: "real", nullable: false),
                    Temp_max = table.Column<float>(type: "real", nullable: false),
                    Pressure = table.Column<int>(type: "int", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Main_BaseWeather_BaseWeatherEntityId",
                        column: x => x.BaseWeatherEntityId,
                        principalTable: "BaseWeather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseWeatherEntityId = table.Column<int>(type: "int", nullable: false),
                    _1H = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rain_BaseWeather_BaseWeatherEntityId",
                        column: x => x.BaseWeatherEntityId,
                        principalTable: "BaseWeather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BaseWeatherEntityId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sunrise = table.Column<int>(type: "int", nullable: false),
                    Sunset = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sys_BaseWeather_BaseWeatherEntityId",
                        column: x => x.BaseWeatherEntityId,
                        principalTable: "BaseWeather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BaseWeatherEntityId = table.Column<int>(type: "int", nullable: false),
                    Main = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weather_BaseWeather_BaseWeatherEntityId",
                        column: x => x.BaseWeatherEntityId,
                        principalTable: "BaseWeather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wind",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseWeatherEntityId = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<float>(type: "real", nullable: false),
                    Deg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wind", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wind_BaseWeather_BaseWeatherEntityId",
                        column: x => x.BaseWeatherEntityId,
                        principalTable: "BaseWeather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clouds_BaseWeatherEntityId",
                table: "Clouds",
                column: "BaseWeatherEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coord_BaseWeatherEntityId",
                table: "Coord",
                column: "BaseWeatherEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Main_BaseWeatherEntityId",
                table: "Main",
                column: "BaseWeatherEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rain_BaseWeatherEntityId",
                table: "Rain",
                column: "BaseWeatherEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sys_BaseWeatherEntityId",
                table: "Sys",
                column: "BaseWeatherEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weather_BaseWeatherEntityId",
                table: "Weather",
                column: "BaseWeatherEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Wind_BaseWeatherEntityId",
                table: "Wind",
                column: "BaseWeatherEntityId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clouds");

            migrationBuilder.DropTable(
                name: "Coord");

            migrationBuilder.DropTable(
                name: "Main");

            migrationBuilder.DropTable(
                name: "Rain");

            migrationBuilder.DropTable(
                name: "Sys");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Wind");

            migrationBuilder.DropTable(
                name: "BaseWeather");
        }
    }
}
