using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCentre.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdatePatientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
        name: "Pesel",
        table: "Patients");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
