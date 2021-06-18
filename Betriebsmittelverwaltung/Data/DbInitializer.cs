using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Betriebsmittelverwaltung.Models;

namespace Betriebsmittelverwaltung.Data
{
    public class DbInitializer
    {
        public static void Initialize(VerwaltungContext context)
        {
            context.Database.EnsureCreated();

            if (context.Bestandsverwaltungs.Any())
            {
                return;
            }
            var av = new Auftragsverwaltung[]
            {
                new Auftragsverwaltung{Typ = "Kran", Verfügbar = true, Bauleiter = null} //Bauleiter fehlt noch
            };
            foreach(Auftragsverwaltung a in av)
            {
                context.Auftragsverwaltungs.Add(a);
            }
            context.SaveChanges();

            var bv = new Baustellenverwaltung[]
            {
                new Baustellenverwaltung{Name = "Turnhalle", Beschreibung = "Turnhalle für die Mustermann Schule", Bauleiter=null }
            };
            foreach(Baustellenverwaltung b in bv)
            {
                context.Baustellenverwaltungs.Add(b);
            }
            context.SaveChanges();



            var bestverw = new Bestandsverwaltung[]
            {
                new Bestandsverwaltung{Typ="Akkuschrauber", Kaufdatum = DateTime.Parse("2021-04-03"), Wartungsintervall = TimeSpan.Parse("6 Monate"), Verfübar = true}
            };
            foreach(Bestandsverwaltung b in bestverw)
            {
                context.Bestandsverwaltungs.Add(b);
            } 
            context.SaveChanges();

            var nv = new Nutzerverwaltung[]
            {
                new Nutzerverwaltung{Vorname = "Achim", Nachname = "Müller", Rolle = Rolle.Admin}
            };
            foreach(Nutzerverwaltung n in nv){
                context.Nutzerverwaltungs.Add(n);
            }
            context.SaveChanges();

            var pv = new Projektverwaltung[]
            {
                new Projektverwaltung{Typ = "Kran", Ausleihdatum = DateTime.Parse("2021-02-02")}
            };
            foreach(Projektverwaltung p in pv)
            {
                context.Projektverwaltungs.Add(p);
            }
            context.SaveChanges();

            var rv = new Retourenverwaltung[]
            {
                new Retourenverwaltung{Typ = "Akkuschrauber", Kaufdatum = DateTime.Parse("2021-05-05"), Wartungsintverall = TimeSpan.Parse("6 Monate"), Verfügbar=true}
            };
            foreach(Retourenverwaltung r in rv)
            {
                context.Retourenverwaltungs.Add(r);
            }
            context.SaveChanges();
        


        }
    }
}
