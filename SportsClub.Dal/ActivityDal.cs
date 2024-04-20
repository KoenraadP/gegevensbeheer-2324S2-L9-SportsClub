using SportsClub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub.Dal
{
    public static class ActivityDal
    {
        // CREATE
        public static bool Create(Activity a)
        {
            using (var db = new SportsClubDbContext())
            {
                try
                {
                    db.Activities.Add(a);
                    return db.SaveChanges() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        // READ ALL
        public static List<Activity> Read()
        {
            // verbinding met databank maken
            using (var db = new SportsClubDbContext())
            {
                // lijst van members uit db halen
                List<Activity> lstActivities = db.Activities.ToList();
                return lstActivities;
            }
        }

        // READ SINGLE
        public static Activity Read(int id)
        {
            // verbinding met databank maken
            using (var db = new SportsClubDbContext())
            {
                // record van member opzoeken op basis van id
                Activity a = db.Activities.Find(id);
                // member als return waarde geven
                return a;
            }
        }

        // UPDATE

        // DELETE
    }
}
