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

namespace H6DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HockeyLeague smliiga;
        List<HockeyTeam> liigaJoukkueet;
        int osoitin;
        public MainWindow()
        {
            InitializeComponent();
            AlustaKontrollit();
        }

        private void AlustaKontrollit()
        {
            List<string> joukkueet = new List<string>();
            joukkueet.Add("Ilves");
            joukkueet.Add("JYP");
            joukkueet.Add("Kärpät");
            cbTeams.ItemsSource = joukkueet;

            // SM-liiga
            smliiga = new HockeyLeague();
            liigaJoukkueet = smliiga.GetTeams();
        }

        private void btnGetSetting_Click(object sender, RoutedEventArgs e)
        {
            // Koodi lukee App.configin asetuksen UserName
            btnGetSetting.Content = H6DataBinding.Properties.Settings.Default.UserName;
        }

        private void btnBind_Click(object sender, RoutedEventArgs e)
        {
            // Sidotaan kokoelma stackpaneliin
            spLiiga.DataContext = liigaJoukkueet;
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            // Siirretään osoitinta kokoelmassa yhdellä eteenpäin
            if (osoitin < liigaJoukkueet.Count - 1)
            {
                osoitin++;
                spLiiga.DataContext = liigaJoukkueet[osoitin];
            }
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {
            // Siirretään osoitinta kokoelmassa yhdellä taaksepäin
            if (osoitin > 0)
            {
                osoitin--;
                spLiiga.DataContext = liigaJoukkueet[osoitin];
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Lisätään kokoelmaan uusi joukkue
            HockeyTeam uusi = new HockeyTeam();
            liigaJoukkueet.Add(uusi);
            osoitin = liigaJoukkueet.Count - 1;
            spLiiga.DataContext = liigaJoukkueet[osoitin];
        }
    }
}
