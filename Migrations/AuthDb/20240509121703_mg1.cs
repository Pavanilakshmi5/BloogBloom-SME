using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloogBloom.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "472ba632-6133-44a1-b158-6c10bd7d850d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d87893a-89b0-45ee-bb09-c62daedfa91f", "AQAAAAIAAYagAAAAEPyq1zcDhNjJQ39eoFscLnBSkJvgXcSR2HnkIhQI2VYrxXWiQTlKFSSytq70mHn4mw==", "511cc5f5-4654-4d56-85e3-dffb51c1ec07" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "472ba632-6133-44a1-b158-6c10bd7d850d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04d57b31-475b-418f-99f8-e0c61578b6f4", "AQAAAAIAAYagAAAAELAAE5boXYl15rnLib0Bor871b/B3SNzdiSu23XA6K+u5rEonXCgSUOCK2LgeyN0ng==", "68796361-10a3-4b99-bfac-d13ed16be971" });
        }
    }
}
