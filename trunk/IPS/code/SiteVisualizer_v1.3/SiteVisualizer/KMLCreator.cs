using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using bfhmarcel.googleearth.kml21;
using System.IO;
using System.Diagnostics;

namespace bfhmarcel.googleearth
{
    /// <summary>
    /// Represents a set of geographic data as KML file.
    /// It allows data to be added and the whole set to be either 
    /// visualized in google earth directly or saved in a
    /// KML file.
    /// </summary>
    public class KMLCreator
    {
        /// <summary>
        /// represents the complete current kml file
        /// </summary>
        KmlType iKML = new KmlType();

        /// <summary>
        /// represents the document inside the kml file
        /// </summary>
        DocumentType iDocument = new DocumentType();

        /// <summary>
        /// represents some placemarks inside the document
        /// </summary>
        FeatureType[] iPlacemarks = new PlacemarkType[20];

        /// <summary>
        /// Counter for already appended placemarks
        /// </summary>
        int iPlacemarkCount = 0;



        /// <summary>
        /// Default constructor,
        /// creates an empty kml representation
        /// </summary>
        public KMLCreator()
            : this("Highlighted Icon", "Platzmarkierung mit SiteVisualizer erstellt.")
        {
                 }

        /// <summary>
        /// Constructor that takes a name and description for the KML doc
        /// </summary>
        public KMLCreator(String aName, String aDescription)
        {
            iDocument.name = aName;
            iDocument.description = aDescription;
            iKML.Item = iDocument; //add to iKML
            iDocument.Items1 = iPlacemarks; //add to the iDocument
        }

        public void AddTrack(IEnumerable<WGS84Position> positions)
        {
            //create a single placemark
            PlacemarkType placemark = new PlacemarkType();
            //placemark.name = aName;
            iPlacemarks.SetValue(placemark, iPlacemarks.Length - 1); //add to the placemarks array

            //create a line string for the placemark
            LineStringType lineString = new LineStringType();
            lineString.altitudeMode = altitudeModeEnum.clampToGround;
            lineString.tessellate = true;

            //create long string of all waypoints
            StringBuilder sb = new StringBuilder();
            foreach (WGS84Position pos in positions)
            {
                sb.Append(string.Format("{0},{1}\r\n", pos.Longitude, pos.Latitude));
            }
            lineString.coordinates = sb.ToString();
            placemark.Item1 = lineString;



            //add to array
            if (iPlacemarks.Length <= iPlacemarkCount) //array too small?
            {
                Array.Resize(ref iPlacemarks, iPlacemarks.Length + 20);
                iDocument.Items1 = iPlacemarks; //add to the iDocument AGAIN!
            }

            iPlacemarks[iPlacemarkCount++] = placemark;  //add the placemark itself



        }


        /// <summary>
        /// Adds a placemark to the existing KML
        /// </summary>
        /// <param name="aPosition"></param>
        /// <param name="aName"></param>
        public void AddPlacemark(WGS84Position aPosition, String aName)
        {
            //create a single placemark
            PlacemarkType placemark = new PlacemarkType();
            placemark.name = aName;
            iPlacemarks.SetValue(placemark, iPlacemarks.Length-1); //add to the placemarks array

            //create a point for the placemark
            PointType point = new PointType();
            point.coordinates = aPosition.Longitude.ToString() + "," + aPosition.Latitude.ToString();
            placemark.Item1 = point; //add to the placemark

            //add to array
            if (iPlacemarks.Length <= iPlacemarkCount) //array too small?
            {
                Array.Resize(ref iPlacemarks, iPlacemarks.Length + 20);
                iDocument.Items1 = iPlacemarks; //add to the iDocument AGAIN!
            }

            iPlacemarks[iPlacemarkCount++] = placemark;  //add the placemark itself

  
        }

        /// <summary>
        /// Creates a file out of the current object 
        /// </summary>
        /// <param name="?"></param>
        public void Create(String aFilename)
        {
            //create serializer
            XmlSerializer serializer =
            new XmlSerializer(typeof(KmlType));
            System.IO.TextWriter writer = new System.IO.StreamWriter(aFilename);

            // Serialize the iKML, and close the TextWriter.
            serializer.Serialize(writer, iKML);
            writer.Close();
        }
        /// <summary>
        /// shows the current object in the default application, usually Google Earth
        /// </summary>
        public void Show()
        {
            //create temp files
            string FileName = Path.GetTempFileName();
            FileName = FileName.Replace(".tmp", ".kml");
            Create(FileName);

            Process objProcess = new Process();
            objProcess.StartInfo = new ProcessStartInfo(FileName);
            objProcess.Start();                      
        }
    }

    /*
    class KMLCreator
    {
        /// <summary>
        /// Default constructor,
        /// creates an empty KML
        /// </summary>
        public KMLCreator()
        {
            //create KML using the serializer
            XmlSerializer serializer =
            new XmlSerializer(typeof(KmlType));
            System.IO.TextWriter writer = new System.IO.StreamWriter("c:\\temp\\stream.iKML");
            KmlType iKML = new KmlType();

            //create a iKML iDocument element            
            DocumentType iDocument = new DocumentType();
            iDocument.name = "Highlighted Icon";
            iDocument.description = "Platzmarkierung mit SiteVisualizer erstellt.";
            iKML.Item = iDocument; //add to iKML

            //create a iPlacemarks array
            FeatureType[] iPlacemarks = new PlacemarkType[1];
            iDocument.Items1 = iPlacemarks; //add to the iDocument

            //create a single placemark
            PlacemarkType placemark = new PlacemarkType();
            placemark.name = "Roll over this icon";
            iPlacemarks.SetValue(placemark, 0); //add to the array

            //create a point for the placemark
            PointType point = new PointType();
            point.coordinates = "-90.86948943473118,48.25450093195546";
            placemark.Item1 = point; //add to the placemark

            // Serialize the iKML, and close the TextWriter.
            serializer.Serialize(writer, iKML);
            writer.Close();
            
        }

        /// <summary>
        /// Adds a placemark to the existing KML
        /// </summary>
        /// <param name="aPosition"></param>
        /// <param name="aName"></param>
        public void AddPlacemark(WGS84Position aPosition, String aName)
    {
        }

        /// <summary>
        /// Creates a file out of the current object 
        /// </summary>
        /// <param name="?"></param>
        public void Create(String aFilename)
    {
    }
        /// <summary>
        /// shows the current object in the default application, usually Google Earth
        /// </summary>
        public void Show()
        {
        }
           }
      */
}
