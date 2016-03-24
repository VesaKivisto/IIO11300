using System;
using System.Data;
using System.Data.SqlClient;

namespace H9Bookshop
{
    public class DBBookshop
    {
        public static DataTable GetTestData()
        {
            // Luodaan testausta varten oikeanlainen DataTable
            DataTable dt = new DataTable();
            // Sarakkeiden määrittely
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("author", typeof(string));
            dt.Columns.Add("country", typeof(string));
            dt.Columns.Add("year", typeof(int));
            // Rivit eli tietueet
            dt.Rows.Add(11, "Pekka Lipposen seikkailut", "Outsider", "Suomi", 1950);
            dt.Rows.Add(12, "Lucky Luke", "René Coscinny", "Belgia", 1946);
            return dt;
        }

        public static DataTable GetBooks(string connStr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "SELECT id, name, author, country, year FROM books";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Books");
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

        public static int UpdateBook(string connStr, int id, string name, string author, string country, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // HUOM: käytetään SQL-kyselyn parametrejä kahdesta syystä:
                    // 1: heittomerkki (hipsa) engl. apostrophe esim. nimessä O'Hara
                    // 2: tietoturva: parametrisoidut kyselyt ovat tietoturvallisempia
                    string sql = string.Format("UPDATE books SET name = @name, author = @Author, country = @Country, year = @Year WHERE id = @ID", id, name, author, country, year);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    // Lisätään parametrit
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@Year", year);
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

        public static int InsertBook(string connStr, string name, string author, string country, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // HUOM: käytetään SQL-kyselyn parametrejä kahdesta syystä:
                    // 1: heittomerkki (hipsa) engl. apostrophe esim. nimessä O'Hara
                    // 2: tietoturva: parametrisoidut kyselyt ovat tietoturvallisempia
                    string sql = string.Format("INSERT INTO books (name, author, country, year) VALUES (@Name, @Author, @Country, @Year)", name, author, country, year);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    // Lisätään parametrit
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@Year", year);
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

        public static int DeleteBook(string connStr, int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM books WHERE id = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    int lkm = cmd.ExecuteNonQuery();
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
