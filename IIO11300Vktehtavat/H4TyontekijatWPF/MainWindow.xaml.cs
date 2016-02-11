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
using System.Xml;
using System.Xml.Linq;

namespace H4TyontekijatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XmlDocument xd;
        XElement xe;
        XmlNodeList tyontekijat;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReadXML_Click(object sender, RoutedEventArgs e)
        {
            // Luetaan XML-tiedostosta tyontekija-elementit ja sidotaan ne DataGridiin
            try
            {
                string file = "D:\\Työntekijät2016.xml"; // Tiedostonimi kovakoodattu, välttäkää kovakoodausta
                xe = XElement.Load(file);
                xd = new XmlDocument();
                xd.Load(file);
                tyontekijat = xd.SelectNodes("/tyontekijat/tyontekija");
                dgData.DataContext = xe.Elements("tyontekija");
                tbMessage.Text = string.Format("Työntekijöitä {0} ja palkat yhteensä {1}", CountWorkers("vakituinen"), CalculateSalarySum("vakituinen"));
            }
            catch (Exception ex)
            {
                tbMessage.Text = ex.Message;
            }
        }
        private int CountWorkers()
        {
            int lkm = 0;
            lkm = tyontekijat.Count;
            return lkm;
        }
        private int CountWorkers(string tyosuhde)
        {
            int lkm = 0;
            // Lasketaan LINQ-kyselyllä tietyntyyppiset työntekijät
            var sukunimet = from ele
                            in xe.Elements()
                            where ele.Element("tyosuhde").Value == tyosuhde
                            select ele.Element("sukunimi");
            lkm = sukunimet.Count();
            return lkm;
        }
        private decimal CalculateSalarySum()
        {
            decimal sum = 0;
            XmlNode xn;
            for (int i = 0; i < tyontekijat.Count; i++)
            {
                xn = tyontekijat.Item(i);
                sum += decimal.Parse(xn.LastChild.InnerText);
            }
            return sum;
        }
        private decimal CalculateSalarySum(string tyosuhde)
        {
            decimal sum = 0;
            var palkat = from ele
                         in xe.Elements()
                         where ele.Element("tyosuhde").Value == tyosuhde
                         select ele.Element("palkka").Value;
            foreach (var item in palkat)
            {
                System.Diagnostics.Debug.Print(item.ToString());
                sum += decimal.Parse(item);
            }
            return sum;
        }
    }
}
