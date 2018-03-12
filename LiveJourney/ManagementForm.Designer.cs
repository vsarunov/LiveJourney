namespace LiveJourney
{
    partial class ManagementForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.TrainLineNameLabel = new System.Windows.Forms.Label();
            this.TrainLineColourLabel = new System.Windows.Forms.Label();
            this.TrainLineNameTextBox = new System.Windows.Forms.TextBox();
            this.TrainLineColourComboBox = new System.Windows.Forms.ComboBox();
            this.AddTrainLineButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TravelSpeedTextBox = new MyCustomTextBox.MyBox();
            this.DepartureTimeTextBox = new MyCustomTextBox.MyBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.TrainLineListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeleteTrainLineButton = new System.Windows.Forms.Button();
            this.EditTrainLineButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.StationListView = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeleteStationButton = new System.Windows.Forms.Button();
            this.EditStationButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.StationNameLabel = new System.Windows.Forms.Label();
            this.DisntanceLabel = new System.Windows.Forms.Label();
            this.StationNameTextBox = new System.Windows.Forms.TextBox();
            this.AddStationButton = new System.Windows.Forms.Button();
            this.MyUniqueTextBox = new MyCustomTextBox.MyBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.69325F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.30675F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1315, 749);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.97222F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.02778F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 743F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(647, 743);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.TrainLineNameLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.TrainLineColourLabel, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.TrainLineNameTextBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.TrainLineColourComboBox, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.AddTrainLineButton, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.TravelSpeedTextBox, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.DepartureTimeTextBox, 0, 7);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 10;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.57599F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.980843F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.448276F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.086845F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.342273F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.363985F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.236271F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.747127F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.108557F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.13155F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(162, 737);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // TrainLineNameLabel
            // 
            this.TrainLineNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrainLineNameLabel.AutoSize = true;
            this.TrainLineNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.TrainLineNameLabel.Location = new System.Drawing.Point(3, 0);
            this.TrainLineNameLabel.Name = "TrainLineNameLabel";
            this.TrainLineNameLabel.Size = new System.Drawing.Size(156, 26);
            this.TrainLineNameLabel.TabIndex = 0;
            this.TrainLineNameLabel.Text = "Train Line Name:";
            // 
            // TrainLineColourLabel
            // 
            this.TrainLineColourLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrainLineColourLabel.AutoSize = true;
            this.TrainLineColourLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.TrainLineColourLabel.Location = new System.Drawing.Point(3, 62);
            this.TrainLineColourLabel.Name = "TrainLineColourLabel";
            this.TrainLineColourLabel.Size = new System.Drawing.Size(156, 25);
            this.TrainLineColourLabel.TabIndex = 1;
            this.TrainLineColourLabel.Text = "Train Line Colour";
            // 
            // TrainLineNameTextBox
            // 
            this.TrainLineNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrainLineNameTextBox.Location = new System.Drawing.Point(3, 29);
            this.TrainLineNameTextBox.Name = "TrainLineNameTextBox";
            this.TrainLineNameTextBox.Size = new System.Drawing.Size(156, 20);
            this.TrainLineNameTextBox.TabIndex = 2;
            // 
            // TrainLineColourComboBox
            // 
            this.TrainLineColourComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrainLineColourComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.TrainLineColourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrainLineColourComboBox.FormattingEnabled = true;
            this.TrainLineColourComboBox.Location = new System.Drawing.Point(3, 90);
            this.TrainLineColourComboBox.Name = "TrainLineColourComboBox";
            this.TrainLineColourComboBox.Size = new System.Drawing.Size(156, 21);
            this.TrainLineColourComboBox.TabIndex = 4;
            this.TrainLineColourComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TrainLineColourComboBox_DrawItem);
            // 
            // AddTrainLineButton
            // 
            this.AddTrainLineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddTrainLineButton.Location = new System.Drawing.Point(3, 268);
            this.AddTrainLineButton.Name = "AddTrainLineButton";
            this.AddTrainLineButton.Size = new System.Drawing.Size(156, 31);
            this.AddTrainLineButton.TabIndex = 3;
            this.AddTrainLineButton.Text = "Add Train Line";
            this.AddTrainLineButton.UseVisualStyleBackColor = true;
            this.AddTrainLineButton.Click += new System.EventHandler(this.AddTrainLineButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(3, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Train Travel Speed (km):";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(3, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 38);
            this.label2.TabIndex = 6;
            this.label2.Text = "Train departs every (min):";
            // 
            // TravelSpeedTextBox
            // 
            this.TravelSpeedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TravelSpeedTextBox.Location = new System.Drawing.Point(3, 150);
            this.TravelSpeedTextBox.Name = "TravelSpeedTextBox";
            this.TravelSpeedTextBox.Size = new System.Drawing.Size(156, 20);
            this.TravelSpeedTextBox.TabIndex = 0;
            // 
            // DepartureTimeTextBox
            // 
            this.DepartureTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DepartureTimeTextBox.Location = new System.Drawing.Point(3, 227);
            this.DepartureTimeTextBox.Name = "DepartureTimeTextBox";
            this.DepartureTimeTextBox.Size = new System.Drawing.Size(156, 20);
            this.DepartureTimeTextBox.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.TrainLineListView, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.DeleteTrainLineButton, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.EditTrainLineButton, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(171, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.94891F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.641124F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.768838F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.51341F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(473, 737);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // TrainLineListView
            // 
            this.TrainLineListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.TrainLineListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrainLineListView.FullRowSelect = true;
            this.TrainLineListView.Location = new System.Drawing.Point(3, 3);
            this.TrainLineListView.MultiSelect = false;
            this.TrainLineListView.Name = "TrainLineListView";
            this.TrainLineListView.Size = new System.Drawing.Size(467, 583);
            this.TrainLineListView.TabIndex = 0;
            this.TrainLineListView.UseCompatibleStateImageBehavior = false;
            this.TrainLineListView.View = System.Windows.Forms.View.Details;
            this.TrainLineListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.TrainLineListView_ItemSelectionChanged);
            this.TrainLineListView.DoubleClick += new System.EventHandler(this.TrainLineListView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Train Line name";
            this.columnHeader1.Width = 88;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Train Line Colour";
            this.columnHeader2.Width = 92;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Train line travel speed (km)";
            this.columnHeader4.Width = 139;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Train Departure Every (min)";
            this.columnHeader5.Width = 141;
            // 
            // DeleteTrainLineButton
            // 
            this.DeleteTrainLineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteTrainLineButton.Location = new System.Drawing.Point(3, 592);
            this.DeleteTrainLineButton.Name = "DeleteTrainLineButton";
            this.DeleteTrainLineButton.Size = new System.Drawing.Size(467, 43);
            this.DeleteTrainLineButton.TabIndex = 1;
            this.DeleteTrainLineButton.Text = "Delete Train Line";
            this.DeleteTrainLineButton.UseVisualStyleBackColor = true;
            this.DeleteTrainLineButton.Click += new System.EventHandler(this.DeleteTrainLineButton_Click);
            // 
            // EditTrainLineButton
            // 
            this.EditTrainLineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditTrainLineButton.Location = new System.Drawing.Point(3, 641);
            this.EditTrainLineButton.Name = "EditTrainLineButton";
            this.EditTrainLineButton.Size = new System.Drawing.Size(467, 43);
            this.EditTrainLineButton.TabIndex = 2;
            this.EditTrainLineButton.Text = "Edit Train Line/Add delay";
            this.EditTrainLineButton.UseVisualStyleBackColor = true;
            this.EditTrainLineButton.Click += new System.EventHandler(this.EditTrainLineButton_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.5122F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.4878F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(656, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 725F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(656, 743);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.StationListView, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.DeleteStationButton, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.EditStationButton, 0, 2);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(295, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.92628F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.258693F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.675939F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(358, 737);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // StationListView
            // 
            this.StationListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.StationListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StationListView.Enabled = false;
            this.StationListView.FullRowSelect = true;
            this.StationListView.Location = new System.Drawing.Point(3, 3);
            this.StationListView.MultiSelect = false;
            this.StationListView.Name = "StationListView";
            this.StationListView.Size = new System.Drawing.Size(352, 635);
            this.StationListView.TabIndex = 0;
            this.StationListView.UseCompatibleStateImageBehavior = false;
            this.StationListView.View = System.Windows.Forms.View.Details;
            this.StationListView.DoubleClick += new System.EventHandler(this.StationListView_DoubleClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Nr.";
            this.columnHeader6.Width = 26;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Name";
            this.columnHeader7.Width = 103;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Distance to Previous Station (km)";
            this.columnHeader8.Width = 175;
            // 
            // DeleteStationButton
            // 
            this.DeleteStationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteStationButton.Enabled = false;
            this.DeleteStationButton.Location = new System.Drawing.Point(3, 644);
            this.DeleteStationButton.Name = "DeleteStationButton";
            this.DeleteStationButton.Size = new System.Drawing.Size(352, 40);
            this.DeleteStationButton.TabIndex = 1;
            this.DeleteStationButton.Text = "Deleted Selected Station";
            this.DeleteStationButton.UseVisualStyleBackColor = true;
            this.DeleteStationButton.Click += new System.EventHandler(this.DeleteStationButton_Click);
            // 
            // EditStationButton
            // 
            this.EditStationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditStationButton.Enabled = false;
            this.EditStationButton.Location = new System.Drawing.Point(3, 690);
            this.EditStationButton.Name = "EditStationButton";
            this.EditStationButton.Size = new System.Drawing.Size(352, 44);
            this.EditStationButton.TabIndex = 2;
            this.EditStationButton.Text = "Edit Station";
            this.EditStationButton.UseVisualStyleBackColor = true;
            this.EditStationButton.Click += new System.EventHandler(this.EditStationButton_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.StationNameLabel, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.DisntanceLabel, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.StationNameTextBox, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.AddStationButton, 0, 4);
            this.tableLayoutPanel7.Controls.Add(this.MyUniqueTextBox, 0, 3);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 6;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.496533F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.698567F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.894298F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.006954F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.4242F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.97218F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(286, 737);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // StationNameLabel
            // 
            this.StationNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StationNameLabel.AutoSize = true;
            this.StationNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.StationNameLabel.Location = new System.Drawing.Point(3, 0);
            this.StationNameLabel.Name = "StationNameLabel";
            this.StationNameLabel.Size = new System.Drawing.Size(280, 18);
            this.StationNameLabel.TabIndex = 1;
            this.StationNameLabel.Text = "Station Name:";
            // 
            // DisntanceLabel
            // 
            this.DisntanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisntanceLabel.AutoSize = true;
            this.DisntanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.DisntanceLabel.Location = new System.Drawing.Point(3, 45);
            this.DisntanceLabel.Name = "DisntanceLabel";
            this.DisntanceLabel.Size = new System.Drawing.Size(280, 28);
            this.DisntanceLabel.TabIndex = 2;
            this.DisntanceLabel.Text = "Distance To Previous Stations (km):";
            // 
            // StationNameTextBox
            // 
            this.StationNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StationNameTextBox.Enabled = false;
            this.StationNameTextBox.Location = new System.Drawing.Point(3, 21);
            this.StationNameTextBox.Name = "StationNameTextBox";
            this.StationNameTextBox.Size = new System.Drawing.Size(280, 20);
            this.StationNameTextBox.TabIndex = 3;
            // 
            // AddStationButton
            // 
            this.AddStationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddStationButton.Enabled = false;
            this.AddStationButton.Location = new System.Drawing.Point(3, 112);
            this.AddStationButton.Name = "AddStationButton";
            this.AddStationButton.Size = new System.Drawing.Size(280, 33);
            this.AddStationButton.TabIndex = 4;
            this.AddStationButton.Text = "Add Station";
            this.AddStationButton.UseVisualStyleBackColor = true;
            this.AddStationButton.Click += new System.EventHandler(this.AddStationButton_Click);
            // 
            // MyUniqueTextBox
            // 
            this.MyUniqueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyUniqueTextBox.Enabled = false;
            this.MyUniqueTextBox.Location = new System.Drawing.Point(3, 76);
            this.MyUniqueTextBox.Name = "MyUniqueTextBox";
            this.MyUniqueTextBox.Size = new System.Drawing.Size(280, 20);
            this.MyUniqueTextBox.TabIndex = 0;
            // 
            // ManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 749);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ManagementForm";
            this.Text = "ManagementForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManagementForm_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label TrainLineNameLabel;
        private System.Windows.Forms.Label TrainLineColourLabel;
        private System.Windows.Forms.TextBox TrainLineNameTextBox;
        private System.Windows.Forms.Button AddTrainLineButton;
        private System.Windows.Forms.ComboBox TrainLineColourComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ListView TrainLineListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button DeleteTrainLineButton;
        private System.Windows.Forms.Button EditTrainLineButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.ListView StationListView;
        private System.Windows.Forms.Button DeleteStationButton;
        private System.Windows.Forms.Button EditStationButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label StationNameLabel;
        private System.Windows.Forms.Label DisntanceLabel;
        private System.Windows.Forms.TextBox StationNameTextBox;
        private System.Windows.Forms.Button AddStationButton;
        private MyCustomTextBox.MyBox MyUniqueTextBox;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MyCustomTextBox.MyBox TravelSpeedTextBox;
        private MyCustomTextBox.MyBox DepartureTimeTextBox;
    }
}