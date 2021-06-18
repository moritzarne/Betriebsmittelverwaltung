using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betriebsmittelverwaltung.Models
{
    public class Retourenverwaltung
    {
        public int ID { get; set; }
        public string Typ { get; set; }
        public DateTime Kaufdatum { get; set; }
        public TimeSpan Wartungsintverall { get; set; }
        public bool Verfügbar { get; set; }
    }
}
