using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub.Entities
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        [Required(ErrorMessage = "Naam mag niet leeg zijn.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Naam activiteit tussen {2} en {1} karakters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Maxparticipants mag niet leeg zijn.")]
        [Range(6, 30, ErrorMessage = "Waarde moet tussen {1} en {2} liggen.")]
        public int MaxParticipants { get; set; }

        // link met member
        public List<Member> Members { get; set; }

        public Activity(string name, int maxParticipants)
        {
            Name = name;
            MaxParticipants = maxParticipants;
            // list initialiseren
            Members = new List<Member>();
        }

        public Activity()
        {
            
        }
    }
}
