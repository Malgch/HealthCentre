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
    class HealthCentreRepository
    {
        private readonly HealthCentreContext _context;

        public HealthCentreRepository()
        {
            _context = new HealthCentreContext();
        }

        #region Consultations
        public List<Consultation> GetAllConsultations()
        {
            return _context.Consultations
                .Include(c => c.Doctor)
                .Include(c => c.Patient)
                .Include(c => c.Diagnosis)
                .ToList();
        }

        public void AddConsultation(Consultation consultation)
        {
            _context.Consultations.Add(consultation);
            _context.SaveChanges();
        }

        public void UpdateConsultation(Consultation consultation)
        {
            _context.Consultations.Update(consultation);
            _context.SaveChanges();
        }

        public void DeleteConsultation(int consultationId)
        {
            var consultation = _context.Consultations.Find(consultationId);
            if (consultation != null)
            {
                _context.Consultations.Remove(consultation);
                _context.SaveChanges();
            }
        }
        #endregion

        #region Doctors
        public List<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }
        public void AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }
        public void UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }
        public void DeleteDoctor(int doctorId)
        {
            var doctor = _context.Doctors.Find(doctorId);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
        }
        #endregion



        public List<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }
        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }
        public void UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }
        public void DeletePatient(int patientId)
        {
            var patient = _context.Patients.Find(patientId);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }



        public List<Diagnosis> GetAllDiagnoses()
        {
            return _context.Diagnoses.ToList();
        }
    }
}
