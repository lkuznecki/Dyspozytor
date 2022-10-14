using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dyspozytor.Models
{
    public class Kierowca
    {
        public int ID { get; set; }
        public string Nazwisko { get; set; }

        public string Imie { get; set; }

        public DateTime Rozpocz_Pracy { get; set; }


        public virtual ICollection<Zlecenie> Zlecenia { get; set; }
    }
}