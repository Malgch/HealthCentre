using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCentre.Migrations
{
    /// <inheritdoc />
    public partial class SeedConsultation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Consultations (Date, Recommendation, DiagnosisId, DoctorId, PatientId) VALUES ('2023-07-01 09:30:00', 'Take rest and drink plenty of fluids', 1, 1, 1)");
            migrationBuilder.Sql("INSERT INTO Consultations (Date, Recommendation, DiagnosisId, DoctorId, PatientId) VALUES ('2023-07-02 14:45:00', 'Prescribed medication for hypertension', 2, 1, 2)");
            migrationBuilder.Sql("INSERT INTO Consultations (Date, Recommendation, DiagnosisId, DoctorId, PatientId) VALUES ('2023-07-03 11:15:00', 'Recommended dietary changes', 3, 2, 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
