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

namespace Tehtava2
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtResults.Text = "";
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            Lotto lotto = new Lotto();
            int draws = int.Parse(txtDraws.Text);
            int[] numbers;

            try
            {
                if (cboGames.Text == "Suomi")
                {
                    for (int i = 0; i < draws; i++)
                    {
                        numbers = new int[7];
                        numbers = lotto.DrawLotto();
                        foreach (int j in numbers)
                        {
                            txtResults.Text += j + " ";
                        }
                        txtResults.Text += "\r\n";
                    }
                }
                else if (cboGames.Text == "Viking Lotto")
                {
                    for (int i = 0; i < draws; i++)
                    {
                        numbers = new int[6];
                        numbers = lotto.DrawVikingLotto();
                        foreach (int j in numbers)
                        {
                            txtResults.Text += j + " ";
                        }
                        txtResults.Text += "\r\n";
                    }
                }
                else if (cboGames.Text == "Eurojackpot")
                {
                    for (int i = 0; i < draws; i++)
                    {
                        numbers = new int[5];
                        numbers = lotto.DrawEurojackpotMain();
                        foreach (int j in numbers)
                        {
                            txtResults.Text += j + " ";
                        }
                        txtResults.Text += "+ ";
                        numbers = new int[2];
                        numbers = lotto.DrawEurojackpotStar();
                        foreach (int j in numbers)
                        {
                            txtResults.Text += j + " ";
                        }
                        txtResults.Text += "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
        }
    }
}
