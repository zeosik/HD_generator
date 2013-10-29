using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections;
using System.Configuration;

namespace pt_lab3_6
{
    [Serializable]
    public class Data
    {
        [XmlIgnore]
        Random rnd;
        [XmlAttribute]
        public string data;
        public int kilometry;
        public decimal koszt_paliwa;
        public List<lekarz> lekarze;
        public Data() { }
        public Data(string Data, List<ArrayList> imionaNazwiska, Random rand)
        {
            rnd = rand;
            data = Data;
            kilometry = rnd.Next(500, 5000);
            koszt_paliwa = (decimal)(kilometry/100*7*(4.0+rnd.NextDouble()));
            koszt_paliwa = System.Decimal.Round(koszt_paliwa, 2);
            lekarze = new List<lekarz>();
            int min = int.Parse(ConfigurationManager.AppSettings["min_lekarzy"]);
            int max = int.Parse(ConfigurationManager.AppSettings["max_lekarzy"]);
            int lekarzy = rnd.Next(min, max);
            for (int i = 0; i < lekarzy; ++i)
                lekarze.Add(new lekarz(imionaNazwiska, rnd));
            
            //lekarze.Add(new lekarz("Jan", "Kowalski", "Okulista"));
            //lekarze.Add(new lekarz("Jan", "Kowalski", "Okulista"));
            
        }
    }
}
