using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Tehtava7
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

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            string password = txtPassword.Text;
            int characters = password.Count();
            int uppercase = password.Count(c => char.IsUpper(c));
            int lowercase = password.Count(c => char.IsLower(c));
            int numbers = password.Count(c => char.IsNumber(c));
            int specials = Regex.Matches(password, "[~!@#$%^&*()_+{}:\"<>?]").Count;

            if (characters == 0)
            {
                background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8F8F8F"));
                tbNotice.Text = "Enter password";
            }
            else if (characters < 8)
            {
                // BAD
                background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDE8D00"));
                tbNotice.Text = "Bad";
            }
            else if (characters < 12)
            {
                // FAIR
                background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFBF118"));
                tbNotice.Text = "Fair";
            }
            else if (characters < 16)
            {
                // MODERATE
                background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00F359"));
                tbNotice.Text = "Moderate";
            }
            else if (characters >= 16)
            {
                // GOOD
                background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079100"));
                tbNotice.Text = "Good";
            }

            tbCharacters.Text = "Characters: " + characters.ToString();
            tbUppercase.Text = "Uppercase: " + uppercase.ToString();
            tbLowercase.Text = "Lowercase: " + lowercase.ToString();
            tbNumbers.Text = "Numbers: " + numbers.ToString();
            tbSpecials.Text = "Specials: " + specials.ToString();
        }
    }
}
