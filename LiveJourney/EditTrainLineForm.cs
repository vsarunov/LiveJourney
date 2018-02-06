﻿using DataAccess.Repository;
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

        public EditTrainLineForm(TrainLine trainLineToEdit, IEnumerable<TrainLine> trainLinesToCheck, IMainRepository mainRepo)
        {
            InitializeComponent();
            this.MainRepo = mainRepo;
            this.TrainLines = trainLinesToCheck;
            this.TrainLineToEdit = trainLineToEdit;
            this.PopulateComboBoxWithColours();
            this.RemoveUsedColours();
            this.SetTextBox();
            this.SetSelecedColour();
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

        private void SetTextBox()
        {
            this.TrainLineNameTextBox.Text = this.TrainLineToEdit.TrainLineName;
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

        private void SubmitEditingsButton_Click(object sender, EventArgs e)
        {
            if (!this.CheckIfValidInput(this.TrainLineNameTextBox.Text) && !this.CheckIfValidInput(this.TrainLineColourComboBox.Text)
                && !this.TrainLines.Where(x => x.Id != this.TrainLineToEdit.Id).Any(x => x.TrainLineName == this.TrainLineNameTextBox.Text) && !this.TrainLines.Where(x => x.Id != this.TrainLineToEdit.Id).Any(x => x.TrainLineColour == this.TrainLineColourComboBox.Text))
            {
                this.TrainLineToEdit.TrainLineName = this.TrainLineNameTextBox.Text;
                this.TrainLineToEdit.TrainLineColour = this.TrainLineColourComboBox.Text;
                this.MainRepo.UpdateTrainLine(this.TrainLineToEdit);
                this.Close();
            }
        }

        private bool CheckIfValidInput(string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }
    }
}