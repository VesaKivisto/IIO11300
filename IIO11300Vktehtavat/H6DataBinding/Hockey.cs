using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6DataBinding
{
    public class HockeyPlayer
    {

    }

    public class HockeyTeam
    {
        #region PROPERTIES
        // HUOM! public field ei kelpaa XAMLin bindauksessa, pitää olla Property
        public string Name { get; set; }
        public string City { get; set; }
        #endregion
        #region CONSTRUCTORS
        public HockeyTeam()
        {
            Name = "Anonymous";
            City = "None";
        }
        public HockeyTeam(string teamName, string teamCity)
        {
            Name = teamName;
            City = teamCity;
        }
        #endregion
        public override string ToString()
        {
            return Name + "@" + City;
        }
    }

    public class HockeyLeague
    {
        // Perustetaan SM-Liiga
        List<HockeyTeam> teams = new List<HockeyTeam>();
        public HockeyLeague()
        {
            teams.Add(new HockeyTeam("Ilves", "Tampere"));
            teams.Add(new HockeyTeam("JYP", "Jyväskylä"));
            teams.Add(new HockeyTeam("HIFK", "Helsinki"));
            teams.Add(new HockeyTeam("Kärpät", "Oulu"));
            teams.Add(new HockeyTeam("KalPa", "Kuopio"));
            teams.Add(new HockeyTeam("SaiPa", "Lappeenranta"));
        }
        // Metodi, joka palauttaa liigan joukkueet
        public List<HockeyTeam> GetTeams()
        {
            return teams;
        }
    }
}
