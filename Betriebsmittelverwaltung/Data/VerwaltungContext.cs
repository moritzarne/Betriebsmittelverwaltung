using Betriebsmittelverwaltung.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betriebsmittelverwaltung.Data
{
    public class VerwaltungContext : DbContext
    {
        public VerwaltungContext(DbContextOptions<VerwaltungContext> options) : base(options)
        {

        }
        public DbSet<Auftragsverwaltung> Auftragsverwaltungs { get; set; }
        public DbSet<Baustellenverwaltung> Baustellenverwaltungs { get; set; }
        public DbSet<Bestandsverwaltung> Bestandsverwaltungs { get; set; }
        public DbSet<Nutzerverwaltung> Nutzerverwaltungs { get; set; }
        public DbSet<Projektverwaltung> Projektverwaltungs { get; set; }
        public DbSet<Retourenverwaltung> Retourenverwaltungs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auftragsverwaltung>().ToTable("Auftragsverwaltung");
            modelBuilder.Entity<Baustellenverwaltung>().ToTable("Baustellenverwaltung");
            modelBuilder.Entity<Bestandsverwaltung>().ToTable("Bestandsverwaltung");
            modelBuilder.Entity<Nutzerverwaltung>().ToTable("Nutzerverwaltung");
            modelBuilder.Entity<Projektverwaltung>().ToTable("Projektverwaltung");
            modelBuilder.Entity<Retourenverwaltung>().ToTable("Retourenverwaltung");
        }

    }
}
