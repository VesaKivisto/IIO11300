/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 13.1.2016
* Authors: Tero ,Esa Salmikangas
*/
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

namespace JAMK.IT.IIO113000
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

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double windowWidth = double.Parse(txtWidht.Text);
            double windowHeight = double.Parse(txtHeight.Text);
            double frameWidth = double.Parse(txtFrameWidht.Text);

            try
            {
                double perimeterResult;
                perimeterResult = BusinessLogicWindow.CalculatePerimeter(windowWidth, windowHeight);
                txtFramePiiriTulos.Text = Math.Round(perimeterResult, 2).ToString() + " m";

                double windowAreaResult;
                windowAreaResult = BusinessLogicWindow.CalculateWindowArea(windowWidth, windowHeight);
                txtAlaTulos.Text = Math.Round(windowAreaResult, 2).ToString() + " m^2"; ;

                double frameAreaResult;
                frameAreaResult = BusinessLogicWindow.CalculateFrameArea(windowWidth, windowHeight, frameWidth);
                txtFrameAlaTulos.Text = Math.Round(frameAreaResult, 2).ToString() + " m^2"; ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //yield to an user that everything okay
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //Käynnissä olevan sovelluksen sulkeminen
            Application.Current.Shutdown();
        }

        private void btnCalculateOO_Click(object sender, RoutedEventArgs e)
        {
            //Olion avulla lasketaan pinta-ala, piiri ja hinta
            //Luodaan olio
            Ikkuna ikkuna = new Ikkuna();
            ikkuna.Leveys = double.Parse(txtWidht.Text);
            ikkuna.Korkeus = double.Parse(txtHeight.Text);
            //V1 Pinta-alan laskeminen kutsumalla metodia
            txtAlaTulos.Text = ikkuna.LaskePintaAla().ToString();
            //V2 Pinta-ala on olion ominaisuus
            txtAlaTulos.Text = ikkuna.PintaAla.ToString();
        }
    }
}
