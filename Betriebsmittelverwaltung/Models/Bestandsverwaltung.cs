using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betriebsmittelverwaltung.Models
{
    public class Bestandsverwaltung
    {
        public int ID { get; set; }
        public string Typ { get; set; } //eventuell ein Enum besser, sonst könnte man alles angeben
        public DateTime Kaufdatum { get; set; }

        public TimeSpan Wartungsintervall { get; set; }

        public bool Verfübar { get; set; }

        public ICollection<Auftragsverwaltung> Auftragsverwaltungs {get; set;}
        public ICollection<Retourenverwaltung> Retourenverwaltungs { get; set; }


    }
}
