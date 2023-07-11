using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCentre_.Entities
{
    public class Consultation
    {
        public int IdConsultation { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public DateTime? Date { get; set; }
        public int? Diagnosis { get; set; }
        public string Recommendation { get; set; }
    }
}
