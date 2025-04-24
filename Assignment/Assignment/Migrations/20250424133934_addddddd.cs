using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class addddddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Districts");

            migrationBuilder.AddColumn<short>(
                name: "Id",
                table: "States",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<short>(
                name: "StateId",
                table: "Districts",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<short>(
                name: "Id",
                table: "Districts",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { (short)1, "Maharashtra" },
                    { (short)2, "Tamil Nadu" },
                    { (short)3, "Uttar Pradesh" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "StateId" },
                values: new object[,]
                {
                    { (short)1, "Mumbai", (short)1 },
                    { (short)2, "Pune", (short)1 },
                    { (short)3, "Nagpur", (short)1 },
                    { (short)4, "Chennai", (short)2 },
                    { (short)5, "Madurai", (short)2 },
                    { (short)6, "Coimbatore", (short)2 },
                    { (short)7, "Lucknow", (short)3 },
                    { (short)8, "Kanpur", (short)3 },
                    { (short)9, "Agra", (short)3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_StateId",
                table: "Districts",
                column: "StateId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_States_StateId",
                table: "Districts",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInfo_Districts_DistrictId",
                table: "CustomerInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_States_StateId",
                table: "Districts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_Districts_StateId",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInfo_DistrictId",
                table: "CustomerInfo");

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyColumnType: "smallint",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyColumnType: "smallint",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyColumnType: "smallint",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyColumnType: "smallint",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyColumnType: "smallint",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyColumnType: "smallint",
                keyValue: (short)6);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyColumnType: "smallint",
                keyValue: (short)7);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyColumnType: "smallint",
                keyValue: (short)8);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyColumnType: "smallint",
                keyValue: (short)9);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyColumnType: "smallint",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyColumnType: "smallint",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyColumnType: "smallint",
                keyValue: (short)3);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "States");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Districts");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "States",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Districts",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Districts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "DistrictId");
        }
    }
}
