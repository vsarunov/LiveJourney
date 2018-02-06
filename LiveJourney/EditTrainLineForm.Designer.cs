namespace LiveJourney
{
    partial class EditTrainLineForm
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
            this.TrainLineNameLabel = new System.Windows.Forms.Label();
            this.TrainLineNameTextBox = new System.Windows.Forms.TextBox();
            this.TrainLineColourLabel = new System.Windows.Forms.Label();
            this.TrainLineColourComboBox = new System.Windows.Forms.ComboBox();
            this.SubmitEditingsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.TrainLineNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TrainLineNameTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TrainLineColourLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TrainLineColourComboBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.SubmitEditingsButton, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.73885F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.13187F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.08791F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.50549F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(299, 160);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.TrainLineNameLabel.Size = new System.Drawing.Size(293, 20);
            this.TrainLineNameLabel.TabIndex = 1;
            this.TrainLineNameLabel.Text = "Train Line Name:";
            // 
            // TrainLineNameTextBox
            // 
            this.TrainLineNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrainLineNameTextBox.Location = new System.Drawing.Point(3, 23);
            this.TrainLineNameTextBox.Name = "TrainLineNameTextBox";
            this.TrainLineNameTextBox.Size = new System.Drawing.Size(293, 20);
            this.TrainLineNameTextBox.TabIndex = 3;
            // 
            // TrainLineColourLabel
            // 
            this.TrainLineColourLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrainLineColourLabel.AutoSize = true;
            this.TrainLineColourLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.TrainLineColourLabel.Location = new System.Drawing.Point(3, 48);
            this.TrainLineColourLabel.Name = "TrainLineColourLabel";
            this.TrainLineColourLabel.Size = new System.Drawing.Size(293, 19);
            this.TrainLineColourLabel.TabIndex = 4;
            this.TrainLineColourLabel.Text = "Train Line Colour";
            // 
            // TrainLineColourComboBox
            // 
            this.TrainLineColourComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrainLineColourComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.TrainLineColourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrainLineColourComboBox.FormattingEnabled = true;
            this.TrainLineColourComboBox.Location = new System.Drawing.Point(3, 70);
            this.TrainLineColourComboBox.Name = "TrainLineColourComboBox";
            this.TrainLineColourComboBox.Size = new System.Drawing.Size(293, 21);
            this.TrainLineColourComboBox.TabIndex = 5;
            this.TrainLineColourComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TrainLineColourComboBox_DrawItem);
            // 
            // SubmitEditingsButton
            // 
            this.SubmitEditingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitEditingsButton.Location = new System.Drawing.Point(3, 92);
            this.SubmitEditingsButton.Name = "SubmitEditingsButton";
            this.SubmitEditingsButton.Size = new System.Drawing.Size(293, 65);
            this.SubmitEditingsButton.TabIndex = 6;
            this.SubmitEditingsButton.Text = "Submit Edittings ";
            this.SubmitEditingsButton.UseVisualStyleBackColor = true;
            this.SubmitEditingsButton.Click += new System.EventHandler(this.SubmitEditingsButton_Click);
            // 
            // EditTrainLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 160);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EditTrainLineForm";
            this.Text = "EditTrainLineForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label TrainLineNameLabel;
        private System.Windows.Forms.TextBox TrainLineNameTextBox;
        private System.Windows.Forms.Label TrainLineColourLabel;
        private System.Windows.Forms.ComboBox TrainLineColourComboBox;
        private System.Windows.Forms.Button SubmitEditingsButton;
    }
}