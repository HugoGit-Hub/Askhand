using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskHand.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIdOne = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIdTwo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartFriendshipDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndFriendshipDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaData_FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MetaData_LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MetaData_Age = table.Column<int>(type: "int", nullable: false),
                    MetaData_PictureProfilPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skill_Level = table.Column<int>(type: "int", nullable: false),
                    City_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Walls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level_Rate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_ZipCode_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Climbs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstimationTime = table.Column<double>(type: "float", nullable: false),
                    ValidationRate = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WallId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Climbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Climbs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Climbs_Walls_WallId",
                        column: x => x.WallId,
                        principalTable: "Walls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Climbs_UserId",
                table: "Climbs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Climbs_WallId",
                table: "Climbs",
                column: "WallId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Climbs");

            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Walls");
        }
    }
}
