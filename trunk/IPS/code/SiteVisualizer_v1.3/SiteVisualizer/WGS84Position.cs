using System;
using System.Collections.Generic;
using System.Text;

namespace bfhmarcel.googleearth
{
    /// <summary>
    /// A position on the globe, using the WGS84 Notation
    /// </summary>
    public class WGS84Position
    {
        /// <summary>
        /// Constructor initialising all fields
        /// </summary>
        /// <param name="aLongitude"></param>
        /// <param name="aLatitude"></param>
        /// <param name="aHeight"></param>
        public WGS84Position(double aLongitude, double aLatitude, double aHeight)
        {
            Longitude = aLongitude;
            Latitude = aLatitude;
            Height = aHeight;
        }

        /// <summary>
        /// the double-typed longitude value of this position
        /// </summary>
        double m_Longitude;
        public double Longitude
        {
            get { return m_Longitude; }
            set { m_Longitude = value; }
        }


        /// <summary>
        /// the double-typed latitude value of this position
        /// </summary>
        double m_Latitude;
        public double Latitude
        {
            get { return m_Latitude; }
            set { m_Latitude = value; }
        }


        /// <summary>
        /// the double-typed height of this position
        /// </summary>
        double m_Height;
        public double Height
        {
            get { return m_Height; }
            set { m_Height = value; }
        }

        internal CH1903Position ConvertToCH1903()
        {
            //Näherungsformeln für die direkte Umrechnung von:
            //ellipsoidischen WGS84-Koordinaten (φ, λ, h)
            //nach Schweizer Projektionskoordinaten (y, x, h')
            //(Genauigkeit im 1-Meter-Bereich)
            //nach: [H. Dupraz, Transformation approchée de coordonnées WGS84 en coordonnées nationales
            //suisses, IGEO-TOPO, EPFL, 1992]
            //Die Parameter wurden von U. Marti (Mai 1999) neu berechnet. Zudem wurden die Einheiten so
            //angepasst, dass sie mit den Formeln aus [Bolliger 1967] vergleichbar werden.
            
            //1. Breite φ und Länge λ sind in Sexagesimalsekunden ["] umzuwandeln
            double phi = Latitude * 3600;
            double lambda = Longitude * 3600;
            
            //2. Hilfsgrössen (Breiten- und Längendifferenz gegenüber Bern in der Einheit [10000"]) berechnen:
            double phiStrich = (phi - 169028.66) / 10000;
            double lambdaStrich = (lambda - 26782.5) / 10000;
            
            //3. y, x, h' berechnen
            double y = 600072.37
            + 211455.93 * lambdaStrich
            - 10938.51 * lambdaStrich * phiStrich
            - 0.36 * lambdaStrich * Math.Pow(phiStrich, 2)
            - 44.54 * Math.Pow(lambdaStrich, 3);

            double x = 200147.07
            + 308807.95 * phiStrich
            + 3745.25 * Math.Pow(lambdaStrich, 2)
            + 76.63 * Math.Pow(phiStrich, 2)
            - 194.56 * Math.Pow(lambdaStrich, 2) * phiStrich
            + 119.79 * Math.Pow(phiStrich, 3);

            double hStrich = Height - 49.55
            + 2.73 * lambdaStrich
            + 6.94 * phiStrich;

            return new CH1903Position(x, y, hStrich);
        }
    }
}
