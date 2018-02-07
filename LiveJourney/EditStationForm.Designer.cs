namespace LiveJourney
{
    partial class EditStationForm
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
            this.MyUniqueTextBox = new MyCustomTextBox.MyBox();
            this.StationNameTextBox = new System.Windows.Forms.TextBox();
            this.StationNameLabel = new System.Windows.Forms.Label();
            this.DisntanceLabel = new System.Windows.Forms.Label();
            this.SubmitChangesButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.MyUniqueTextBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.StationNameTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.StationNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DisntanceLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SubmitChangesButton, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.55319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.08511F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.95745F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.14894F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.7234F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(281, 188);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MyUniqueTextBox
            // 
            this.MyUniqueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyUniqueTextBox.Location = new System.Drawing.Point(3, 100);
            this.MyUniqueTextBox.Name = "MyUniqueTextBox";
            this.MyUniqueTextBox.Size = new System.Drawing.Size(275, 20);
            this.MyUniqueTextBox.TabIndex = 5;
            // 
            // StationNameTextBox
            // 
            this.StationNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StationNameTextBox.Location = new System.Drawing.Point(3, 36);
            this.StationNameTextBox.Name = "StationNameTextBox";
            this.StationNameTextBox.Size = new System.Drawing.Size(275, 20);
            this.StationNameTextBox.TabIndex = 4;
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
            this.StationNameLabel.Size = new System.Drawing.Size(275, 33);
            this.StationNameLabel.TabIndex = 2;
            this.StationNameLabel.Text = "Station Name:";
            // 
            // DisntanceLabel
            // 
            this.DisntanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisntanceLabel.AutoSize = true;
            this.DisntanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.DisntanceLabel.Location = new System.Drawing.Point(3, 67);
            this.DisntanceLabel.Name = "DisntanceLabel";
            this.DisntanceLabel.Size = new System.Drawing.Size(275, 30);
            this.DisntanceLabel.TabIndex = 3;
            this.DisntanceLabel.Text = "Distance To Previous Stations (km):";
            // 
            // SubmitChangesButton
            // 
            this.SubmitChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitChangesButton.Location = new System.Drawing.Point(3, 136);
            this.SubmitChangesButton.Name = "SubmitChangesButton";
            this.SubmitChangesButton.Size = new System.Drawing.Size(275, 23);
            this.SubmitChangesButton.TabIndex = 8;
            this.SubmitChangesButton.Text = "Submit changes";
            this.SubmitChangesButton.UseVisualStyleBackColor = true;
            this.SubmitChangesButton.Click += new System.EventHandler(this.SubmitChangesButton_Click);
            // 
            // EditStationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 188);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EditStationForm";
            this.Text = "EditStationForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label StationNameLabel;
        private System.Windows.Forms.Label DisntanceLabel;
        private System.Windows.Forms.TextBox StationNameTextBox;
        private MyCustomTextBox.MyBox MyUniqueTextBox;
        private System.Windows.Forms.Button SubmitChangesButton;
    }
}