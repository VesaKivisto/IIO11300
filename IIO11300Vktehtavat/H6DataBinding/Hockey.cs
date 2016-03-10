﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6DataBinding
{
    public static class TestHockeyBench
    {
        public static List<HockeyPlayer> Get3Players()
        {
            List<HockeyPlayer> players = new List<HockeyPlayer>();
            players.Add(new HockeyPlayer("Teemu Selänne", "8"));
            players.Add(new HockeyPlayer("Jarkko Immonen", "26"));
            players.Add(new HockeyPlayer("Ville Peltonen", "16"));
            return players;
        }
    }

    public class HockeyPlayer : INotifyPropertyChanged
    {
        // Properties
        private string name;
        public string Name
        {
            set
            {
                name = value;
                Notify("Name");
                Notify("NameAndNumber");
            }
            get
            {
                return name;
            }
        }

        private string number;
        public string Number
        {
            set
            {
                number = value;
                Notify("Number");
                Notify("NameAndNumber");
            }
            get
            {
                return number;
            }
        }

        public string NameAndNumber
        {
            get
            {
                return name + " #" + number;
            }
        }

        //Constructors
        public HockeyPlayer()
        {
            
        }
        public HockeyPlayer(string name, string number)
        {
            this.name = name;
            this.number = number;
        }

        // Rajapinnan (interface) toteutus
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
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
