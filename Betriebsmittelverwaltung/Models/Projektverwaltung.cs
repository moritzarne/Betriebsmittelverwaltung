using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betriebsmittelverwaltung.Models
{
    public class Projektverwaltung
    {
        public int ID { get; set; }
        public string Typ { get; set; }
        public DateTime Ausleihdatum {get; set;}
        public string Rückgabe { get; set; } //string ist (glaube ich) nicht der richtige Datentyp, wollte nur das die Datenbank erstmal steht
        public ICollection<Auftragsverwaltung> Auftragsverwaltungs { get; set; }
        public ICollection<Retourenverwaltung> Retourenverwaltungs { get; set; }
    }
}
