using HealthCentre.Entities;
using HealthCentre.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthCentre.ViewComponents
{
    /// <summary>
    /// Interaction logic for PatientsDetails.xaml
    /// </summary>
    public partial class PatientsDetails : UserControl
    {
        public PatientsDetails()
        {
            InitializeComponent();
            Loaded += PatientsDetails_Loaded;
        }

        private void PatientsDetails_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is PatientsViewModel viewModel)
            {
                DataContext = viewModel;
            }
        }

        public static readonly DependencyProperty SelectedPatientProperty = DependencyProperty.Register(
        "SelectedPatient", typeof(Patient), typeof(PatientsDetails));

        public Patient SelectedPatient
        {
            get { return (Patient)GetValue(SelectedPatientProperty); }
            set { SetValue(SelectedPatientProperty, value); }
        }

    }
}
