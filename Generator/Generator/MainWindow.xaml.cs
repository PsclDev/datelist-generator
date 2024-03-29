﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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
using MaterialDesignThemes.Wpf;
using MahApps;
using BespokeFusion;

namespace Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPowerOff_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxExport.Text != "" && DatePickerFrom.Text != "" && DatePickerTo.Text != "")
            {
                DateTime From, To;
                string Path;

                From = DateTime.Parse(DatePickerFrom.Text);
                To = DateTime.Parse(DatePickerTo.Text);
                Path = TextBoxExport.Text;

                Functions.Generate(From, To);
                Functions.Export(Path);
            }
            else
            {
                MaterialMessageBox.ShowError(@"You need to fill out all 3 Controls");
            }
        }
    }
}
