using System;
using System.Windows;
using System.Data; // sisältää ADO:n perusluokat
using System.Data.SqlClient; // SQL Server spesifiset luokat

namespace H8ADONETLasnaolotWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            try
            {
                // Yhteys
                using (SqlConnection conn = new SqlConnection(H8ADONETLasnaolotWPF.Properties.Settings.Default.Tietokanta))
                {
                    // Data-adapteri
                    string sql = "SELECT asioid, lastname, firstname, date FROM presences WHERE asioid = 'H9073'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable("Lasnaolot");
                    da.Fill(dt);
                    // Sidotaan datatable UI-kontrolliin
                    dgLasnaolot.DataContext = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}