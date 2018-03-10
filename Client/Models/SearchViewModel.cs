using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Models
{
    public class SearchViewModel
    {

        [Required]
        [Display(Name = "Start Station")]
        public string StartStation { get; set; }

        [Required]
        [Display(Name = "Destination Station")]
        public string DestinationStation { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime Time { get; set; }

        public string Result { get; set; } = null;

        public IEnumerable<SelectListItem> Stations { get; set; }
        public List<TrainLine> TrainLines { get; set; }
    }
}