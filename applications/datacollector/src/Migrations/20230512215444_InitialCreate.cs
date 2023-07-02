using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace datacollector.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    co = table.Column<double>(type: "double", nullable: false),
                    no = table.Column<double>(type: "double", nullable: false),
                    no2 = table.Column<double>(type: "double", nullable: false),
                    o3 = table.Column<double>(type: "double", nullable: false),
                    so2 = table.Column<double>(type: "double", nullable: false),
                    pm25 = table.Column<double>(name: "pm2_5", type: "double", nullable: false),
                    pm10 = table.Column<double>(type: "double", nullable: false),
                    nh3 = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AQIDataPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    dt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    componentsId = table.Column<Guid>(type: "char(36)", nullable: true),
                    main = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AQIDataPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AQIDataPoints_Components_componentsId",
                        column: x => x.componentsId,
                        principalTable: "Components",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AQIDataPoints_componentsId",
                table: "AQIDataPoints",
                column: "componentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AQIDataPoints");

            migrationBuilder.DropTable(
                name: "Components");
        }
    }
}
