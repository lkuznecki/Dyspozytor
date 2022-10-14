using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dyspozytor.Models
{
    public class Pojazd
    {
        // umożliwia wprowadzenie klucza podstawowego dla pojazdu, a nie jego wygenerowanie.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PojazdID { get; set; }
        public string Nazwa_Pojazdu { get; set; }

        public int Pojemnosc { get; set; }

        public virtual ICollection<Zlecenie> Zlecenia { get; set; }
    }
}