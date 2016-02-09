using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava4
{
    class Pelaaja
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
            this.kuva = "";
        }
        public Pelaaja(string enimi, string snimi, int siirtohinta, string seura)
        {
            this.etunimi = enimi;
            this.sukunimi = snimi;
            this.siirtohinta = siirtohinta;
            this.seura = seura;

            // satunnainen kuva
            Random rand = new Random();
            int number = rand.Next(1, 6);
            this.kuva = "/images/image" + number + ".png";
        }
        #endregion
        #region Methods
        #endregion
    }
}
