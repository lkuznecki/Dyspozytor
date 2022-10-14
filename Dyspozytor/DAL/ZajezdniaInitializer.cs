using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dyspozytor.Models;
using System.Data.Entity;

namespace Dyspozytor.DAL
{
    public class ZajezdniaInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<ZajezdniaContext>
    {
        protected override void Seed(ZajezdniaContext context)
        {
            var kierowcy = new List<Kierowca>
            {
                new Kierowca{Imie="Tomasz",Nazwisko="Janusz",Rozpocz_Pracy=DateTime.Parse("2015-06-25")},
                new Kierowca{Imie="Miroslaw",Nazwisko="Nowak",Rozpocz_Pracy=DateTime.Parse("2016-05-25")},
                new Kierowca{Imie="Eryk",Nazwisko="Kowalski",Rozpocz_Pracy=DateTime.Parse("2017-08-25")},
                new Kierowca{Imie="Mateusz",Nazwisko="Wójcik",Rozpocz_Pracy=DateTime.Parse("2018-11-25")},
                new Kierowca{Imie="Łukasz",Nazwisko="Lewandowski",Rozpocz_Pracy=DateTime.Parse("2019-12-25")},
                new Kierowca{Imie="Wiktor",Nazwisko="Mazur",Rozpocz_Pracy=DateTime.Parse("2020-09-25")},
                new Kierowca{Imie="Piotr",Nazwisko="Alzur",Rozpocz_Pracy=DateTime.Parse("2021-06-25")}
            };

            kierowcy.ForEach(s => context.Kierowcy.Add(s));
            context.SaveChanges();
            var pojazdy = new List<Pojazd>
            {
                new Pojazd{PojazdID=773150,Nazwa_Pojazdu="Skoda",Pojemnosc=1000},
                new Pojazd{PojazdID=723551,Nazwa_Pojazdu="Dacia",Pojemnosc=1300},
                new Pojazd{PojazdID=133562,Nazwa_Pojazdu="Fiat",Pojemnosc=1350},
                new Pojazd{PojazdID=663321,Nazwa_Pojazdu="Ford",Pojemnosc=1250},
                new Pojazd{PojazdID=775123,Nazwa_Pojazdu="Mercedes",Pojemnosc=1500}
            };
            pojazdy.ForEach(s => context.Pojazdy.Add(s));
            context.SaveChanges();
            var zlecenia = new List<Zlecenie>
            {

            };
            zlecenia.ForEach(s => context.Zlecenia.Add(s));
            context.SaveChanges();
           
        }
    }
}