using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One_Pass_Fitness.Migrations
{
    /// <inheritdoc />
    public partial class finalisingmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Roles_RoleId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Roles_Roleid",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "MembershipType",
                table: "Membership");

            migrationBuilder.RenameColumn(
                name: "Rolesid",
                table: "Roles",
                newName: "Roleid");

            migrationBuilder.RenameColumn(
                name: "Roleid",
                table: "Membership",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_Membership_Roleid",
                table: "Membership",
                newName: "IX_Membership_Userid");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Classes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_RoleId",
                table: "Classes",
                newName: "IX_Classes_UserId");

            migrationBuilder.AddColumn<int>(
                name: "RolesRoleid",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Usersid",
                table: "Personalinfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesRoleid",
                table: "Users",
                column: "RolesRoleid");

            migrationBuilder.CreateIndex(
                name: "IX_Personalinfo_Usersid",
                table: "Personalinfo",
                column: "Usersid");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Users_UserId",
                table: "Classes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Usersid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Users_Userid",
                table: "Membership",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Usersid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personalinfo_Users_Usersid",
                table: "Personalinfo",
                column: "Usersid",
                principalTable: "Users",
                principalColumn: "Usersid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolesRoleid",
                table: "Users",
                column: "RolesRoleid",
                principalTable: "Roles",
                principalColumn: "Roleid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Users_UserId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Users_Userid",
                table: "Membership");

            migrationBuilder.DropForeignKey(
                name: "FK_Personalinfo_Users_Usersid",
                table: "Personalinfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolesRoleid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolesRoleid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Personalinfo_Usersid",
                table: "Personalinfo");

            migrationBuilder.DropColumn(
                name: "RolesRoleid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Usersid",
                table: "Personalinfo");

            migrationBuilder.RenameColumn(
                name: "Roleid",
                table: "Roles",
                newName: "Rolesid");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "Membership",
                newName: "Roleid");

            migrationBuilder.RenameIndex(
                name: "IX_Membership_Userid",
                table: "Membership",
                newName: "IX_Membership_Roleid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Classes",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_UserId",
                table: "Classes",
                newName: "IX_Classes_RoleId");

            migrationBuilder.AddColumn<string>(
                name: "MembershipType",
                table: "Membership",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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
    }
}
