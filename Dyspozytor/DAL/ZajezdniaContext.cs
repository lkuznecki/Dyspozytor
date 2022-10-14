using Dyspozytor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Dyspozytor.DAL
{
    public class ZajezdniaContext : DbContext
    {
        public ZajezdniaContext() : base("ZajezdniaContext")
        {

        }
        public DbSet<Kierowca> Kierowcy { get; set; }
        public DbSet<Zlecenie> Zlecenia { get; set; }
        public DbSet<Pojazd> Pojazdy { get; set; }

        // Zapobieganie pluralizmu nazw tabel
        //Konwencja, aby ustawić nazwę tabeli jako liczbę w liczbie mnogiej nazwy typu jednostki.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}