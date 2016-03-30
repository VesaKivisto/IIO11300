using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tehtava10
{
    public class Pelaaja
    {
        #region Properties
        private static string cs = Properties.Settings.Default.Tietokanta;

        private int id;
        private string etunimi;
        private string sukunimi;
        private string seura;
        private string siirtohinta;
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Etunimi
        {
            get { return this.etunimi; }
            set { this.etunimi = value; }
        }
        public string Sukunimi
        {
            get { return this.sukunimi; }
            set { this.sukunimi = value; }
        }
        public string Seura
        {
            get { return this.seura; }
            set { this.seura = value; }
        }
        public string Siirtohinta
        {
            get { return this.siirtohinta; }
            set { this.siirtohinta = value; }
        }
        public string KokoNimi
        {
            get { return Etunimi + " " + Sukunimi; }
        }
        public string EsitysNimi
        {
            get { return ID + ", " + KokoNimi + ", " + Seura; }
        }
        #endregion
        #region Constructors
        public Pelaaja()
        {
            this.etunimi = "";
            this.sukunimi = "";
            this.siirtohinta = "";
            this.seura = "";
        }
        public Pelaaja(string enimi, string snimi, string siirtohinta, string seura)
        {
            this.etunimi = enimi;
            this.sukunimi = snimi;
            this.siirtohinta = siirtohinta;
            this.seura = seura;
        }
        #endregion

        public static List<Pelaaja> GetPlayers()
        {
            List<Pelaaja> pelaajat = new List<Pelaaja>();
            try
            {
                DataTable dt = DBPelaaja.GetPlayers(cs);
                foreach (DataRow row in dt.Rows)
                {
                    Pelaaja pelaaja = new Pelaaja();
                    pelaaja.ID = (int)row["id"];
                    pelaaja.Etunimi = row["etunimi"].ToString();
                    pelaaja.Sukunimi = row["sukunimi"].ToString();
                    pelaaja.Seura = row["seura"].ToString();
                    pelaaja.Siirtohinta = row["arvo"].ToString();
                    
                    pelaajat.Add(pelaaja);
                }
                return pelaajat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdatePlayer(Pelaaja pelaaja)
        {
            try
            {
                int lkm = DBPelaaja.UpdatePlayer(cs, pelaaja.ID, pelaaja.Sukunimi, pelaaja.Etunimi, pelaaja.Seura, pelaaja.Siirtohinta);
                return lkm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool InsertPlayer(Pelaaja pelaaja)
        {
            try
            {
                int lkm = DBPelaaja.InsertPlayer(cs, pelaaja.Sukunimi, pelaaja.Etunimi, pelaaja.Seura, pelaaja.Siirtohinta);
                if (lkm > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
