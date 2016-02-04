using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    [Serializable]
    public class MittausData
    {
        #region PROPERTIES
        private string kello;
        public string Kello
        {
            get { return kello; }
            set { kello = value; }
        }
        private string mittaus;

        public string Mittaus
        {
            get { return mittaus; }
            set { mittaus = value; }
        }
        #endregion
        #region CONSTRUCTORS
        // Luokalle tehdään kaksi konstruktoria
        public MittausData()
        {
            kello = "0:00";
            mittaus = "empty";
        }
        public MittausData(string klo, string mdata)
        {
            this.kello = klo;
            this.mittaus = mdata;
        }
        #endregion
        #region METHODS
        // Ylikirjoitetaan ToString
        public override string ToString()
        {
            // Return base.ToString();
            return kello + " = " + mittaus;
        }
        // Tiedoston käsittelymetodit
        public static void SaveToFile(string filename, List<MittausData> mittaukset)
        {
            try
            {
                StreamWriter sw;
                // Tarkistetaan onko tiedosto jo olemassa
                if (File.Exists(filename))
                {
                    // Liitetään olemassa olevaan tiedostoon
                    sw = File.AppendText(filename);
                }
                else
                {
                    // Luodaan uusi tiedosto
                    sw = File.CreateText(filename);
                }
                // Kirjoitus
                foreach (var item in mittaukset)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveToFileV2(string filename, List<MittausData> mittaukset)
        {
            try
            {
                // Luodaan uusi tai kirjoitetaan olemassa olevaan
                StreamWriter sw = File.AppendText(filename);

                // Kirjoitus
                foreach (var item in mittaukset)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<MittausData> ReadFromFile(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    // Luetaan tekstitiedosto ja muutetaan se MittausData-olioksi
                    MittausData md;
                    List<MittausData> luetut = new List<MittausData>();
                    string rivi = "";
                    StreamReader sr = File.OpenText(filename);
                    while ((rivi = sr.ReadLine()) != null)
                    {
                        if (rivi.Length > 3 && rivi.Contains("="))
                        {
                            string[] split = rivi.Split(new char[] { '=' });
                            // Alimerkkijonoista luodaan olio
                            md = new MittausData(split[0], split[1]);
                            luetut.Add(md);
                        } 
                    }
                    sr.Close();
                    // Palautetaan
                    return luetut;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}