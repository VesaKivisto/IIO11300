﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO113000
{
    public class Ikkuna
    {
        #region Muuttujat (variables)
        private double korkeus;
        private double leveys;
        //private double pintaAla;
        #endregion
        #region Ominaisuudet (properties)
        //Oliosuunnittelun aikana on päätetty, että pinta-ala ja hinta ovat read-only -ominaisuuksia
        public double PintaAla
        {
            get
            {
                return korkeus * leveys;
            }
        }
        public float Hinta
        {
            get
            {
                return LaskeHinta();
            }
        }
        public double Korkeus
        {
            get
            {
                return korkeus;
            }
            set
            {
                //Tässä kohdassa voisi tarvittaessa tehdä tarkistuksia
                korkeus = value;
            }
        }
        public double Leveys
        {
            get { return leveys; }
            set { leveys = value; }
        }

        #endregion
        #region Konstruktorit (constructors)
        #endregion
        #region Metodit (methods)
        public double LaskePintaAla()
        {
            return korkeus * leveys;
        }
        private float LaskeHinta()
        {
            //Hinta lasketaan työn, materiaalimenekin ja katteen avulla
            float kate = 100;
            float tyo = 200;
            float materiaali;
            materiaali = 100 * ((float)leveys * (float)korkeus/1000000);
            return (kate + tyo + materiaali);
        }
        #endregion
    }
    public class IkkunaV0
    {
        //Joskus tehdään näin, "oikeaistaan"
        //"En suosittele" -Esa 2016
        public double korkeus;
        public double leveys;
        public double LaskePintaAla()
        {
            return korkeus * leveys;
        }
    }

    public class BusinessLogicWindow
    {
        /// <summary>
        /// CalculatePerimeter calculates the perimeter of a window
        /// </summary>
        public static double CalculatePerimeter(double width, double height)
        {
            double framePerimeter = (width * 2 + height * 2) / 1000;
            return framePerimeter;
        }

        public static double CalculateWindowArea(double width, double height)
        {
            double windowArea = (width * height) / 1000000;
            return windowArea;
        }

        public static double CalculateFrameArea(double width, double height, double frameWidth)
        {
            double frameArea = ((2 * frameWidth + height) * (2 * frameWidth + width) - (width * height)) / 1000000;
            return frameArea;
        }
    }
}
