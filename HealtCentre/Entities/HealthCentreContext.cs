using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCentre_.Entities;
using HealthCentre.Entities;

namespace HealtCentre.Entities
{
    public class HealthCentreContext : DbContext
    {
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }       
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HealthCentreDb;Trusted_Connection=True;");
        }


    }
}
