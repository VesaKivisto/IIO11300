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
using Microsoft.Win32;

namespace H1MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool IsPlaying = false;
        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }
        private void InitMyStuff()
        {
            //kootaan tänne kaikki alustukset mitä tarvitaan ohjelman suorittamiseksi
            txtFileName.Text = "D:\\H9073\\Media\\CoffeeMaker.mp4";
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtFileName.Text.Length > 0 && System.IO.File.Exists(txtFileName.Text))
                {
                    mediaElement.Source = new Uri(txtFileName.Text);
                    mediaElement.Play();
                    IsPlaying = true;
                    //Nappulat käyttöön
                    SetMyButtons();
                    SetBrowsing();
                }
                else
                {
                    MessageBox.Show("Tiedostoa " + txtFileName.Text + " ei löydy."); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (IsPlaying)
            {
                mediaElement.Pause();
                IsPlaying = false;
                btnPause.Content = "Resume";
                SetBrowsing();
            }
            else
            {
                mediaElement.Play();
                IsPlaying = true;
                btnPause.Content = "Pause";
                SetBrowsing();
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            IsPlaying = false;
            //Nappulat käyttöön
            SetMyButtons();
            SetBrowsing();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            //Haetaan käyttäjän vakiodialogilla valitsema tiedosto textboxiin
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\H9073";
            ofd.Filter = "Musiikkitiedostot|*.mp3|Videotiedostot|*.mp4|All files|*.*";
            Nullable<bool> result = ofd.ShowDialog();
            if (result == true)
            {
                txtFileName.Text = ofd.FileName;
            }
        }

        private void SetMyButtons()
        {
            btnPause.IsEnabled = IsPlaying;
            btnStop.IsEnabled = IsPlaying;
            btnPlay.IsEnabled = !IsPlaying;
            
        }

        private void SetBrowsing()
        {
            btnBrowse.IsEnabled = !IsPlaying;
            txtFileName.IsEnabled = !IsPlaying;
        }
    }
}
