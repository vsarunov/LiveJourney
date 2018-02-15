using DataAccess.Repository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveJourney
{
    public partial class EditTrainLineForm : Form
    {
        private readonly IMainRepository MainRepo;
        private readonly IEnumerable<TrainLine> TrainLines;
        private readonly TrainLine TrainLineToEdit;
        private readonly List<DelayModel> Delays = new List<DelayModel>();

        public EditTrainLineForm(TrainLine trainLineToEdit, IEnumerable<TrainLine> trainLinesToCheck, IMainRepository mainRepo)
        {
            InitializeComponent();
            this.MainRepo = mainRepo;
            this.TrainLines = trainLinesToCheck;
            this.TrainLineToEdit = trainLineToEdit;
            this.PopulateFirstStationComboBox(); // Does not work for some reason need to find out
            this.PopulateComboBoxWithColours();
            this.RemoveUsedColours();
            this.SetTextBox();
            this.SetSelecedColour();
            this.Delays.AddRange(this.MainRepo.ReadDelay());
            this.PopulateDelaysList();
        }

        private void PopulateDelaysList()
        {
            foreach (var item in this.Delays)
            {
                var startStationName = this.TrainLineToEdit.Stations.Where(x => x.Id == item.StartDelayStationId).FirstOrDefault()?.StationName;
                var finishStationName = this.TrainLineToEdit.Stations.Where(x => x.Id == item.EndDelayStationId).FirstOrDefault()?.StationName;
                if (startStationName != null && finishStationName != null)
                {
                    this.listView1.Items.Add(new ListViewItem(new[] { startStationName, finishStationName, item.DelayTime.ToString() }));
                }
            }
        }

        private void PopulateFirstStationComboBox()
        {
            foreach (var item in this.TrainLineToEdit.Stations)
            {
                this.DelayStartStaionComboBox.Items.Add(item.StationName);
            }
        }

        private void PopulateComboBoxWithColours()
        {
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.TrainLineColourComboBox.Items.Add(c.Name);
            }
        }

        private void SetTextBox()
        {
            this.TrainLineNameTextBox.Text = this.TrainLineToEdit.TrainLineName;
            this.TrainTravelSpeedTextBox.Text = this.TrainLineToEdit.TrainTravelSpeed.ToString();
            this.TrainDepartureTimeTextBox.Text = this.TrainLineToEdit.TrainDepartureDelay.ToString();
        }

        private void SetSelecedColour()
        {
            var selectedIndex = this.TrainLineColourComboBox.FindStringExact(this.TrainLineToEdit.TrainLineColour);
            this.TrainLineColourComboBox.SelectedIndex = selectedIndex;
        }

        private void RemoveUsedColours()
        {
            foreach (var item in this.TrainLines.Where(x => x.Id != this.TrainLineToEdit.Id))
            {
                this.RemoveColourFromComboBox(item.TrainLineColour);
            }
        }

        private void RemoveColourFromComboBox(string colourName)
        {
            this.TrainLineColourComboBox.Items.Remove(colourName);
        }

        private bool CheckIfValidInput(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        private void TrainLineColourComboBox_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5,
                                rect.Width - 10, rect.Height - 10);
            }
        }

        private void SubmitEditingsButton_Click_1(object sender, EventArgs e)
        {
            if (!this.CheckIfValidInput(this.TrainLineNameTextBox.Text) && !this.CheckIfValidInput(this.TrainLineColourComboBox.Text)
    && !this.TrainLines.Where(x => x.Id != this.TrainLineToEdit.Id).Any(x => x.TrainLineName == this.TrainLineNameTextBox.Text) && !this.TrainLines.Where(x => x.Id != this.TrainLineToEdit.Id).Any(x => x.TrainLineColour == this.TrainLineColourComboBox.Text)
    && !this.CheckIfValidInput(this.TrainTravelSpeedTextBox.Text)
    && !this.CheckIfValidInput(this.TrainDepartureTimeTextBox.Text))
            {
                this.TrainLineToEdit.TrainLineName = this.TrainLineNameTextBox.Text;
                this.TrainLineToEdit.TrainLineColour = this.TrainLineColourComboBox.Text;
                this.TrainLineToEdit.TrainTravelSpeed = long.Parse(this.TrainTravelSpeedTextBox.Text);
                this.TrainLineToEdit.TrainDepartureDelay = long.Parse(this.TrainDepartureTimeTextBox.Text);
                this.MainRepo.UpdateTrainLine(this.TrainLineToEdit);
                this.Close();
            }
        }

        private void AddDelayButton_Click(object sender, EventArgs e)
        {
            if (!this.CheckIfValidInput(this.DelayStartStaionComboBox.Text) && !this.CheckIfValidInput(this.DelayFinishComboBox.Text) && !this.CheckIfValidInput(this.DelayTimeBox.Text))
            {
                var startStation = this.TrainLineToEdit.Stations.Where(x => x.StationName == this.DelayStartStaionComboBox.Text).FirstOrDefault();
                var finishStation = this.TrainLineToEdit.Stations.Where(x => x.StationName == this.DelayFinishComboBox.Text).FirstOrDefault();
                if (startStation != null && finishStation != null)
                {
                    var delayObject = new DelayModel() { DelayTime = long.Parse(this.DelayTimeBox.Text), StartDelayStationId = startStation.Id, EndDelayStationId = finishStation.Id, TrainLineId = this.TrainLineToEdit.Id, TimeStamp = DateTime.Now.Ticks };
                    this.MainRepo.InsertDelay(delayObject);
                    this.Delays.Add(delayObject);
                    this.listView1.Items.Add(new ListViewItem(new[] { this.DelayStartStaionComboBox.Text, this.DelayFinishComboBox.Text, this.DelayTimeBox.Text }));
                    this.DelayStartStaionComboBox.Text = string.Empty;
                    this.DelayFinishComboBox.Text = string.Empty;
                    this.DelayTimeBox.Text = string.Empty;
                }
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!this.CheckIfValidInput(this.DelayStartStaionComboBox.Text))
            {
                this.DelayFinishComboBox.Items.Clear();
                var station = this.TrainLineToEdit.Stations.Where(x => x.StationName == this.DelayStartStaionComboBox.Text).FirstOrDefault();
                do
                {
                    if (station != null)
                    {
                        this.DelayFinishComboBox.Items.Add(station.StationName);
                        station = this.TrainLineToEdit.Stations.Where(x => x.Id == station.NextStationId).FirstOrDefault();
                    }
                }
                while (station != null);
            }
            else
            {
                this.DelayFinishComboBox.Items.Clear();
            }
        }

        private void RemoveDelayButton_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0)
            {
                var listItemToDelete = this.listView1.SelectedItems[0];
                var startStation = this.TrainLineToEdit.Stations.Where(x => x.StationName == listItemToDelete.SubItems[0].Text).FirstOrDefault();
                var finishStation = this.TrainLineToEdit.Stations.Where(x => x.StationName == listItemToDelete.SubItems[1].Text).FirstOrDefault();
                if (startStation != null && finishStation != null)
                {
                    var itemToDelete = this.Delays.Where(x => x.StartDelayStationId == startStation.Id && x.EndDelayStationId == finishStation.Id && x.DelayTime == long.Parse(listItemToDelete.SubItems[2].Text)).FirstOrDefault();
                    if (itemToDelete != null)
                    {
                        this.MainRepo.DeleteDelay(itemToDelete);
                        this.listView1.Items.Remove(listItemToDelete);
                        this.Delays.Remove(itemToDelete);
                    }
                }

            }
        }
    }
}
