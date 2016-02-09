using Microsoft.Win32;
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

namespace Tehtava4
{
    /// <summary>
    /// Interaction logic for Save.xaml
    /// </summary>
    public partial class Save : Window
    {
        public Save()
        {
            InitializeComponent();
        }

        private void btnSelaa_Click(object sender, RoutedEventArgs e)
        {
            //Haetaan käyttäjän vakiodialogilla valitsema tiedosto textboxiin
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\";
            ofd.Filter = "Tekstitiedostot|*.txt|All files|*.*";
            Nullable<bool> result = ofd.ShowDialog();
            if (result == true)
            {
                txtTiedosto.Text = ofd.FileName;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
