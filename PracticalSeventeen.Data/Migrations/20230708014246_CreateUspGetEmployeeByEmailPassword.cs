using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticalSeventeen.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateUspGetEmployeeByEmailPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var sp = @"-- =============================================
-- Author:		Bhavin Kareliya
-- Create date: 08-07-2023
-- Description:	returns user details with role
-- =============================================
CREATE PROCEDURE usp_GetUserDetailsByEmailPassword 
	@Email varchar(320), 
	@Password varchar(120)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT u.*, r.RoleName from [dbo].[Users] u
	JOIN UserRoles ur ON u.Id = ur.UserId
	JOIN Roles r ON ur.RoleId = r.Id
	WHERE [Email] = @Email AND [Password] = @Password
END";

            migrationBuilder.Sql(sp);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE usp_GetUserDetailsByEmailPassword");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(320)",
                oldMaxLength: 320);
        }
    }
}
