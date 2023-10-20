using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payroll.Data.Migrations
{
    /// <inheritdoc />
    public partial class Employees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyBranch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBranch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KraPin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhifNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NssfNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyBranchId = table.Column<int>(type: "int", nullable: false),
                    CompanyDepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_CompanyBranch_CompanyBranchId",
                        column: x => x.CompanyBranchId,
                        principalTable: "CompanyBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_CompanyDepartment_CompanyDepartmentId",
                        column: x => x.CompanyDepartmentId,
                        principalTable: "CompanyDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyBranchId",
                table: "Employee",
                column: "CompanyBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyDepartmentId",
                table: "Employee",
                column: "CompanyDepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "CompanyBranch");

            migrationBuilder.DropTable(
                name: "CompanyDepartment");
        }
    }
}
