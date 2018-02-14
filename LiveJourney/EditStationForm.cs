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
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class EditStationForm : Form
    {
        private readonly IMainRepository MainRepo;
        private readonly IEnumerable<Station> Stations;
        private readonly Station StationToEdit;

        public EditStationForm(Station stationToEdit, IEnumerable<Station> StationsToCheck, IMainRepository mainRepo)
        {
            InitializeComponent();
            this.MainRepo = mainRepo;
            this.Stations = StationsToCheck;
            this.StationToEdit = stationToEdit;
            this.StationNameTextBox.Text = this.StationToEdit.StationName;
            this.MyUniqueTextBox.Text = this.StationToEdit.DistanceToPreviousStation.ToString();
        }

        private void SubmitChangesButton_Click(object sender, EventArgs e)
        {
            if (!this.CheckIfValidInput(this.StationNameTextBox.Text) && !Stations.Where(x => x.Id != this.StationToEdit.Id).Any(x => x.StationName == this.StationNameTextBox.Text))
            {
                var distanceValue = double.Parse(this.MyUniqueTextBox.Text);
                if ((Stations.Any(x => x.NextStationId == StationToEdit.Id) && distanceValue == 0))
                {
                    MessageBox.Show("Distance cannot be 0");
                }
                else if (StationToEdit.PreviousStationId == -1 && distanceValue > 0)
                {
                    MessageBox.Show("Distance cannot be bigger than 0");
                }
                else
                {
                    StationToEdit.StationName = this.StationNameTextBox.Text;
                    StationToEdit.DistanceToPreviousStation = distanceValue;
                    this.MainRepo.UpdateStation(StationToEdit);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Such station name already exists on this train line");
            }
        }

        private bool CheckIfValidInput(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }
    }
}
