﻿// <auto-generated />
using System;
using Betriebsmittelverwaltung.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Betriebsmittelverwaltung.Migrations
{
    [DbContext(typeof(VerwaltungContext))]
    [Migration("20210618102556_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Betriebsmittelverwaltung.Models.Auftragsverwaltung", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BauleiterID")
                        .HasColumnType("int");

                    b.Property<int?>("BestandsverwaltungID")
                        .HasColumnType("int");

                    b.Property<int?>("ProjektIDID")
                        .HasColumnType("int");

                    b.Property<string>("Typ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Verfügbar")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("BauleiterID");

                    b.HasIndex("BestandsverwaltungID");

                    b.HasIndex("ProjektIDID");

                    b.ToTable("Auftragsverwaltung");
                });

            modelBuilder.Entity("Betriebsmittelverwaltung.Models.Baustellenverwaltung", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BauleiterID")
                        .HasColumnType("int");

                    b.Property<string>("Beschreibung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BauleiterID");

                    b.ToTable("Baustellenverwaltung");
                });

            modelBuilder.Entity("Betriebsmittelverwaltung.Models.Bestandsverwaltung", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Kaufdatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Typ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Verfübar")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("Wartungsintervall")
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.ToTable("Bestandsverwaltung");
                });

            modelBuilder.Entity("Betriebsmittelverwaltung.Models.Nutzerverwaltung", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nachname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rolle")
                        .HasColumnType("int");

                    b.Property<string>("Vorname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Nutzerverwaltung");
                });

            modelBuilder.Entity("Betriebsmittelverwaltung.Models.Projektverwaltung", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Ausleihdatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BaustellenverwaltungID")
                        .HasColumnType("int");

                    b.Property<string>("Rückgabe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Typ")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BaustellenverwaltungID");

                    b.ToTable("Projektverwaltung");
                });

            modelBuilder.Entity("Betriebsmittelverwaltung.Models.Retourenverwaltung", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BestandsverwaltungID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Kaufdatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProjektverwaltungID")
                        .HasColumnType("int");

                    b.Property<string>("Typ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Verfügbar")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("Wartungsintverall")
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.HasIndex("BestandsverwaltungID");

                    b.HasIndex("ProjektverwaltungID");

                    b.ToTable("Retourenverwaltung");
                });

            modelBuilder.Entity("Betriebsmittelverwaltung.Models.Auftragsverwaltung", b =>
                {
                    b.HasOne("Betriebsmittelverwaltung.Models.Nutzerverwaltung", "Bauleiter")
                        .WithMany()
                        .HasForeignKey("BauleiterID");

                    b.HasOne("Betriebsmittelverwaltung.Models.Bestandsverwaltung", null)
                        .WithMany("Auftragsverwaltungs")
                        .HasForeignKey("BestandsverwaltungID");

                    b.HasOne("Betriebsmittelverwaltung.Models.Projektverwaltung", "ProjektID")
                        .WithMany("Auftragsverwaltungs")
                        .HasForeignKey("ProjektIDID");
                });

            modelBuilder.Entity("Betriebsmittelverwaltung.Models.Baustellenverwaltung", b =>
                {
                    b.HasOne("Betriebsmittelverwaltung.Models.Nutzerverwaltung", "Bauleiter")
                        .WithMany()
                        .HasForeignKey("BauleiterID");
                });

            modelBuilder.Entity("Betriebsmittelverwaltung.Models.Projektverwaltung", b =>
                {
                    b.HasOne("Betriebsmittelverwaltung.Models.Baustellenverwaltung", null)
                        .WithMany("Projektverwaltungs")
                        .HasForeignKey("BaustellenverwaltungID");
                });

            modelBuilder.Entity("Betriebsmittelverwaltung.Models.Retourenverwaltung", b =>
                {
                    b.HasOne("Betriebsmittelverwaltung.Models.Bestandsverwaltung", null)
                        .WithMany("Retourenverwaltungs")
                        .HasForeignKey("BestandsverwaltungID");

                    b.HasOne("Betriebsmittelverwaltung.Models.Projektverwaltung", null)
                        .WithMany("Retourenverwaltungs")
                        .HasForeignKey("ProjektverwaltungID");
                });
#pragma warning restore 612, 618
        }
    }
}
