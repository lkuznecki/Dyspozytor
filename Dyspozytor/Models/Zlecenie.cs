using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dyspozytor.Models
{
    public enum Wtrasie
    {
        Tak,Nie
    }
    // Właściwość nawigacji
    public class Zlecenie
    {
        public int ZlecenieID { get; set; } //Klucz podstawowy
        public int PojazdID { get; set; }
        public int KierowcaID { get; set; }

        public DateTime Godz_Rozp { get;set; }
        public string Zleceniodawca { get; set; }
        public DateTime Godz_zakoncz { get; set; }

        public Wtrasie? Wtrasie { get; set; }
        public virtual Pojazd Pojazd { get; set; } //właściwość nawigacji
        public virtual Kierowca Kierowca { get; set; }
        

    }
}