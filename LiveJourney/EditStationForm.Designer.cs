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
            this.StationNameLabel = new System.Windows.Forms.Label();
            this.DisntanceLabel = new System.Windows.Forms.Label();
            this.StationNameTextBox = new System.Windows.Forms.TextBox();
            this.MyUniqueTextBox = new MyCustomTextBox.MyBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DelayTextBox = new MyCustomTextBox.MyBox();
            this.SubmitChangesButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.DelayTextBox, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.MyUniqueTextBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.StationNameTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.StationNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DisntanceLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SubmitChangesButton, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.74359F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.82051F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.76923F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.28205F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.53846F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.51283F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(274, 206);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.StationNameLabel.Size = new System.Drawing.Size(268, 20);
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
            this.DisntanceLabel.Location = new System.Drawing.Point(3, 46);
            this.DisntanceLabel.Name = "DisntanceLabel";
            this.DisntanceLabel.Size = new System.Drawing.Size(268, 22);
            this.DisntanceLabel.TabIndex = 3;
            this.DisntanceLabel.Text = "Distance To Previous Stations (km):";
            // 
            // StationNameTextBox
            // 
            this.StationNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StationNameTextBox.Location = new System.Drawing.Point(3, 23);
            this.StationNameTextBox.Name = "StationNameTextBox";
            this.StationNameTextBox.Size = new System.Drawing.Size(268, 20);
            this.StationNameTextBox.TabIndex = 4;
            // 
            // MyUniqueTextBox
            // 
            this.MyUniqueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyUniqueTextBox.Location = new System.Drawing.Point(3, 71);
            this.MyUniqueTextBox.Name = "MyUniqueTextBox";
            this.MyUniqueTextBox.Size = new System.Drawing.Size(268, 20);
            this.MyUniqueTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(3, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Delay (In minutes):";
            // 
            // DelayTextBox
            // 
            this.DelayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DelayTextBox.Location = new System.Drawing.Point(3, 121);
            this.DelayTextBox.Name = "DelayTextBox";
            this.DelayTextBox.Size = new System.Drawing.Size(268, 20);
            this.DelayTextBox.TabIndex = 7;
            // 
            // SubmitChangesButton
            // 
            this.SubmitChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitChangesButton.Location = new System.Drawing.Point(3, 165);
            this.SubmitChangesButton.Name = "SubmitChangesButton";
            this.SubmitChangesButton.Size = new System.Drawing.Size(268, 23);
            this.SubmitChangesButton.TabIndex = 8;
            this.SubmitChangesButton.Text = "Submit changes";
            this.SubmitChangesButton.UseVisualStyleBackColor = true;
            this.SubmitChangesButton.Click += new System.EventHandler(this.SubmitChangesButton_Click);
            // 
            // EditStationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 206);
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
        private System.Windows.Forms.Label label1;
        private MyCustomTextBox.MyBox DelayTextBox;
        private System.Windows.Forms.Button SubmitChangesButton;
    }
}