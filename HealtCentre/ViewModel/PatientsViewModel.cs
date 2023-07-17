using HealthCentre.Entities;
using HealthCentre.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthCentre.ViewModel
{
    public class PatientsViewModel : ViewModelBase
    {
        private HealthCentreRepository? _repository;
        private List<Patient>? _patients;

        public PatientsViewModel(HealthCentreRepository repository)
        {
            _repository = repository;
        }


        public List<Patient> Patients
        {
            get { return _patients; }
            set
            {
                _patients = value;
                OnPropertyChanged();
            }
        }

        public void LoadPatients()
        {
            Patients = _repository.GetAllPatients();
        }


        //query - do napisania nizej
    }
}
