using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Betriebsmittelverwaltung.Models
{
    public class Auftragsverwaltung
    {
        public int ID { get; set; }
        public string Typ { get; set; }
        public Projektverwaltung ProjektID { get; set; }
        public Nutzerverwaltung Bauleiter { get; set; }
        public bool Verfügbar { get; set; }
    }
}
