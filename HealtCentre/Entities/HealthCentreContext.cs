using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCentre.Entities;
using System.Windows.Input;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultation>(eb =>
            {
                eb.Property(x => x.Date).IsRequired();
                eb.Property(x => x.Date).HasConversion(v => RoundToNearest15Minutes(v), v => v);
                eb.Property(x => x.Date).HasPrecision(0);

                eb.HasOne(y => y.Patient)
                    .WithMany(p => p.Consultations)
                    .HasForeignKey(y => y.PatientId);

                eb.HasOne(y => y.Doctor)
                    .WithMany(p => p.Consultations)
                    .HasForeignKey(y => y.DoctorId);

                eb.HasOne(y => y.Diagnosis)
                    .WithMany(p => p.Consultations)
                    .HasForeignKey(y => y.DiagnosisId);

                eb.HasIndex(y => new { y.DoctorId, y.Date }).IsUnique();
                eb.HasIndex(y => new { y.PatientId, y.Date }).IsUnique();

            });

            modelBuilder.Entity<Patient>(eb =>
            {
                eb.HasMany(p => p.Consultations)
                    .WithOne(c => c.Patient)
                    .HasForeignKey(c => c.PatientId);
            });

            modelBuilder.Entity<Doctor>(eb =>
            {
                eb.HasMany(p => p.Consultations)
                    .WithOne(c => c.Doctor)
                    .HasForeignKey(c => c.DoctorId);
            });

            modelBuilder.Entity<Diagnosis>(eb =>
            {
                eb.HasMany(p => p.Consultations)
                    .WithOne(c => c.Diagnosis)
                    .HasForeignKey(c => c.DiagnosisId);
            });

        }
        public DateTime RoundToNearest15Minutes(DateTime value)
        {
            int minutes = value.Minute;
            int remainder = minutes % 15;
            if (remainder != 0)
            {
                // Round up or down to the nearest 15 minutes
                int minutesToAdd = remainder < 8 ? -remainder : 15 - remainder;
                value = value.AddMinutes(minutesToAdd);
            }
            return value;
        }

    }

}
