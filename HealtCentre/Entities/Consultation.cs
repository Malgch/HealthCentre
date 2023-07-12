using HealthCentre.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCentre.Entities
{
    public class Consultation
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Recommendation { get; set; }

        public Diagnosis? Diagnosis { get; set; }
        public int DiagnosisId { get; set; }

        public Doctor Doctor { get; set; }
        public int DoctorId { get; set;}

        public Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}
