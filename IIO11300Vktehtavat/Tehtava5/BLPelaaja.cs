using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tehtava4
{
    public class Pelaaja
    {
        #region Properties
        private string etunimi;
        private string sukunimi;
        private string seura;
        private int siirtohinta;
        private string kuva;
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
        public int Siirtohinta
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
            get { return KokoNimi + ", " + Seura; }
        }
        public string Kuva
        {
            get { return kuva; }
        }
        #endregion
        #region Constructors
        public Pelaaja()
        {
            this.etunimi = "";
            this.sukunimi = "";
            this.siirtohinta = 0;
            this.seura = "";
        }
        public Pelaaja(string enimi, string snimi, int siirtohinta, string seura)
        {
            this.etunimi = enimi;
            this.sukunimi = snimi;
            this.siirtohinta = siirtohinta;
            this.seura = seura;
        }
        #endregion
        #region Methods
        public string GetEverything()
        {
            return this.KokoNimi + " " + this.Siirtohinta + " " + this.Seura;
        }
        public static void SerialisoiXml(string tiedosto, ICollection ic)
        {
            XmlSerializer xs = new XmlSerializer(ic.GetType());
            TextWriter tw = new StreamWriter(tiedosto);
            try
            {
                xs.Serialize(tw, ic);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                tw.Close();
            }
        }
        public static List<Pelaaja> DeSerialisoiXml(string tiedosto)
        {
            //deserialisointi, huom vain tyypitetylle listalle MittausData-olioita!!
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Pelaaja>));
            TextReader tr = new StreamReader(tiedosto);
            try
            {
                return (List<Pelaaja>)deserializer.Deserialize(tr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tr.Close();
            }
        }
        #endregion
    }
}
