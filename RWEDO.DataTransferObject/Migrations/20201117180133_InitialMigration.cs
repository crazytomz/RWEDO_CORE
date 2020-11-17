using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RWEDO.DataTransferObject.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyFiles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Index = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    InsurerID = table.Column<int>(nullable: false),
                    RepairerID = table.Column<int>(nullable: false),
                    Insured = table.Column<string>(maxLength: 100, nullable: false),
                    EstimateDate = table.Column<string>(nullable: true),
                    BillDate = table.Column<string>(nullable: true),
                    FollowUpDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyFiles", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyFiles");
        }
    }
}
