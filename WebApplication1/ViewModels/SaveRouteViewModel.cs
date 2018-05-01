using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class SaveRouteViewModel
    {
        [Required(ErrorMessage = "Must choose Route Name.")]
        [Display(Name = "Route Name:")]
        public string RouteName { get; set; }

        [Required(ErrorMessage = "Must enter Route Origin.")]
        [Display(Name = "Starting Point:")]
        public string Origin { get; set; }

        // TODO - Make sure Passwords get hashed.
        [Required(ErrorMessage = "Must enter Destination.")]
        [Display(Name = "Destination:")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Please Enter a Review.")]
        [Display(Name = "Please Leave A Review:")]
        public string Review { get; set; }

        [Display(Name = "Turn 1")]
        public string Waypoint1 { get; set; }
        [Display(Name = "Turn 2")]
        public string Waypoint2 { get; set; }
        [Display(Name = "Turn 3")]
        public string Waypoint3 { get; set; }
        [Display(Name = "Turn 4")]
        public string Waypoint4 { get; set; }
        [Display(Name = "Turn 5")]
        public string Waypoint5 { get; set; }
        [Display(Name = "Turn 6")]
        public string Waypoint6 { get; set; }
        [Display(Name = "Turn 7")]
        public string Waypoint7 { get; set; }
        [Display(Name = "Turn 8")]
        public string Waypoint8 { get; set; }
        [Display(Name = "Turn 9")]
        public string Waypoint9 { get; set; }
        [Display(Name = "Turn 10")]
        public string Waypoint10 { get; set; }
        [Display(Name = "Turn 11")]
        public string Waypoint11 { get; set; }
        [Display(Name = "Turn 12")]
        public string Waypoint12 { get; set; }
        [Display(Name = "Turn 13")]
        public string Waypoint13 { get; set; }
        [Display(Name = "Turn 14")]
        public string Waypoint14 { get; set; }
        [Display(Name = "Turn 15")]
        public string Waypoint15 { get; set; }
        [Display(Name = "Turn 16")]
        public string Waypoint16 { get; set; }
        [Display(Name = "Turn 17")]
        public string Waypoint17 { get; set; }
        [Display(Name = "Turn 18")]
        public string Waypoint18 { get; set; }
        [Display(Name = "Turn 19")]
        public string Waypoint19 { get; set; }
        [Display(Name = "Turn 20")]
        public string Waypoint20 { get; set; }

        // TODO - Need this "default constructor" for methods later...? look into.
        public SaveRouteViewModel()
        {
        }
    }
}
