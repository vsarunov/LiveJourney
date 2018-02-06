namespace LiveJourney
{
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

    public partial class ManagementForm : Form
    {
        private readonly IMainRepository MainRepo;
        private readonly List<TrainLine> TrainLines = new List<TrainLine>();


        public ManagementForm(IMainRepository mainRepo)
        {
            this.MainRepo = mainRepo;
            InitializeComponent();
            this.PopulateComboBoxWithColours();
            this.PopulateTrainLines();
            this.PopulateTrainLineListView();
        }

        private void AddTrainLineButton_Click(object sender, EventArgs e)
        {
            if (!this.CheckIfValidInput(this.TrainLineNameTextBox.Text) && !this.CheckIfValidInput(this.TrainLineColourComboBox.Text) && !TrainLines.Any(x => x.TrainLineName == this.TrainLineNameTextBox.Text))
            {
                var listViewItem = new ListViewItem(new[] { this.TrainLineNameTextBox.Text, this.TrainLineColourComboBox.Text });
                Color colour = Color.FromName(this.TrainLineColourComboBox.Text);
                listViewItem.ForeColor = colour;
                this.TrainLineListView.Items.Add(listViewItem);
                var newTrainLine = new TrainLine() { TrainLineName = this.TrainLineNameTextBox.Text, TrainLineColour = this.TrainLineColourComboBox.Text };
                this.RemoveColourFromComboBox(this.TrainLineColourComboBox.Text);
                this.TrainLineNameTextBox.Text = string.Empty;
                this.TrainLineColourComboBox.Text = string.Empty;
                var trainLineId = this.MainRepo.InsertTrainline(newTrainLine);
                newTrainLine.Id = trainLineId;
                TrainLines.Add(newTrainLine);
            }
        }

        private void PopulateTrainLines()
        {
            var TrainLineReadResult = this.MainRepo.ReadTrainLines();
            this.TrainLines.AddRange(TrainLineReadResult);
        }

        private void PopulateTrainLineListView()
        {
            this.TrainLineListView.Items.Clear();
            foreach (var item in TrainLines)
            {
                var listViewItem = new ListViewItem(new[] { item.TrainLineName, item.TrainLineColour });
                Color colour = Color.FromName(item.TrainLineColour);
                listViewItem.ForeColor = colour;
                this.TrainLineListView.Items.Add(listViewItem);
                this.RemoveColourFromComboBox(item.TrainLineColour);
            }

            if (this.TrainLineListView.Items.Count != 0)
                this.TrainLineListView.Items[0].Selected = true;
        }

        private void RemoveColourFromComboBox(string colourName)
        {
            this.TrainLineColourComboBox.Items.Remove(colourName);
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

        private bool CheckIfValidInput(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        private void TrainLineColourComboBox_DrawItem(object sender, DrawItemEventArgs e)
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

        private void ManagementForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void DeleteTrainLineButton_Click(object sender, EventArgs e)
        {
            if (this.TrainLineListView.SelectedItems.Count != 0)
            {
                var itemToRemove = this.TrainLines.Where(x => x.TrainLineName == this.TrainLineListView.SelectedItems[0].SubItems[0].Text).FirstOrDefault();
                if (itemToRemove != null)
                {
                    this.TrainLineListView.Items.Remove(this.TrainLineListView.SelectedItems[0]);
                    this.TrainLines.Remove(itemToRemove);
                    this.MainRepo.DeleteTrainLine(itemToRemove);
                }
            }
        }

        private void TrainLineListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (this.TrainLineListView.SelectedItems.Count != 0)
            {
                var trainLine = this.TrainLines.Where(x => x.TrainLineName == this.TrainLineListView.SelectedItems[0].SubItems[0].Text).FirstOrDefault();
                if (trainLine != null)
                {
                    this.TurnFieldOnOf(true);
                    this.PopulateStations(trainLine);
                }
            }
            else
            {
                this.TurnFieldOnOf(false);
                this.StationListView.Items.Clear();
            }
        }

        private void PopulateStations(TrainLine trainLine)
        {
            foreach (var item in trainLine.Stations)
            {
                var listViewItem = new ListViewItem(new[] { item.StationName, item.DistanceToPreviousStation.ToString(), item.Id.ToString() });
                this.StationListView.Items.Add(listViewItem);
            }
        }

        private void TurnFieldOnOf(bool value)
        {
            StationListView.Enabled = value;
            StationNameTextBox.Enabled = value;
            MyUniqueTextBox.Enabled = value;
            AddStationButton.Enabled = value;
            DeleteStationButton.Enabled = value;
            EditStationButton.Enabled = value;
        }

        private void EditTrainLineButton_Click(object sender, EventArgs e)
        {
            if (this.TrainLineListView.SelectedItems.Count != 0)
            {
                var trainLine = this.TrainLines.Where(x => x.TrainLineName == this.TrainLineListView.SelectedItems[0].SubItems[0].Text).FirstOrDefault();
                if (trainLine != null)
                {
                    new EditTrainLineForm(trainLine, this.TrainLines, this.MainRepo).ShowDialog();
                    this.PopulateTrainLineListView();
                }
            }
        }

        private void AddStationButton_Click(object sender, EventArgs e)
        {
            if (this.TrainLineListView.SelectedItems.Count != 0)
            {
                var trainLine = this.TrainLines.Where(x => x.TrainLineName == this.TrainLineListView.SelectedItems[0].SubItems[0].Text).FirstOrDefault();
                if (trainLine != null)
                {
                    if (!this.CheckIfValidInput(this.StationNameTextBox.Text) && !this.CheckIfValidInput(this.MyUniqueTextBox.Text))
                    {
                        var previousStation = trainLine.Stations.Where(x => x.NextStationId == -1).FirstOrDefault();
                        var newStation = new Station()
                        {
                            TrainLineId = trainLine.Id,
                            StationName = this.StationNameTextBox.Text,
                            DistanceToPreviousStation = double.Parse(this.MyUniqueTextBox.Text),
                            PreviousStationId = previousStation == null ? -1 : previousStation.Id
                        };
                        var returnedId = this.MainRepo.InsertStation(newStation);
                        newStation.Id = returnedId;
                        if (previousStation != null)
                        {
                            previousStation.NextStationId = returnedId;
                            this.MainRepo.UpdateStation(previousStation);
                        }

                        this.StationNameTextBox.Text = string.Empty;
                        this.MyUniqueTextBox.Text = string.Empty;

                        trainLine.Stations.Add(newStation);
                        this.PopulateStationListView(trainLine);
                    }
                }
            }
        }

        private void PopulateStationListView(TrainLine trainLine)
        {
            this.StationListView.Items.Clear();
            foreach (var item in trainLine.Stations)
            {
                this.StationListView.Items.Add(new ListViewItem(new[] { item.StationName, item.DistanceToPreviousStation.ToString(), item.Id.ToString() }));
            }
        }
    }
}
