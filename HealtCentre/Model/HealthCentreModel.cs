using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealtCentre.Entities;
using HealthCentre.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthCentre.Model
{
    public class HealthCentreModel
    {
        private readonly HealthCentreContext _context;

        public HealthCentreModel(HealthCentreContext context)
        {
            _context = context;
        }

        public void AddConsultation(Consultation consultation)
        {
            _context.Consultations.Add(consultation);
            _context.SaveChanges();
        }

        public void RemoveConsultation(int consultationId)
        {
            var consultation = _context.Consultations.Find(consultationId);
            if (consultation != null)
            {
                _context.Consultations.Remove(consultation);
                _context.SaveChanges();
            }
        }

        public List<Consultation> GetAllConsultations()
        {
            return _context.Consultations
                .Include(c => c.Patient)
                .Include(c => c.Doctor)
                .Include(c => c.Diagnosis)
                .ToList();
        }
    }
}
