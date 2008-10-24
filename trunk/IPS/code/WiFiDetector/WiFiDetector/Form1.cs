using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace WiFiDetector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //label1.Text = GetSignalStrengthAsInt(label2).ToString();
            RetrieveSignalString();

        }

        private double RetrieveSignalString()
        {

            double theSignalStrength = 0;
            string ssid = string.Empty;

            ConnectionOptions theConnectionOptions = new ConnectionOptions();

            ManagementScope theManagementScope = new ManagementScope("root\\wmi");

            ObjectQuery theObjectQuery = new ObjectQuery("SELECT * FROM MSNdis_80211_ReceivedSignalStrength WHERE active=true");

            ManagementObjectSearcher theQuery = new ManagementObjectSearcher(theManagementScope, theObjectQuery);

            try
            {

                //ManagementObjectCollection theResults = theQuery.Get();

                foreach (ManagementObject currentObject in theQuery.Get())
                {

                    theSignalStrength = theSignalStrength + Convert.ToDouble(currentObject["Ndis80211ReceivedSignalStrength"]);
                    ssid = ssid + currentObject["Ndis80211SsId"]);

                }

            }

            catch (Exception e)
            {

                //handle

            }



            return Convert.ToDouble(theSignalStrength);

        }

//        public static int GetSignalStrengthAsInt(Label label2)
//        {
//            Int32 returnStrength = 0;
//            ManagementObjectSearcher searcher = null;
//            try
//            {
//                // Query the management object with the valid scope and the
//                //correct query statment
//                searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSNdis_80211_ReceivedSignalStrength where active=true");

//                // Call the get in order to populate the collection
//                ManagementObjectCollection adapterObjects = searcher.Get();
//                // Loop though the management object and pull out the signal
//                //strength
//                foreach (ManagementObject mo in adapterObjects)
//                {
//                    //returnStrength = Convert.ToInt32(mo.GetQualifierValue("Ndis80211ReceivedSignalStrength"));
//                    ManagementObjectCollection moc = mo.GetRelated("Ndis80211ReceivedSignalStrength");

////Dim objarr() As Management.ManagementBaseObject = CType(moe.Current.Properties("Ndis80211BSSIList").Value, Management.ManagementBaseObject())

//                    foreach (ManagementBaseObject  moco in moc)
//                    {
//                        moco

//                    }

//                    ManagementBaseObject mbo = 

//                    moc.
//                    //returnStrength = Convert.ToDouble(mo("Ndis80211ReceivedSignalStrength"));
//                    break;
//                }   

//            }
//            catch (Exception e)
//            {
//                label2.Text = e.Message;
//            }
//            finally
//            {
//                if (searcher != null)
//                {
//                    searcher.Dispose();
//                }
//            }

//            return returnStrength;
//        }


    }
}
