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

        public IEnumerable<SelectListItem> Stations { get; set; }
    }
}