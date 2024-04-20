using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsClub.Entities
{
    // sjabloon voor Members table in db
    public class Member
    {
        // memberid --> primary key voor databank
        // [Key] om aan te duiden dat dit de PK is
        [Key]
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Voornaam mag niet leeg zijn.")]
        [StringLength(20,MinimumLength = 2, 
            ErrorMessage = "Lengte voornaam tussen {2} en {1}.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Achternaam mag niet leeg zijn.")]
        public string LastName { get; set; }
        // de picture property zal de bestandsnaam
        // van de foto bevatten
        public string Picture { get; set; }

        // property die link legt met Activity
        // een member kan zich inschrijven voor meerdere activities --> list
        public List<Activity> Activities { get; set; }

        // constructor om te zorgen dat Members altijd met een
        // voornaam en achternaam aangemaakt worden
        public Member(string firstName, string lastName, string picture)
        {
            FirstName = firstName;
            LastName = lastName;
            Picture = picture;
            // lege list initialiseren
            Activities = new List<Activity>();
        }

        public Member()
        {
            
        }
    }
}
