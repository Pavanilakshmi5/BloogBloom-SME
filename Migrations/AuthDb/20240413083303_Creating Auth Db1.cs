using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloogBloom.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class CreatingAuthDb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "472ba632-6133-44a1-b158-6c10bd7d850d",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "04d57b31-475b-418f-99f8-e0c61578b6f4", "superadmin@bloog.com", "SUPERADMIN@BLOOG.COM", "SUPERADMIN@BLOOG.COM", "AQAAAAIAAYagAAAAELAAE5boXYl15rnLib0Bor871b/B3SNzdiSu23XA6K+u5rEonXCgSUOCK2LgeyN0ng==", "68796361-10a3-4b99-bfac-d13ed16be971", "superadmin@bloog.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "472ba632-6133-44a1-b158-6c10bd7d850d",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "0ce8e159-8c72-4a48-a08e-05bad6c5e5c0", "superadmin@bloggie.com", "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAIAAYagAAAAEPDFkfu40qNSZ/nrxKwpzHTevSS2wbiwWtjF/xc3cGsFSGLbswRhaKCDIA16xrwZCA==", "86c71a53-87c5-41a0-9f0f-7f2562b1864e", "superadmin@bloggie.com" });
        }
    }
}
