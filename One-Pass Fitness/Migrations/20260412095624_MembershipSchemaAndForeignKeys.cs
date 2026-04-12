using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One_Pass_Fitness.Migrations
{
    /// <inheritdoc />
    public partial class MembershipSchemaAndForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MembershipType",
                table: "Memberships",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "Annual");

            migrationBuilder.RenameTable(
                name: "Memberships",
                newName: "Membership");

            migrationBuilder.RenameColumn(
                name: "MembershipInfoid",
                table: "Membership",
                newName: "Membershipid");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_Personid",
                table: "Trainers",
                column: "Personid");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Personid",
                table: "Members",
                column: "Personid");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_Personid",
                table: "Manager",
                column: "Personid");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Trainerid",
                table: "Classes",
                column: "Trainerid");

            migrationBuilder.CreateIndex(
                name: "IX_BookingClasses_Classid",
                table: "BookingClasses",
                column: "Classid");

            migrationBuilder.CreateIndex(
                name: "IX_BookingClasses_Memberid",
                table: "BookingClasses",
                column: "Memberid");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_Memberid",
                table: "Membership",
                column: "Memberid");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingClasses_Classes_Classid",
                table: "BookingClasses",
                column: "Classid",
                principalTable: "Classes",
                principalColumn: "ClassesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingClasses_Members_Memberid",
                table: "BookingClasses",
                column: "Memberid",
                principalTable: "Members",
                principalColumn: "Memberid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Trainers_Trainerid",
                table: "Classes",
                column: "Trainerid",
                principalTable: "Trainers",
                principalColumn: "Trainersid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Personalinfo_Personid",
                table: "Manager",
                column: "Personid",
                principalTable: "Personalinfo",
                principalColumn: "Personalinfoid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Personalinfo_Personid",
                table: "Members",
                column: "Personid",
                principalTable: "Personalinfo",
                principalColumn: "Personalinfoid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Members_Memberid",
                table: "Membership",
                column: "Memberid",
                principalTable: "Members",
                principalColumn: "Memberid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Personalinfo_Personid",
                table: "Trainers",
                column: "Personid",
                principalTable: "Personalinfo",
                principalColumn: "Personalinfoid",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingClasses_Classes_Classid",
                table: "BookingClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingClasses_Members_Memberid",
                table: "BookingClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Trainers_Trainerid",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Personalinfo_Personid",
                table: "Manager");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Personalinfo_Personid",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Members_Memberid",
                table: "Membership");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Personalinfo_Personid",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_Personid",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Members_Personid",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Manager_Personid",
                table: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_Classes_Trainerid",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_BookingClasses_Classid",
                table: "BookingClasses");

            migrationBuilder.DropIndex(
                name: "IX_BookingClasses_Memberid",
                table: "BookingClasses");

            migrationBuilder.DropIndex(
                name: "IX_Membership_Memberid",
                table: "Membership");

            migrationBuilder.RenameColumn(
                name: "Membershipid",
                table: "Membership",
                newName: "MembershipInfoid");

            migrationBuilder.RenameTable(
                name: "Membership",
                newName: "Memberships");

            migrationBuilder.DropColumn(
                name: "MembershipType",
                table: "Memberships");
        }
    }
}
