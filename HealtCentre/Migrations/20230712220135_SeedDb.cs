using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCentre.Migrations
{
    /// <inheritdoc />
    public partial class SeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Patients (Name, Surname) VALUES ('John', 'Doe')");
            migrationBuilder.Sql("INSERT INTO Patients (Name, Surname) VALUES ('Jane', 'Smith')");
            migrationBuilder.Sql("INSERT INTO Patients (Name, Surname) VALUES ('Hayden','Emerson')");

            migrationBuilder.Sql("INSERT INTO Doctors (Name, Surname, Specialization) VALUES ('Smith', 'Johnson', 'Cardiology')");
            migrationBuilder.Sql("INSERT INTO Doctors (Name, Surname, Specialization) VALUES ('Emily', 'Brown', 'Dermatology')");
            migrationBuilder.Sql("INSERT INTO Doctors (Name, Surname, Specialization) VALUES ('Cullen','Martinez', 'Anesthesiology')");
            migrationBuilder.Sql("INSERT INTO Doctors (Name, Surname, Specialization) VALUES ('Leo','Best','Internal medicine')");
            migrationBuilder.Sql("INSERT INTO Doctors (Name, Surname, Specialization) VALUES ('Burton','Baird','Allergy and immunology')");

            migrationBuilder.Sql("INSERT INTO Diagnoses (Description) VALUES ('Common Cold')");
            migrationBuilder.Sql("INSERT INTO Diagnoses (Description) VALUES ('Hypertension')");
            migrationBuilder.Sql("INSERT INTO Diagnoses (Description) VALUES ('Headaches')");
            migrationBuilder.Sql("INSERT INTO Diagnoses (Description) VALUES ('Stomach Aches')");
            migrationBuilder.Sql("INSERT INTO Diagnoses (Description) VALUES ('Allergies')");
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
