namespace SiteVisualizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gBInput = new System.Windows.Forms.GroupBox();
            this.lHoehe = new System.Windows.Forms.Label();
            this.lY = new System.Windows.Forms.Label();
            this.lX = new System.Windows.Forms.Label();
            this.tBHoehe = new System.Windows.Forms.TextBox();
            this.tBRechtswert = new System.Windows.Forms.TextBox();
            this.tBHochwert = new System.Windows.Forms.TextBox();
            this.gBOutput = new System.Windows.Forms.GroupBox();
            this.lHeight = new System.Windows.Forms.Label();
            this.lLong = new System.Windows.Forms.Label();
            this.tBHeight = new System.Windows.Forms.TextBox();
            this.tBLongitude = new System.Windows.Forms.TextBox();
            this.tBLatitude = new System.Windows.Forms.TextBox();
            this.lLat = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddPlacemark = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnLoadSiteTable = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnLoadUKWSitesTxt = new System.Windows.Forms.Button();
            this.btnLoadUKWSites = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this._btnLoadRailwayLinesFromTxt = new System.Windows.Forms.Button();
            this.ofdTetrapolSites = new System.Windows.Forms.OpenFileDialog();
            this.ofdBakomUKW = new System.Windows.Forms.OpenFileDialog();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gBInput.SuspendLayout();
            this.gBOutput.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBInput
            // 
            this.gBInput.Controls.Add(this.lHoehe);
            this.gBInput.Controls.Add(this.lY);
            this.gBInput.Controls.Add(this.lX);
            this.gBInput.Controls.Add(this.tBHoehe);
            this.gBInput.Controls.Add(this.tBRechtswert);
            this.gBInput.Controls.Add(this.tBHochwert);
            this.gBInput.Location = new System.Drawing.Point(6, 6);
            this.gBInput.Name = "gBInput";
            this.gBInput.Size = new System.Drawing.Size(268, 106);
            this.gBInput.TabIndex = 0;
            this.gBInput.TabStop = false;
            this.gBInput.Text = "CH1903 Position";
            // 
            // lHoehe
            // 
            this.lHoehe.AutoSize = true;
            this.lHoehe.Location = new System.Drawing.Point(6, 74);
            this.lHoehe.Name = "lHoehe";
            this.lHoehe.Size = new System.Drawing.Size(33, 13);
            this.lHoehe.TabIndex = 1;
            this.lHoehe.Text = "Höhe";
            // 
            // lY
            // 
            this.lY.AutoSize = true;
            this.lY.Location = new System.Drawing.Point(6, 51);
            this.lY.Name = "lY";
            this.lY.Size = new System.Drawing.Size(61, 13);
            this.lY.TabIndex = 1;
            this.lY.Text = "Rechtswert";
            // 
            // lX
            // 
            this.lX.AutoSize = true;
            this.lX.Location = new System.Drawing.Point(6, 25);
            this.lX.Name = "lX";
            this.lX.Size = new System.Drawing.Size(53, 13);
            this.lX.TabIndex = 1;
            this.lX.Text = "Hochwert";
            // 
            // tBHoehe
            // 
            this.tBHoehe.Location = new System.Drawing.Point(101, 74);
            this.tBHoehe.Name = "tBHoehe";
            this.tBHoehe.Size = new System.Drawing.Size(150, 20);
            this.tBHoehe.TabIndex = 0;
            this.tBHoehe.TextChanged += new System.EventHandler(this.tBAny_TextChanged);
            // 
            // tBRechtswert
            // 
            this.tBRechtswert.Location = new System.Drawing.Point(101, 48);
            this.tBRechtswert.Name = "tBRechtswert";
            this.tBRechtswert.Size = new System.Drawing.Size(150, 20);
            this.tBRechtswert.TabIndex = 0;
            this.tBRechtswert.TextChanged += new System.EventHandler(this.tBAny_TextChanged);
            // 
            // tBHochwert
            // 
            this.tBHochwert.Location = new System.Drawing.Point(101, 22);
            this.tBHochwert.Name = "tBHochwert";
            this.tBHochwert.Size = new System.Drawing.Size(150, 20);
            this.tBHochwert.TabIndex = 0;
            this.tBHochwert.TextChanged += new System.EventHandler(this.tBAny_TextChanged);
            // 
            // gBOutput
            // 
            this.gBOutput.Controls.Add(this.lHeight);
            this.gBOutput.Controls.Add(this.lLong);
            this.gBOutput.Controls.Add(this.tBHeight);
            this.gBOutput.Controls.Add(this.tBLongitude);
            this.gBOutput.Controls.Add(this.tBLatitude);
            this.gBOutput.Controls.Add(this.lLat);
            this.gBOutput.Location = new System.Drawing.Point(6, 118);
            this.gBOutput.Name = "gBOutput";
            this.gBOutput.Size = new System.Drawing.Size(268, 104);
            this.gBOutput.TabIndex = 1;
            this.gBOutput.TabStop = false;
            this.gBOutput.Text = "WGS84 Position";
            // 
            // lHeight
            // 
            this.lHeight.AutoSize = true;
            this.lHeight.Location = new System.Drawing.Point(6, 74);
            this.lHeight.Name = "lHeight";
            this.lHeight.Size = new System.Drawing.Size(38, 13);
            this.lHeight.TabIndex = 1;
            this.lHeight.Text = "Height";
            // 
            // lLong
            // 
            this.lLong.AutoSize = true;
            this.lLong.Location = new System.Drawing.Point(6, 22);
            this.lLong.Name = "lLong";
            this.lLong.Size = new System.Drawing.Size(54, 13);
            this.lLong.TabIndex = 1;
            this.lLong.Text = "Longitude";
            // 
            // tBHeight
            // 
            this.tBHeight.Location = new System.Drawing.Point(101, 71);
            this.tBHeight.Name = "tBHeight";
            this.tBHeight.Size = new System.Drawing.Size(150, 20);
            this.tBHeight.TabIndex = 0;
            this.tBHeight.TextChanged += new System.EventHandler(this.tBAny_TextChanged);
            // 
            // tBLongitude
            // 
            this.tBLongitude.Location = new System.Drawing.Point(101, 19);
            this.tBLongitude.Name = "tBLongitude";
            this.tBLongitude.Size = new System.Drawing.Size(150, 20);
            this.tBLongitude.TabIndex = 0;
            this.tBLongitude.TextChanged += new System.EventHandler(this.tBAny_TextChanged);
            // 
            // tBLatitude
            // 
            this.tBLatitude.Location = new System.Drawing.Point(101, 45);
            this.tBLatitude.Name = "tBLatitude";
            this.tBLatitude.Size = new System.Drawing.Size(150, 20);
            this.tBLatitude.TabIndex = 0;
            this.tBLatitude.TextChanged += new System.EventHandler(this.tBAny_TextChanged);
            // 
            // lLat
            // 
            this.lLat.AutoSize = true;
            this.lLat.Location = new System.Drawing.Point(6, 48);
            this.lLat.Name = "lLat";
            this.lLat.Size = new System.Drawing.Size(45, 13);
            this.lLat.TabIndex = 1;
            this.lLat.Text = "Latitude";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(148, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(147, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(147, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(126, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // btnAddPlacemark
            // 
            this.btnAddPlacemark.Location = new System.Drawing.Point(6, 228);
            this.btnAddPlacemark.Name = "btnAddPlacemark";
            this.btnAddPlacemark.Size = new System.Drawing.Size(268, 23);
            this.btnAddPlacemark.TabIndex = 3;
            this.btnAddPlacemark.Text = "Add Placemark";
            this.btnAddPlacemark.UseVisualStyleBackColor = true;
            this.btnAddPlacemark.Click += new System.EventHandler(this.btnAddPlacemark_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 355);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(639, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 321);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gBInput);
            this.tabPage1.Controls.Add(this.gBOutput);
            this.tabPage1.Controls.Add(this.btnAddPlacemark);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(376, 295);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnLoadSiteTable);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(376, 295);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tetrapol Sites";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnLoadSiteTable
            // 
            this.btnLoadSiteTable.Location = new System.Drawing.Point(59, 18);
            this.btnLoadSiteTable.Name = "btnLoadSiteTable";
            this.btnLoadSiteTable.Size = new System.Drawing.Size(141, 23);
            this.btnLoadSiteTable.TabIndex = 0;
            this.btnLoadSiteTable.Text = "Load SiteTable...";
            this.btnLoadSiteTable.UseVisualStyleBackColor = true;
            this.btnLoadSiteTable.Click += new System.EventHandler(this.btnLoadSiteTable_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnLoadUKWSitesTxt);
            this.tabPage3.Controls.Add(this.btnLoadUKWSites);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(376, 295);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "BAKOM UKW Sites (PDF)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnLoadUKWSitesTxt
            // 
            this.btnLoadUKWSitesTxt.Location = new System.Drawing.Point(46, 79);
            this.btnLoadUKWSitesTxt.Name = "btnLoadUKWSitesTxt";
            this.btnLoadUKWSitesTxt.Size = new System.Drawing.Size(221, 23);
            this.btnLoadUKWSitesTxt.TabIndex = 1;
            this.btnLoadUKWSitesTxt.Text = "Load UKW Sites from TXT...";
            this.btnLoadUKWSitesTxt.UseVisualStyleBackColor = true;
            this.btnLoadUKWSitesTxt.Click += new System.EventHandler(this.btnLoadUKWSitesTxt_Click);
            // 
            // btnLoadUKWSites
            // 
            this.btnLoadUKWSites.Location = new System.Drawing.Point(46, 39);
            this.btnLoadUKWSites.Name = "btnLoadUKWSites";
            this.btnLoadUKWSites.Size = new System.Drawing.Size(221, 23);
            this.btnLoadUKWSites.TabIndex = 0;
            this.btnLoadUKWSites.Text = "Load UKW Sites from PDF...";
            this.btnLoadUKWSites.UseVisualStyleBackColor = true;
            this.btnLoadUKWSites.Click += new System.EventHandler(this.btnLoadUKWSitesPDF_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this._btnLoadRailwayLinesFromTxt);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(376, 295);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Railway Lines";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // _btnLoadRailwayLinesFromTxt
            // 
            this._btnLoadRailwayLinesFromTxt.Location = new System.Drawing.Point(35, 29);
            this._btnLoadRailwayLinesFromTxt.Name = "_btnLoadRailwayLinesFromTxt";
            this._btnLoadRailwayLinesFromTxt.Size = new System.Drawing.Size(218, 23);
            this._btnLoadRailwayLinesFromTxt.TabIndex = 0;
            this._btnLoadRailwayLinesFromTxt.Text = "Load Railway Lines from Txt";
            this._btnLoadRailwayLinesFromTxt.UseVisualStyleBackColor = true;
            this._btnLoadRailwayLinesFromTxt.Click += new System.EventHandler(this._btnLoadRailwayLinesFromTxt_Click);
            // 
            // ofdTetrapolSites
            // 
            this.ofdTetrapolSites.FileName = "openFileDialog1";
            // 
            // ofdBakomUKW
            // 
            this.ofdBakomUKW.DefaultExt = "pdf";
            this.ofdBakomUKW.FileName = "openFileDialog1";
            this.ofdBakomUKW.Filter = "\"PDF files (*.pdf)\"|*.pdf";
            this.ofdBakomUKW.Title = "Open Bakom UKW Site List";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 377);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Converter CH1903<->WGS84";
            this.gBInput.ResumeLayout(false);
            this.gBInput.PerformLayout();
            this.gBOutput.ResumeLayout(false);
            this.gBOutput.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBInput;
        private System.Windows.Forms.GroupBox gBOutput;
        private System.Windows.Forms.Label lX;
        private System.Windows.Forms.TextBox tBRechtswert;
        private System.Windows.Forms.TextBox tBHochwert;
        private System.Windows.Forms.Label lY;
        private System.Windows.Forms.TextBox tBLatitude;
        private System.Windows.Forms.Label lLong;
        private System.Windows.Forms.TextBox tBLongitude;
        private System.Windows.Forms.Label lLat;
        private System.Windows.Forms.Label lHoehe;
        private System.Windows.Forms.TextBox tBHoehe;
        private System.Windows.Forms.Label lHeight;
        private System.Windows.Forms.TextBox tBHeight;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnAddPlacemark;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnLoadSiteTable;
        private System.Windows.Forms.OpenFileDialog ofdTetrapolSites;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnLoadUKWSites;
        private System.Windows.Forms.OpenFileDialog ofdBakomUKW;
        private System.Windows.Forms.Button btnLoadUKWSitesTxt;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button _btnLoadRailwayLinesFromTxt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

