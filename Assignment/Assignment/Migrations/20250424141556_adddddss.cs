using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class adddddss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInfo_Districts_DistrictId",
                table: "CustomerInfo");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInfo_DistrictId",
                table: "CustomerInfo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CustomerInfo_DistrictId",
                table: "CustomerInfo",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInfo_Districts_DistrictId",
                table: "CustomerInfo",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
