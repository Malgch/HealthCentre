using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCentre.Entities
{
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Consultation> Consultations { get; set; } = new List<Consultation>();
    }
}
