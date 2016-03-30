using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava10
{
    public class DBPelaaja
    {
        public static DataTable GetPlayers(string connStr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "SELECT id, etunimi, sukunimi, seura, arvo FROM Pelaajat";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Pelaajat");
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdatePlayer(string connStr, int id, string sukunimi, string etunimi, string seura, string arvo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // HUOM: käytetään SQL-kyselyn parametrejä kahdesta syystä:
                    // 1: heittomerkki (hipsa) engl. apostrophe esim. nimessä O'Hara
                    // 2: tietoturva: parametrisoidut kyselyt ovat tietoturvallisempia
                    string sql = string.Format("UPDATE Pelaajat SET sukunimi = @Sukunimi, etunimi = @Etunimi, seura = @Seura, arvo = @Arvo WHERE id = @ID", id, sukunimi, etunimi, seura, arvo);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    // Lisätään parametrit
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Sukunimi", sukunimi);
                    cmd.Parameters.AddWithValue("@Etunimi", etunimi);
                    cmd.Parameters.AddWithValue("@Seura", seura);
                    cmd.Parameters.AddWithValue("@Arvo", arvo);
                    // Suoritetaan kysely kantaan
                    int lkm = cmd.ExecuteNonQuery();
                    conn.Close();
                    return lkm;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertPlayer(string connStr, string sukunimi, string etunimi, string seura, string arvo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // HUOM: käytetään SQL-kyselyn parametrejä kahdesta syystä:
                    // 1: heittomerkki (hipsa) engl. apostrophe esim. nimessä O'Hara
                    // 2: tietoturva: parametrisoidut kyselyt ovat tietoturvallisempia
                    string sql = string.Format("INSERT INTO Pelaajat (sukunimi, etunimi, seura, arvo) VALUES (@Sukunimi, @Etunimi, @Seura, @Arvo)", sukunimi, etunimi, seura, arvo);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    // Lisätään parametrit
                    cmd.Parameters.AddWithValue("@Sukunimi", sukunimi);
                    cmd.Parameters.AddWithValue("@Etunimi", etunimi);
                    cmd.Parameters.AddWithValue("@Seura", seura);
                    cmd.Parameters.AddWithValue("@Arvo", arvo);
                    // Suoritetaan kysely kantaan
                    int lkm = cmd.ExecuteNonQuery();
                    conn.Close();
                    return lkm;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
