namespace LiveJourney
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class ManagementForm : Form
    {
        public ManagementForm()
        {
            InitializeComponent();
            this.TrainLineLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            this.TrainLineLayout.AutoSize = true;
        }

        private void AddSizeButton_Click(object sender, EventArgs e)
        {
            this.TrainLineLayout.RowCount = this.TrainLineLayout.RowCount + 1;
            this.TrainLineLayout.ColumnCount = this.TrainLineLayout.ColumnCount + 1;

            this.TrainLineLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.TrainLineLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        }

        private void MinusSizeButton_Click(object sender, EventArgs e)
        {
            this.TrainLineLayout.RowCount = this.TrainLineLayout.RowCount - 1;
            this.TrainLineLayout.ColumnCount = this.TrainLineLayout.ColumnCount - 1;
        }

        private void ManagementForm_Deactivate(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
