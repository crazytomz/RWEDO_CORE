using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RWEDO.DataTransferObject.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Surveyors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    IdentityNumber = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    PhotoPath = table.Column<string>(maxLength: 500, nullable: true),
                    Qualification = table.Column<string>(maxLength: 250, nullable: true),
                    ISDeactivated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveyors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    ISInternal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SurveyFiles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurveyorID = table.Column<int>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(maxLength: 20, nullable: false),
                    InsurerID = table.Column<int>(nullable: false),
                    RepairerName = table.Column<string>(maxLength: 250, nullable: true),
                    RepairerEmail = table.Column<string>(maxLength: 200, nullable: true),
                    Insured = table.Column<string>(maxLength: 100, nullable: false),
                    EstimateDate = table.Column<string>(maxLength: 20, nullable: true),
                    BillDate = table.Column<string>(maxLength: 20, nullable: true),
                    FollowUpDate = table.Column<DateTime>(nullable: false),
                    HasFile = table.Column<bool>(nullable: false),
                    HasEstimate = table.Column<bool>(nullable: false),
                    HasBill = table.Column<bool>(nullable: false),
                    StatusID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SurveyFiles_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyFiles_Surveyors_SurveyorID",
                        column: x => x.SurveyorID,
                        principalTable: "Surveyors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurveyorID = table.Column<int>(nullable: false),
                    UserRoleID = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    ISAdmin = table.Column<bool>(nullable: false),
                    ISDeleted = table.Column<bool>(nullable: false),
                    ISDeactivared = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Surveyors_SurveyorID",
                        column: x => x.SurveyorID,
                        principalTable: "Surveyors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleID",
                        column: x => x.UserRoleID,
                        principalTable: "UserRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "ID", "Description" },
                values: new object[,]
                {
                    { 1, "Opened" },
                    { 2, "File Received" },
                    { 3, "File Received" },
                    { 4, "Surveyed" },
                    { 5, "Estimate Received" },
                    { 6, "Bill Received" },
                    { 7, "Report Prepared" },
                    { 8, "Report Submitted" }
                });

            migrationBuilder.InsertData(
                table: "Surveyors",
                columns: new[] { "ID", "Address", "Email", "ISDeactivated", "IdentityNumber", "Name", "PhoneNumber", "PhotoPath", "Qualification" },
                values: new object[] { 1, null, "thomsonkvarkey@outlook.com", false, "Master", "SAdmin", 0, null, null });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "ID", "ISInternal", "Name" },
                values: new object[,]
                {
                    { 1, true, "SAdmin" },
                    { 2, false, "CEO" },
                    { 3, false, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "ISAdmin", "ISDeactivared", "ISDeleted", "Password", "SurveyorID", "UserName", "UserRoleID" },
                values: new object[] { 1, true, false, false, "sa@2020", 1, "sadmin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyFiles_StatusID",
                table: "SurveyFiles",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyFiles_SurveyorID",
                table: "SurveyFiles",
                column: "SurveyorID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SurveyorID",
                table: "Users",
                column: "SurveyorID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleID",
                table: "Users",
                column: "UserRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyFiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Surveyors");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
