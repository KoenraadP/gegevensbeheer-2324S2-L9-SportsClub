using SportsClub.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub.Dal
{
    // door static toe te voegen kunnen we deze class
    // gebruiken zonder new ...() te moeten typen
    // zorgt ook voor minder memory usage
    // als de class static is, moeten alle methodes erin
    // OOK static zijn
    public static class MemberDal
    {
        // CREATE
        public static bool Create(Member m)
        {
            using (var db = new SportsClubDbContext())
            {
                try
                {
                    // m toevoegen aan databank (klaarzetten)
                    db.Members.Add(m);
                    // verandering effectief doorvoeren in db
                    // aantal wijzigingen opslaan in variabele
                    int numberOfChanges = db.SaveChanges();
                    // als er meer dan 0 wijzigingen zijn, dan is het gelukt
                    if (numberOfChanges > 0)
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }

                return false;
            }
        }

        // READ ALL
        public static List<Member> Read()
        {
            // verbinding met databank maken
            using (var db = new SportsClubDbContext())
            {
                // lijst van members uit db halen
                // select * from...
                List<Member> lstMembers = db.Members.ToList();
                return lstMembers;
            }
        }

        // READ SINGLE
        public static Member Read(int id)
        {
            // verbinding met databank maken
            using (var db = new SportsClubDbContext())
            {
                // record van member opzoeken op basis van id
                Member m = db.Members.Find(id);
                // member als return waarde geven
                return m;
            }
        }

        // UPDATE
        // updatedMember komt binnen via bll
        // dit is de aangepaste member, die nog niet
        // in de databank zit
        public static bool Update(Member updatedMember)
        {
            using (var db = new SportsClubDbContext())
            {
                // probeer member te updaten
                try
                {
                    // update member in database
                    // via updatedMember weet EF het id
                    db.Members.AddOrUpdate(updatedMember);
                    // db wijzigingen effectief doorvoeren
                    // en checken of dit gelukt is
                    return db.SaveChanges() > 0;
                }
                catch
                {
                    // niet gelukt om member te updaten?
                    return false;
                }
            }
        }

        // DELETE
        public static bool Delete(Member m)
        {
            using (var db = new SportsClubDbContext())
            {
                // aanduiden welke member weg moet uit db
                db.Entry(m).State = EntityState.Deleted;
                // wijziging in db effectief uitvoeren
                // return als eindresultaat van methode gebruiken
                return db.SaveChanges() > 0;
            }
        }
    }
}
