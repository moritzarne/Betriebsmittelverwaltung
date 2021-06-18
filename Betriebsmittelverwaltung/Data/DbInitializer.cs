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
        }
    }
}
