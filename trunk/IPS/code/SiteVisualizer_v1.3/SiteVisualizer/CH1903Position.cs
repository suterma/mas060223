using System;
using System.Collections.Generic;
using System.Text;

namespace bfhmarcel.googleearth
{
    /// <summary>
    /// A position on the globe, (preferably inside the country of Switzerland), represented in the
    /// CH1903 Coordinate System.
    /// An explanation of this system can be found at 
    /// http://www.swisstopo.admin.ch/internet/swisstopo/de/home/topics/survey/sys/frames/trans.parsysrelated1.60726.downloadList.80457.DownloadFile.tmp/ch1903wgs84de.pdf
    /// </summary>
    public class CH1903Position
    {
        /// <summary>
        /// Constructor that initialises all values
        /// </summary>
        /// <param name="aHochwert">The "Hochwert" of that position</param>
        /// <param name="aRechtswert">The "Rechtswert" of that position</param>
        /// <param name="aHoehe">The "Hoehe" of that position</param>
        public CH1903Position(double aHochwert, double aRechtswert, double aHoehe)
        {
            Hochwert = aHochwert;
            Rechtswert = aRechtswert;
            Hoehe = aHoehe;
        }

        /// <summary>
        /// the double-typed x value (Hochwert) of this position
        /// </summary>
        double m_Hochwert;
        public double Hochwert
        {
            get { return m_Hochwert; }
            set { m_Hochwert = value; }
        }

        /// <summary>
        /// the double-typed y value (Rechtswert)of this position
        /// </summary>
        double m_Rechtswert;
        public double Rechtswert
        {
            get { return m_Rechtswert; }
            set { m_Rechtswert = value; }
        }

        /// <summary>
        /// the double-typed height (Hoehe) of this position
        /// </summary>
        double m_Hoehe;
        public double Hoehe
        {
            get { return m_Hoehe; }
            set { m_Hoehe = value; }
        }

        /// <summary>
        /// Converts this coordinate in the CH1903 System to a coordinate in the WGS84 System.
        /// Accurracy is within 1 meter inside Switzerland
        /// See http://www.swisstopo.admin.ch/internet/swisstopo/de/home/topics/survey/sys/frames/trans.parsysrelated1.60726.downloadList.80457.DownloadFile.tmp/ch1903wgs84de.pdf
        /// for more information
        /// </summary>
        public WGS84Position ConvertToWGS84()
        {

            //1. Die Projektionskoordinaten y (Rechtswert) und x (Hochwert) sind ins zivile System (Bern = 0 / 0) und
            //in die Einheit [1000 km] umzuwandeln:
            double yStrich = (Rechtswert - 600000) / 1000000;
            double xStrich = (Hochwert - 200000) / 1000000;

            //2. Länge und Breite in der Einheit [10000"] berechnen:
            double lambdaStrich = 2.6779094
            + 4.728982 * yStrich
            + 0.791484 * yStrich * xStrich
            + 0.1306 * yStrich * Math.Pow(xStrich, 2)
            - 0.0436 * Math.Pow(yStrich, 3);

            double phiStrich = 16.9023892
            + 3.238272 * xStrich
            - 0.270978 * Math.Pow(yStrich, 2)
            - 0.002528 * Math.Pow(xStrich, 2)
            - 0.0447 * Math.Pow(yStrich, 2) * xStrich
            - 0.0140 * Math.Pow(yStrich, 3);

            double h = Hoehe + 49.55
            - 12.60 * yStrich
            - 22.64 * xStrich;

            //3. Umrechnen der Länge und Breite in die Einheit [°]
            double lambda = lambdaStrich * 100 / 36;
            double phi = phiStrich * 100 / 36;


            //assign values to a WGS84 coordinate
            return new WGS84Position(lambda, phi, h);
        }
    }
}
