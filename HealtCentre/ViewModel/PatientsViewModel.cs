using HealthCentre.Entities;
using HealthCentre.Model;
using HealthCentre.ViewComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HealthCentre.ViewModel
{
    public class PatientsViewModel : ViewModelBase
    {
        private HealthCentreRepository? _repository;
        private List<Patient>? _patients;
        private Patient _selectedPatient;

        public PatientsViewModel(HealthCentreRepository repository)
        {
            _repository = repository;
        }

        public Patient SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                _selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        public List<Patient> Patients
        {
            get { return _patients; }
            set
            {
                _patients = value;
                OnPropertyChanged(nameof(Patients));
            }
        }

        public void LoadPatients()
        {
            Patients = _repository.GetAllPatients();
        }


        //query - do napisania nizej
    }
}
