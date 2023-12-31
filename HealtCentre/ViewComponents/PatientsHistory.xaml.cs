﻿using HealthCentre.Entities;
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
    /// Interaction logic for PatientsHistory.xaml
    /// </summary>
    public partial class PatientsHistory : UserControl
    {
        public PatientsHistory()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectedPatientProperty = DependencyProperty.Register(
       "SelectedPatient", typeof(Patient), typeof(PatientsHistory));

        public Patient SelectedPatient
        {
            get { return (Patient)GetValue(SelectedPatientProperty); }
            set { SetValue(SelectedPatientProperty, value); }
        }
    }
}
