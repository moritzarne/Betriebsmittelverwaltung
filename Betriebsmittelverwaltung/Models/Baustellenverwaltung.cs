using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betriebsmittelverwaltung.Models
{
    public class Baustellenverwaltung
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public Nutzerverwaltung Bauleiter { get; set; }
        public ICollection<Projektverwaltung> Projektverwaltungs { get; set; }
    }
}
