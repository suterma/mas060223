using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PdfToText;
using bfhmarcel.googleearth;

namespace SiteVisualizer
{
    public partial class Form1 : Form
    {

        PlacemarkListForm placemarkListForm = new PlacemarkListForm();

        CH1903Position m_posCH1903;
        WGS84Position m_posWGS84;

        /// <summary>
        /// used to determine whether to react on text changed
        /// events from the text fields.
        /// If we change the text fields according to calculations,
        /// we should not react on the herein produced events.        /// 
        /// </summary>
        bool m_isEventsEnabled = false;

        public Form1()
        {
            InitializeComponent();


            //whot the list
            placemarkListForm.Show();


            //TODO test
            //init placemarklist


            //TEST
            m_posWGS84 = new WGS84Position(
                8.7304972222222222222222222222222, 46.044130555555555555555555555556,
                650.6);
            m_posCH1903 = m_posWGS84.ConvertToCH1903();
            m_isEventsEnabled = false;
            VisualizeCH1903();
            VisualizeWGS84();
            m_isEventsEnabled = true;
        }

        private void tBAny_TextChanged(object sender, EventArgs e)
        {
            if (m_isEventsEnabled) //should we react?
            {
                //parse text to value
                String input = ((System.Windows.Forms.TextBoxBase)sender).Text;
                try
                {
                    double inputValue = Double.Parse(input);

                    //if no exception enable back all textboxes
                    EnableAllTextBoxes();

                    if ((((TextBox)sender) == tBHochwert) ||
                         (((TextBox)sender) == tBRechtswert) ||
                         (((TextBox)sender) == tBHoehe)
                    ) //something on the CH1903 values changed?
                    {
                        //handle the change of the CH1903 coordinate values
                        if ((TextBox)sender == tBHochwert)
                        {
                            m_posCH1903.Hochwert = inputValue;

                        }
                        if ((TextBox)sender == tBRechtswert)
                        {
                            m_posCH1903.Rechtswert = inputValue;

                        }
                        if ((TextBox)sender == tBHoehe)
                        {
                            m_posCH1903.Hoehe = inputValue;

                        }



                        m_isEventsEnabled = false;
                        UpdateWGS84();
                        m_isEventsEnabled = true;
                    }
                    else if ((((TextBox)sender) == tBLatitude) ||
                        (((TextBox)sender) == tBLongitude) ||
                        (((TextBox)sender) == tBHeight)
                        ) //something on the WGS84 values changed?
                    {
                        //handle the change of the WGS84 coordinate values
                        if ((TextBox)sender == tBLatitude)
                        {
                            m_posWGS84.Latitude = inputValue;

                        }
                        if ((TextBox)sender == tBLongitude)
                        {
                            m_posWGS84.Longitude = inputValue;

                        }
                        if ((TextBox)sender == tBHeight)
                        {
                            m_posWGS84.Height = inputValue;

                        }



                        m_isEventsEnabled = false;
                        UpdateCH1903();
                        m_isEventsEnabled = true;
                    }
                }
                catch (Exception)
                {
                    //if parsing was wrong, disable all other fields
                    DisableTextBoxesExcept((TextBox)sender);

                }
            }

        }

        /// <summary>
        /// remember if we have any textbox disabled because
        /// of input parsing problmes
        /// </summary>
        private bool m_isAnyTextBoxDisabled = false;

        private void EnableAllTextBoxes()
        {
            if (m_isAnyTextBoxDisabled)
            {
                tBHochwert.Enabled = true;
                tBRechtswert.Enabled = true;
                tBHoehe.Enabled = true;
                tBLatitude.Enabled = true;
                tBLongitude.Enabled = true;
                tBHeight.Enabled = true;
            }


        }

        private void DisableTextBoxesExcept(TextBox textBox)
        {
            m_isAnyTextBoxDisabled = true;

            //disable all textboxes that are not the one
            if (textBox != tBHochwert)
                tBHochwert.Enabled = false;
            if (textBox != tBRechtswert)
                tBRechtswert.Enabled = false;
            if (textBox != tBHoehe)
                tBHoehe.Enabled = false;
            if (textBox != tBLatitude)
                tBLatitude.Enabled = false;
            if (textBox != tBLongitude)
                tBLongitude.Enabled = false;
            if (textBox != tBHeight)
                tBHeight.Enabled = false;
        }




        private void UpdateWGS84()
        {
            //create new converted object from the new values
            m_posWGS84 = m_posCH1903.ConvertToWGS84();

            VisualizeWGS84();
        }

        private void VisualizeWGS84()
        {
            //set output text
            this.tBLatitude.Text = m_posWGS84.Latitude.ToString();
            this.tBLongitude.Text = m_posWGS84.Longitude.ToString();
            this.tBHeight.Text = m_posWGS84.Height.ToString();
        }

        private void UpdateCH1903()
        {
            //create new converted object from the new values
            m_posCH1903 = m_posWGS84.ConvertToCH1903();

            VisualizeCH1903();
        }

        private void VisualizeCH1903()
        {
            //set output text
            this.tBHochwert.Text = m_posCH1903.Hochwert.ToString();
            this.tBRechtswert.Text = m_posCH1903.Rechtswert.ToString();
            this.tBHoehe.Text = m_posCH1903.Hoehe.ToString();
        }

        private void btnAddPlacemark_Click(object sender, EventArgs e)
        {
            /*
            KMLCreator creator = new KMLCreator();
            creator.AddPlacemark(m_posWGS84, "Default");
            creator.Create("c:\\temp\\tesiKML.kml");
            creator.Show();
             * */

            //add a placemark out of the current postition to the PlacemarkList
            placemarkListForm.AddPlacemark(m_posWGS84, "Default");
        }

        private void btnLoadSiteTable_Click(object sender, EventArgs e)
        {
            ofdTetrapolSites.DefaultExt = "txt";
            ofdTetrapolSites.ShowDialog();
            ofdTetrapolSites.Multiselect = false;
            String siteTableFilename = ofdTetrapolSites.FileName;

            //load the file into an array of strings
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(siteTableFilename))
                {
                    String line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line[0] == '#') //is comment?
                            continue;

                        String[] splittedLine = line.Split('\t'); //split by tabs

                        if (splittedLine.Length < 7) //invalid number of elements
                            continue;

                        try
                        {
                            //create position from data
                            CH1903Position chPos = new CH1903Position(
                                Double.Parse(splittedLine[3]),
                                Double.Parse(splittedLine[2]),
                                Double.Parse(splittedLine[5]));

                            //create placemark from converted position
                            placemarkListForm.AddPlacemark(chPos.ConvertToWGS84(),
                                splittedLine[1] + "(" + splittedLine[0] + ")");
                        }
                        catch (System.OverflowException)
                        {
                            //something with the parsing went wrong, ignore this line
                        }
                        catch (System.FormatException)
                        {
                            //something with the parsing went wrong, ignore this line
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }








        }

        private void btnLoadUKWSitesPDF_Click(object sender, EventArgs e)
        {
            ofdBakomUKW.ShowDialog();

            String bakomUKWSitesFileName = ofdBakomUKW.FileName;
            String bakomUKWSitesTextFileName = "c:\\temp.txt";
            //convert the pdf to a text file

            // create an instance of the pdfparser class
            PDFParser pdfParser = new PDFParser();

            // extract the text
            Boolean success = pdfParser.ExtractText(bakomUKWSitesFileName, bakomUKWSitesTextFileName);




            //load the intermediate file line by line and parse it
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(bakomUKWSitesTextFileName))
                {
                    String line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line[0] == '#') //is comment?
                            continue;

                        String[] splittedLine = line.Split('\t'); //split by tabs

                        if (splittedLine.Length < 7) //invalid number of elements
                            continue;

                        try
                        {
                            //create position from data
                            CH1903Position chPos = new CH1903Position(
                                Double.Parse(splittedLine[3]),
                                Double.Parse(splittedLine[2]),
                                Double.Parse(splittedLine[5]));

                            //create placemark from converted position
                            placemarkListForm.AddPlacemark(chPos.ConvertToWGS84(),
                                splittedLine[1] + "(" + splittedLine[0] + ")");
                        }
                        catch (System.OverflowException)
                        {
                            //something with the parsing went wrong, ignore this line
                        }
                        catch (System.FormatException)
                        {
                            //something with the parsing went wrong, ignore this line
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }




        }

        enum ECH1903TokenParsingStates
        {
            SEEK_RECHTSWERT,
            SEEK_HOCHWERT,
            SEEK_HOEHE,
            ALL_FOUND //all values have been found
        }

        enum ERailroadTokenParsingStates
        {
            SeekLongitude,
            SeekLatitude,
            AllFound //all values have been found
        }


        private void btnLoadUKWSitesTxt_Click(object sender, EventArgs e)
        {
            ofdBakomUKW.AddExtension = true;
            ofdBakomUKW.Filter = "text files (*.txt)|*.txt";
            ofdBakomUKW.ShowDialog();
            String bakomUKWSitesFileName = ofdBakomUKW.FileName;

            //TODO 
            //load the text file line by line and parse it
            //try
            //{
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader(bakomUKWSitesFileName))
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null) //as long as lines are left
                {
                    //simple length check
                    if (line.Length < 50) continue; //with next line

                    String[] splittedLine = line.Split(' '); //split by white spaces

                    if (splittedLine.Length < 10) //TODO use 16! invalid number of elements
                        continue; //with next line

                    //position
                    CH1903Position transmitterPosition = new CH1903Position(0, 0, 0);

                    //parse the tokens in that line, use states for parsing the tokens each line
                    ECH1903TokenParsingStates tokenToFind = ECH1903TokenParsingStates.SEEK_RECHTSWERT; //first start witch rechtswert

                    foreach (string token in splittedLine)
                    {
                        try //try reading as current value which we are looking for
                        {
                            switch (tokenToFind) //parse as current element
                            {
                                case ECH1903TokenParsingStates.SEEK_RECHTSWERT:
                                    {
                                        if (token.Length != 6) //not exactly 6 digits?
                                        {
                                            continue;
                                        }

                                        Int32 value = Int32.Parse(token);
                                        transmitterPosition.Rechtswert = value; //keep this apparently valid value
                                        tokenToFind = ECH1903TokenParsingStates.SEEK_HOCHWERT; //set next token to look for
                                        break;
                                    }
                                case ECH1903TokenParsingStates.SEEK_HOCHWERT:
                                    {
                                        if (token.Length != 6) //not exactly 6 digits?
                                        {
                                            continue;
                                        }

                                        Int32 value = Int32.Parse(token);
                                        if (
                                             (value > transmitterPosition.Rechtswert) //not in switzerland
                                            )
                                        {
                                            continue; //with next token
                                        }
                                        transmitterPosition.Hochwert = value; //keep this apparently valid value
                                        tokenToFind = ECH1903TokenParsingStates.SEEK_HOEHE; //set next token to look for
                                        break;
                                    }
                                case ECH1903TokenParsingStates.SEEK_HOEHE:
                                    {
                                        if (
                                             (token.Length < 3) ||
                                             (token.Length > 4)
                                           ) //not between 3 or 4 digits?
                                        {
                                            continue;
                                        }

                                        Int32 value = Int32.Parse(token);
                                        if (
                                             (value < 100) || //value out of bounds
                                             (value > 4000) //value out of bounds
                                            )
                                        {
                                            continue; //with next token
                                        }
                                        transmitterPosition.Hoehe = value; //keep this apparently valid value
                                        tokenToFind = ECH1903TokenParsingStates.ALL_FOUND; //set next token to look for

                                        //create placemark from position and add to list
                                        placemarkListForm.AddPlacemark(transmitterPosition.ConvertToWGS84(),
                                            line);
                                        break;
                                    }
                            }
                        }
                        catch
                        {
                            continue; //with next token
                        }
                    }

                }
            }
            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.ToString());
            //}
        }
        ICollection<string> DirSearch(string sDir, string pattern)
        {
            List<string> filesFound = new List<string>();
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d, pattern))
                    {
                        filesFound.Add(f);
                    }
                    filesFound.AddRange(DirSearch(d, pattern));
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            return filesFound;
        }

        private void _btnLoadRailwayLinesFromTxt_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.RootFolder = Environment.SpecialFolder.MyDocuments;
            DialogResult dlgResult = fb.ShowDialog();

            if (dlgResult == DialogResult.OK)
            {
                toolStripStatusLabel1.Text = "Processing Railwy files...";
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
                backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
                ICollection<string> fileList = DirSearch(fb.SelectedPath, "*.txt");
                backgroundWorker1.RunWorkerAsync(fileList);
            
            }
        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcessRailwayTextFiles(e.Argument as ICollection<string>);
        }

        private void ProcessRailwayTextFiles(ICollection<string> fileList)
        {
            int count = fileList.Count;
            int itemNumber = 0;
            foreach (string fileName in fileList)
            {             

                //load the text file line by line and parse it
                try
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        //create kml representation
                        KMLCreator kml = new KMLCreator(fileName, string.Empty);

                        List<WGS84Position> waypoints = new List<WGS84Position>();

                        String line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null) //as long as lines are left
                        {
                            //simple length check
                            if (line.Length < 20) continue; //with next line

                            String[] splittedLine = line.Split(';');

                            if (splittedLine.Length < 2) //not both lat and long found?
                                continue; //with next line

                            //position
                            WGS84Position railroadWaypoint = new WGS84Position(0, 0, 0);

                            //parse the tokens in that line, use states for parsing the tokens each line
                            ERailroadTokenParsingStates tokenToFind = ERailroadTokenParsingStates.SeekLongitude;

                            foreach (string token in splittedLine)
                            {
                                try //try reading as current value which we are looking for
                                {
                                    switch (tokenToFind) //parse as current element
                                    {
                                        case ERailroadTokenParsingStates.SeekLongitude:
                                            {
                                                Double value = Double.Parse(token);
                                                railroadWaypoint.Longitude = value; //keep this apparently valid value
                                                tokenToFind = ERailroadTokenParsingStates.SeekLatitude; //set next token to look for
                                                break;
                                            }
                                        case ERailroadTokenParsingStates.SeekLatitude:
                                            {
                                                Double value = Double.Parse(token);

                                                railroadWaypoint.Latitude = value; //keep this apparently valid value
                                                tokenToFind = ERailroadTokenParsingStates.AllFound; //finish

                                                //create placemark from position and add to list
                                                //placemarkListForm.AddPlacemark(railroadWaypoint, line);
                                                //kml.AddWaypoint(railroadWaypoint);
                                                waypoints.Add(railroadWaypoint);

                                                break;
                                            }
                                    }
                                }
                                catch
                                {
                                    continue; //with next token
                                }
                            }

                        }
                         kml.AddTrack(waypoints);
                        kml.Create(fileName + ".kml");
                        kml.Show();
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
        }



    }
}
