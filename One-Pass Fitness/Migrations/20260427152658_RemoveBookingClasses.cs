using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One_Pass_Fitness.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBookingClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Trainers_Trainerid",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Members_Memberid",
                table: "Membership");

            migrationBuilder.DropTable(
                name: "BookingClasses");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.RenameColumn(
                name: "Memberid",
                table: "Membership",
                newName: "Roleid");

            migrationBuilder.RenameIndex(
                name: "IX_Membership_Memberid",
                table: "Membership",
                newName: "IX_Membership_Roleid");

            migrationBuilder.RenameColumn(
                name: "Trainerid",
                table: "Classes",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_Trainerid",
                table: "Classes",
                newName: "IX_Classes_RoleId");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Rolesid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Rolesid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Usersid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personid = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Usersid);
                    table.ForeignKey(
                        name: "FK_Users_Personalinfo_Personid",
                        column: x => x.Personid,
                        principalTable: "Personalinfo",
                        principalColumn: "Personalinfoid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Personid",
                table: "Users",
                column: "Personid");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Roles_RoleId",
                table: "Classes",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Rolesid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Roles_Roleid",
                table: "Membership",
                column: "Roleid",
                principalTable: "Roles",
                principalColumn: "Rolesid",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Roles_RoleId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Roles_Roleid",
                table: "Membership");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "Roleid",
                table: "Membership",
                newName: "Memberid");

            migrationBuilder.RenameIndex(
                name: "IX_Membership_Roleid",
                table: "Membership",
                newName: "IX_Membership_Memberid");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Classes",
                newName: "Trainerid");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_RoleId",
                table: "Classes",
                newName: "IX_Classes_Trainerid");

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Managerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Managerid);
                    table.ForeignKey(
                        name: "FK_Manager_Personalinfo_Personid",
                        column: x => x.Personid,
                        principalTable: "Personalinfo",
                        principalColumn: "Personalinfoid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Memberid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personid = table.Column<int>(type: "int", nullable: false),
                    Datejoined = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Memberid);
                    table.ForeignKey(
                        name: "FK_Members_Personalinfo_Personid",
                        column: x => x.Personid,
                        principalTable: "Personalinfo",
                        principalColumn: "Personalinfoid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Trainersid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personid = table.Column<int>(type: "int", nullable: false),
                    Datehired = table.Column<DateOnly>(type: "date", nullable: false),
                    Trainedfield = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Trainersid);
                    table.ForeignKey(
                        name: "FK_Trainers_Personalinfo_Personid",
                        column: x => x.Personid,
                        principalTable: "Personalinfo",
                        principalColumn: "Personalinfoid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingClasses",
                columns: table => new
                {
                    BookingClassesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classid = table.Column<int>(type: "int", nullable: false),
                    Memberid = table.Column<int>(type: "int", nullable: false),
                    Attendancestatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bookingdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingClasses", x => x.BookingClassesId);
                    table.ForeignKey(
                        name: "FK_BookingClasses_Classes_Classid",
                        column: x => x.Classid,
                        principalTable: "Classes",
                        principalColumn: "ClassesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingClasses_Members_Memberid",
                        column: x => x.Memberid,
                        principalTable: "Members",
                        principalColumn: "Memberid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingClasses_Classid",
                table: "BookingClasses",
                column: "Classid");

            migrationBuilder.CreateIndex(
                name: "IX_BookingClasses_Memberid",
                table: "BookingClasses",
                column: "Memberid");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Personid",
                table: "Manager",
                column: "Personid");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Personid",
                table: "Members",
                column: "Personid");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_Personid",
                table: "Trainers",
                column: "Personid");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Trainers_Trainerid",
                table: "Classes",
                column: "Trainerid",
                principalTable: "Trainers",
                principalColumn: "Trainersid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Members_Memberid",
                table: "Membership",
                column: "Memberid",
                principalTable: "Members",
                principalColumn: "Memberid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
