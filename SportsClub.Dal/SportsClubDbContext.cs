using SportsClub.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub.Dal
{
    // overerven van DbContext class
    // om alles te kunnen gebruiken uit die class
    internal class SportsClubDbContext : DbContext
    {
        // verbinding leggen met onze SQLEXPRESS server
        // hierin wordt onze databank dan gemaakt
        // de naam van de databank = wat je invult bij de Initial Catalog
        // maak je oefeningen of andere projecten, gewoon copy paste
        // en aanpassen van de Initial Catalog
        public SportsClubDbContext() : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=SportsClubDb;Integrated Security=True")
        {
            
        }

        // properties voorzien die verwijzen naar de aparte tabellen
        // iedere property zal normaal één tabel genereren
        public DbSet<Member> Members { get; set; }
        public DbSet<Activity> Activities { get; set; }

        // commando's om zaken in de db aan te passen
        // niet vergeten: Default project aanpassen naar Dal

        // Stap 1: Migraties inschakelen --> dit moet je slechts één keer doen
        // EntityFramework6\Enable-Migrations

        // Stap 2: Voeg een migratie toe --> elke keer je iets verandert aan je Entities classes
        // EntityFramework6\Add-Migration naam

        // Stap 3: Update de database --> altijd nadat je eerst Add-Migration (stap 2) gedaan hebt
        // EntityFramework6\Update-Database
    }
}
