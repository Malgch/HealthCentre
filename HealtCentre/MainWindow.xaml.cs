﻿using System;
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
using HealthCentre.Views;

namespace HealtCentre;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
    }

    private void OpenPatientsWindow(object sender, RoutedEventArgs e)
    {
        PatientsWindow newWindow = new PatientsWindow();
        newWindow.Show();
        Close();
    }

    private void OpenDoctorsWindow(object sender, RoutedEventArgs e)
    {
        DoctorsWindow newWindow = new DoctorsWindow();
        newWindow.Show();
        Close();
    }
}
