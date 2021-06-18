using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betriebsmittelverwaltung.Models
{
    public enum Rolle
    {
        Bauleiter,
        Admin,
        Lagerist
    }
    public class Nutzerverwaltung
    {
   

        public int ID { get; set; }
        public Rolle Rolle { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }

    }
}
