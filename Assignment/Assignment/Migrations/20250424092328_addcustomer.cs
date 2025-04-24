using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class addcustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GenderId = table.Column<byte>(type: "tinyint", nullable: false),
                    StateId = table.Column<short>(type: "smallint", nullable: false),
                    DistrictId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInfo");
        }
    }
}
