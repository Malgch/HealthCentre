using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Patient> Patients;
        public ObservableCollection<Doctor> Doctors;
        public ObservableCollection<Diagnosis> Diagnoses;
        public ObservableCollection<Consultation> Consultations;

        public HealthCentreModel(HealthCentreContext context)
        {
            _context = context;
            Patients = new ObservableCollection<Patient>(context.Patients);
            Doctors = new ObservableCollection<Doctor> (context.Doctors);
            Diagnoses = new ObservableCollection<Diagnosis>(context.Diagnoses);
            Consultations = new ObservableCollection<Consultation> (context.Consultations);

        }

        public void AddConsultation(Consultation consultation)
        {
            Consultations.Add(consultation);
            _context.SaveChanges();
        }

        public void AddPatient(Patient patient)
        {
            Patients.Add(patient);
            _context.SaveChanges();
        }

        public void RemoveConsultation(int consultationId)
        {
            var consultation = _context.Consultations.Find(consultationId);
            if (consultation != null)
            {
                Consultations.Remove(consultation);
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
