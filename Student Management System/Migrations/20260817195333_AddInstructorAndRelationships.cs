using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Student_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddInstructorAndRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                    table.CheckConstraint("CK_Student_Age", " [Age] >=16");
                    table.CheckConstraint("CK_Student_Email", "[Email] LIKE '%@%.%'");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriptoin = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    DurationInHours = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Email", "Name", "Specialization" },
                values: new object[,]
                {
                    { 1, "mohamed@gmail.com", "Mohamed Ahmed", "C# Programming" },
                    { 2, "ahmed@gmail.com", "Ahmed Hassan", "Database Systems" },
                    { 3, "omar@gmail.com", "Omar Ali", "Web Development" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "Id", "Age", "Email", "Name", "Percentage" },
                values: new object[,]
                {
                    { 1, 20, "ahmed@gmail.com", "Ahmed Ali", 85.50m },
                    { 2, 19, "sara@gmail.com", "Sara Mohamed", 91.25m },
                    { 3, 21, "omar@gmail.com", "Omar Hassan", 78.75m },
                    { 4, 18, "mona@gmail.com", "Mona Ahmed", 88.00m },
                    { 5, 22, "youssef@gmail.com", "Youssef Ali", 95.50m },
                    { 6, 20, "nour@gmail.com", "Nour Khaled", 82.25m },
                    { 7, 19, "hana@gmail.com", "Hana Samir", 90.00m },
                    { 8, 23, "mahmoud@gmail.com", "Mahmoud Adel", 76.50m },
                    { 9, 18, "laila@gmail.com", "Laila Hassan", 93.75m },
                    { 10, 21, "khaled@gmail.com", "Khaled Mostafa", 87.50m }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Descriptoin", "DurationInHours", "InstructorId", "Name" },
                values: new object[,]
                {
                    { 1, "Introduction to C# programming", 40, 1, "C# Programming" },
                    { 2, "Introduction to databases and SQL", 35, 2, "Database Systems" },
                    { 3, "Arrays, linked lists, stacks, queues and trees", 45, 1, "Data Structures" },
                    { 4, "Fundamentals of web development", 50, 2, "Web Development" },
                    { 5, "Software development principles and practices", 30, 1, "Software Engineering" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
