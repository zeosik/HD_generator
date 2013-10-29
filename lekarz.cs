using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections;

namespace pt_lab3_6
{
    [Serializable]
    public class lekarz
    {
        [XmlIgnore]
        Random rnd;
        public string imie;
        public string nazwisko;
        public string specjalizacja;
        public lekarz() { }
        public lekarz(List<ArrayList> imionaNazwiska, Random rand)
        {
            rnd = rand;
            if (rnd.Next(2) == 1)//mezczyzna
            {
                imie = randomImie(imionaNazwiska[0]);
                nazwisko = randomNazwisko(imionaNazwiska[2]);
            }
            else//kobieta
            {
                imie = randomImie(imionaNazwiska[1]);
                nazwisko = randomNazwisko(imionaNazwiska[3]);
            }
            specjalizacja = randomSpecjalizacja();
        }
        public string randomImie(ArrayList imiona)
        {
            string imie = imiona[rnd.Next(imiona.Count)].ToString();
            return imie;
        }
        public string randomNazwisko(ArrayList nazwiska)
        {
            string nazwisko = nazwiska[rnd.Next(nazwiska.Count)].ToString();
            return nazwisko;
        }
        public string randomSpecjalizacja()
        {
            if (rnd.Next(2) == 1)
                return "rodzinny";
            else
                return "okulista";
        }
    }
}
