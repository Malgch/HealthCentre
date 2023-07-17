using HealthCentre.Model;
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
using System.Windows.Shapes;

namespace HealthCentre.Views
{
    /// <summary>
    /// Interaction logic for PatientsWindow.xaml
    /// </summary>
    public partial class PatientsWindow : Window
    {

        public PatientsWindow()
        {
            InitializeComponent();
            using (var repository = new HealthCentreRepository())
            {
                var patientsViewModel = new PatientsViewModel(repository);
                DataContext = patientsViewModel;
                patientsViewModel.LoadPatients();
            }
        }
    }
}
