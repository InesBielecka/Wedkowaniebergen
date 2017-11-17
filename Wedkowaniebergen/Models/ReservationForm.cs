using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wedkowaniebergen.Models
{
    public class ReservationForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Comments { get; set; }
        [Required]
        public string LastName { get; set; }
        public bool Trolltunga { get; set; }
        public bool Flam { get; set; }
        public bool Floyen { get; set; }
        public bool Ulriken { get; set; }
        public bool PływanieŁodzią { get; set; }
        public bool Nocleg { get; set; }
        public bool TransportLotnisko { get; set; }
        public bool Lodowiec { get; set; }
        public bool ZwiedzanieBergen { get; set; }
        public bool Wodospady { get; set; }
    }
}