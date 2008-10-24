using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using bfhmarcel.googleearth;

namespace SiteVisualizer
{
    public partial class PlacemarkListForm : Form
    {

        public PlacemarkListForm()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        public void AddPlacemark(WGS84Position aPosition, string aName)
        {
            string[] row = { aPosition.Longitude.ToString(), aPosition.Latitude.ToString(), aName };

            dgvPlacemarks.Rows.Add(row);

        }

        private void SetupDataGridView()
        {

            this.Controls.Add(dgvPlacemarks);

            dgvPlacemarks.ColumnCount = 3;

            dgvPlacemarks.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvPlacemarks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPlacemarks.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgvPlacemarks.Font, FontStyle.Bold);

            dgvPlacemarks.Name = "dgvPlacemarks";
            dgvPlacemarks.Location = new Point(8, 8);
            dgvPlacemarks.Size = new Size(500, 250);
            dgvPlacemarks.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvPlacemarks.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dgvPlacemarks.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvPlacemarks.GridColor = Color.Black;
            dgvPlacemarks.RowHeadersVisible = false;

            dgvPlacemarks.Columns[0].Name = "Long.";
            dgvPlacemarks.Columns[1].Name = "Lat.";
            dgvPlacemarks.Columns[2].Name = "Name";

            dgvPlacemarks.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvPlacemarks.MultiSelect = false;
            dgvPlacemarks.Dock = DockStyle.Fill;

            /* dgvPlacemarks.CellFormatting += new
                 DataGridViewCellFormattingEventHandler(
                 dgvPlacemarks_CellFormatting);*/
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            KMLCreator creator = new KMLCreator();

            //add all placemark entries from the dgv

            //string[] row0 = new String[1];
            DataGridViewRowCollection rows = dgvPlacemarks.Rows;

            //go through all rows and create placemarks out of them

            //TODO test
           // foreach (DataGridViewCellCollection cells in rows.)            
            foreach (DataGridViewRow myRow in rows)
            {
                DataGridViewCellCollection cells = myRow.Cells;
                /*
            for (int rowCounter = 0; rowCounter < rows.Count; rowCounter++)
            {
                DataGridViewRow myRow = rows[rowCounter];
                DataGridViewCellCollection cells = myRow.Cells;
                */

                string longStr;
                string latStr;
                string name;
                try
                {
                    //convert to strings
                    longStr = cells[0].Value.ToString();
                    latStr = cells[1].Value.ToString();
                    name = cells[2].Value.ToString();


                }
                catch (NullReferenceException)
                {
                    //ignore this row
                    continue;
                }





                /*
                //DataGridViewRow dgvPlacemarks.rows;

                //DataGridViewCellCollection dgvplacemarks.cells;

                DataGridViewRowCollection rows = dgvPlacemarks.Rows;
                //DataGridViewCell[] cells = row.CopyTo();
                DataGridViewRow[] rowsArray = new DataGridViewRow[rows.Count];
                rows.CopyTo(rowsArray, 0);

                String[] cellsArray = new String[rowsArray.GetLength(0)];
                rowsArray.CopyTo(cellsArray, 0);



                //DataGridViewCell[] cellsArray;
                //cells.CopyTo(cellsArray);
                string longStr = cellsArray[0].ToString();
                string latStr = cellsArray[1].ToString();
                string name = cellsArray[2].ToString();
                 * */

                WGS84Position pos = new WGS84Position(Double.Parse(longStr), Double.Parse(latStr), 0);



                creator.AddPlacemark(pos, name);
            }
            creator.Create("c:\\temp\\testKMLSave.kml");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            KMLCreator creator = new KMLCreator();

            //add all placemark entries from the dgv

            //string[] row0 = new String[1];
            DataGridViewRowCollection rows = dgvPlacemarks.Rows;

            //go through all rows and create placemarks out of them

            //TODO test
            // foreach (DataGridViewCellCollection cells in rows.)            
            foreach (DataGridViewRow myRow in rows)
            {
                DataGridViewCellCollection cells = myRow.Cells;
                /*
            for (int rowCounter = 0; rowCounter < rows.Count; rowCounter++)
            {
                DataGridViewRow myRow = rows[rowCounter];
                DataGridViewCellCollection cells = myRow.Cells;
                */

                string longStr;
                string latStr;
                string name;
                try
                {
                    //convert to strings
                    longStr = cells[0].Value.ToString();
                    latStr = cells[1].Value.ToString();
                    name = cells[2].Value.ToString();


                }
                catch (NullReferenceException)
                {
                    //ignore this row
                    continue;
                }





                /*
                //DataGridViewRow dgvPlacemarks.rows;

                //DataGridViewCellCollection dgvplacemarks.cells;

                DataGridViewRowCollection rows = dgvPlacemarks.Rows;
                //DataGridViewCell[] cells = row.CopyTo();
                DataGridViewRow[] rowsArray = new DataGridViewRow[rows.Count];
                rows.CopyTo(rowsArray, 0);

                String[] cellsArray = new String[rowsArray.GetLength(0)];
                rowsArray.CopyTo(cellsArray, 0);



                //DataGridViewCell[] cellsArray;
                //cells.CopyTo(cellsArray);
                string longStr = cellsArray[0].ToString();
                string latStr = cellsArray[1].ToString();
                string name = cellsArray[2].ToString();
                 * */

                WGS84Position pos = new WGS84Position(Double.Parse(longStr), Double.Parse(latStr), 0);



                creator.AddPlacemark(pos, name);
            }
            creator.Show();
        }

    }
}