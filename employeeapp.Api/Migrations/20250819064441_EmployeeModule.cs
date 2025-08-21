using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace employeeapp.Api.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmnets",
                columns: table => new
                {
                    DepartmentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentNumber);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Departmnet",
                        column: x => x.DepartmentId,
                        principalTable: "Departmnets",
                        principalColumn: "DepartmentNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departmnets",
                columns: new[] { "DepartmentNumber", "Name" },
                values: new object[,]
                {
                    { 101, "HR" },
                    { 102, "Operations" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, 101, "Ramu", "9876543210" },
                    { 2, 101, "Somu", "4321098765" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departmnets");
        }
    }
}
