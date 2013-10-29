using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml.XPath;
using System.Configuration;
using System.Collections.Specialized;

namespace pt_lab3_6
{
    [Serializable]
    public class pracownik
    {
        //[XmlText]
        //[XmlElement ("innanazwa2")]
        //[XmlIgnore]
        //[XmlAttribute("innanazwacena")]
        [XmlIgnore]
        public Random rnd;
        public string imie;
        public string nazwisko;
        public string pesel;
        public List<Data> daty;
        /*public class sortNazwa : IComparer<pracownik>
        {
            public int Compare(pracownik a, pracownik b)
            {
                //return a.nazwa.CompareTo(b.nazwa);
                if (string.Compare(a.nazwa, b.nazwa) == -1)
                    return 1;
                else if (string.Compare(a.nazwa, b.nazwa) == 1)
                    return -1;
                else
                {
                    if (a.ludnosc > b.ludnosc)
                        return -1;
                    else if (a.ludnosc < b.ludnosc)
                        return 1;
                    else
                        return 0;
                }
            }
        }*/
        public pracownik() { }
        public pracownik(List<ArrayList> imionaNazwiska, Random rand)
        {
            rnd = rand;
            if (rnd.Next(2) == 1)//mezczyzna
            {
                imie = randomImie(imionaNazwiska[0]);
                nazwisko = randomNazwisko(imionaNazwiska[2]);
                pesel = randomPesel(2);
            }
            else//kobieta
            {
                imie = randomImie(imionaNazwiska[1]);
                nazwisko = randomNazwisko(imionaNazwiska[3]);
                pesel = randomPesel(1);
            }
            daty = new List<Data>();

            int miesiecy = rnd.Next(int.Parse(ConfigurationManager.AppSettings["max_miesiecy"]));
            string Year = ConfigurationManager.AppSettings["od_roku"];
            for (int i = 0; i < miesiecy; ++i)
            {
                if(i + 1 >= 10)
                    daty.Add(new Data(Year + "-" + (i % 12 + 1).ToString(), imionaNazwiska, rnd));
                else
                    daty.Add(new Data(Year + "-0" + (i % 12 + 1).ToString(), imionaNazwiska, rnd));
            }
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
        public string randomPesel(int value)
        {
            //92 01 20 01432
            long r = 0;
            long tmp = rnd.Next(60, 90); // rok
            r += tmp * 1000000000;
            tmp = rnd.Next(1, 12); //miesiac
            r += tmp * 10000000;
            tmp = rnd.Next(1, 28); //dzien
            r += tmp * 100000;
            tmp = rnd.Next(0, 99999);
            r += tmp;
            return r.ToString();
        }
    }
}
