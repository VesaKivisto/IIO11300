using System;
using System.Data.SqlClient;

namespace H7ADONETConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1 Luodaan yhteys
                string connStr = H7ADONETConsole.Properties.Settings.Default.Tietokanta;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Avataan yhteys
                    conn.Open();
                    // 2 Luodaan komento ja suoritetaan se
                    SqlCommand cmd = new SqlCommand("SELECT asioid, lastname, firstname, date FROM presences WHERE asioid = 'H9073'", conn);
                    // 3 Käydään tulos = Reader-olio läpi
                    SqlDataReader rdr = cmd.ExecuteReader();
                    // Käydään rdr läpi
                    if (rdr.HasRows)
                    {
                        int lkm = 0;
                        while (rdr.Read())
                        {
                            // Tulos näkyviin
                            Console.WriteLine("Läsnäolosi {0} {1} {2} {3}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDateTime(3).ToShortDateString());
                            lkm++;
                        }
                        Console.WriteLine("Tulostettu {0} läsnäoloa", lkm);
                    }
                    // Suljetaan yhteys
                    rdr.Close();
                    conn.Close();
                    Console.WriteLine("Tietokantayhteys suljettu onnistuneesti!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}