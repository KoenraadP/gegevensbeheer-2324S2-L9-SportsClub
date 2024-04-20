using SportsClub.Dal;
using SportsClub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub.Bll
{
    public static class Members
    {
        // CREATE
        public static bool Create(string firstName, string lastName,
            string picture)
        {
            // spaties verwijderen uit firstname en lastname
            // de .Trim() methode verwijdert automatisch alle
            // witruimte (spaties) voor en na een opgegeven string
            firstName = firstName.Trim();
            lastName = lastName.Trim();

            // extra controle dat de strings niet leeg of null zijn
            if (!string.IsNullOrEmpty(firstName)
                && !string.IsNullOrEmpty(lastName))
            {
                // nieuwe member aanmaken met gegevens uit parameters
                Member m = new Member(firstName, lastName, picture);
                // create methode uit dal uitvoeren
                bool createSuccessful = MemberDal.Create(m);
                // true of false als return geven
                return createSuccessful;
            }

            // return als de voorgaande if niet gelukt is
            return false;
        }

        // READ ALL
        public static List<Member> Read()
        {
            // read methode uit Dal gebruiken
            List<Member> lstMembers = MemberDal.Read();
            return lstMembers;
        }

        // READ SINGLE
        public static Member Read(int id)
        {
            // member opzoeken met dal methode
            Member m = MemberDal.Read(id);

            // als member niet bestaat (null) dan blanco member aanmaken
            if (m == null)
            {
                m = new Member();
            }

            // member als return geven
            return m;
        }

        // UPDATE
        public static bool Update(int memberId,
            string firstName, string lastName)
        {
            // member opzoeken via id
            Member m = MemberDal.Read(memberId);

            // eventuele spaties verwijderen bij de namen
            firstName = firstName.Trim();
            lastName = lastName.Trim();

            // extra controle om zeker te zijn dat
            // er effectief namen doorgegeven worden
            if (!string.IsNullOrEmpty(firstName)
                && !string.IsNullOrEmpty(lastName))
            {
                // namen van member aanpassen naar nieuwe
                m.FirstName = firstName;
                m.LastName = lastName;
            }

            // dal methode gebruiken om member in db
            // te gaan updaten, tegelijk ook false of
            // true hier uit halen en als return gebruiken
            return MemberDal.Update(m);
        }

        // DELETE
        public static bool Delete(int id)
        {
            // member opzoeken met id
            Member m = MemberDal.Read(id);
            // delete methode uit dal uitvoeren
            return MemberDal.Delete(m);
        }
    }
}
