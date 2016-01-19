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

namespace Tehtava1
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

            //TODO
            try
            {
                double perimeterResult;
                perimeterResult = BusinessLogicWindow.CalculatePerimeter(windowWidth, windowHeight);
                txtFramePiiriTulos.Text = perimeterResult.ToString();

                double windowAreaResult;
                windowAreaResult = BusinessLogicWindow.CalculateWindowArea(windowWidth, windowHeight);
                txtAlaTulos.Text = windowAreaResult.ToString();

                double frameAreaResult;
                frameAreaResult = BusinessLogicWindow.CalculateFrameArea(windowWidth, windowHeight, frameWidth, windowAreaResult);
                txtFrameAlaTulos.Text = frameAreaResult.ToString();
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
    }
}
