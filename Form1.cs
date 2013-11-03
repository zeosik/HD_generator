using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml.XPath;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;

namespace pt_lab3_6
{
    using tuple_type = Tuple<string, string, string, double>;
    using apteki_tuple = Tuple<string, string, string>;
    using pracownik_tuple = Tuple<string, string, long>;
    
    public partial class Form1 : Form
    {
        public class Pracownik_Marek
        {
            public long id;
            public string imie;
            public string nazwisko;
            public long pesel;
            public string rejon; //DELeTE? YES
            public DateTime data_zatrudnienia;

            public override string ToString()
            {
                string d = "', '";
                return String.Concat(
                    id, d,
                    imie, d,
                    nazwisko, d,
                    pesel.ToString(), d,
                    data_zatrudnienia.ToShortDateString());
            }
        }
        public class Apteka
        {
            public long id;
            public Pracownik_Marek pracownik;
            public string nazwa;
            public string rejon;
            public string wojewodztwo;
            public override string ToString()
            {
                string d = "', '";
                return String.Concat(
                    id, d,
                    pracownik.id,
                    d, nazwa,
                    d, rejon,
                    d, wojewodztwo.ToString());
            }
        }

        class Lek
        {
            public long id;
            public string nazwa;
            public string typ;
            public double cena; //helper field

            override public string ToString()
            {
                string d = "', '";
                return String.Concat(id, d, nazwa, d, typ);
            }
        }

        class Faktura
        {
            public Apteka apteka;
            public Lek lek;
            public int ilosc;
            public double cena;
            public DateTime data;

            // override object.Equals
            public override bool Equals(object obj)
            {
                //       
                // See the full list of guidelines at
                //   http://go.microsoft.com/fwlink/?LinkID=85237  
                // and also the guidance for operator== at
                //   http://go.microsoft.com/fwlink/?LinkId=85238
                //

                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
                Faktura other = obj as Faktura;
                return
                    this.apteka == other.apteka &&
                    this.lek == other.lek &&
                    this.data == other.data;
            }
            public override string ToString()
            {
                string d = "', '";
                return String.Concat(
                    lek.id, d,
                    apteka.id, d,
                    ilosc, d,
                    cena.ToString("0.00").Replace(',', '.'), d, //so stupid..
                    data.ToShortDateString()
                    );
            }
        }

        class generator
        {
            //consts
            public DateTime startDate { get; set; }

            public int lek_max_ilosc { get; set; }
            public float lek_cena_min { get; set; }
            public float lek_cena_max { get; set; }

            long rand_pesel()
            {
                //92 01 20 01432
                long r = 0;
                long tmp = gen.Next(60, 90); // rok
                r += tmp * 1000000000;
                tmp = gen.Next(1, 12); //miesiac
                r += tmp * 10000000;
                tmp = gen.Next(1, 28); //dzien
                r += tmp * 100000;
                tmp = gen.Next(0, 99999);
                r += tmp;
                return r;
            }

            //
            Random gen = new Random();
            //from stack over flow
            DateTime RandomDate()
            {
                DateTime start = startDate;

                int range = (DateTime.Today - start).Days;
                return start.AddDays(gen.Next(range));
            }
            static string wojewodztwa_rejony_raw = "dolnośląskie;Jelenia Góra,dolnośląskie;Legnica,dolnośląskie;Wałbrzych,dolnośląskie;Wrocław,dolnośląskie;Zielona Góra,kujawsko-pomorskie;Bydgoszcz,kujawsko-pomorskie;Toruń,kujawsko-pomorskie;Włocławek,lubelskie;Biała Podlaska,lubelskie;Chełm,lubelskie;Lublin,lubelskie;Tarnobrzeg,lubelskie;Zamość,lubuskie;Gorzów,lubuskie;Gorzów Wlkp,lubuskie;Zielona Góra";

            static string apteki_raw = "Abrahama,Agar,Akademicka,Aksamitna,Alpejska,Antidotum,Aqua,Arnika,Asteria,Avena,Belladonna,Błękitna,Bratek,Brzeźno,Bursztynowa,Calamus,Centrum,Crategus,Częstochowska,Datura,Diamentowa,Dominikańska,Dyżurna,Dyżurna,Dyżurna,Eljax,Elżbietańska,Euro-apteka,Gdańska,Gemini,Gemini,Grodzieńska,Herba,Jagiellońska,Jaskółcza,Jesionowa,Kalinowa,Kameralna,Kaprów,Kartuska,Kaszubska,Kliniczna,Kolejarzy,Krzemowa,Lazurowa,Leśna,Libra,Lotnia,Manhattan,Medicur,Medyk,Milenijna,Millenium,Millennium,Miła,Morena,Morenowa,Natura,Niedźwiednik,Nova,Nova,Oliwska,Opolska,Orlik,Orunia-śuławska,Oruńska,Osiedlowa,Panaceum,Piastowska,Planeta,Polanki,Polska,Polska,Południowa,Pomorska,Przyjazna,Przymorska,Rajska,Ratuszowa,Remedium,Rodzinna,Rodzinna,Salix,Salus,Sanitas,Słoneczna,Słowiańska,Spacerowa,Staromiejska,Studencka,Super-pharm,Super-pharm,Tkacka,Tradycyjna,Ujeścisko,Vademecum,Vena,Wałowa,Wałowa,Westerplatte,Wileńska,Wrzosowa,Wspólna,Wymarzona,Zaspa,Żabianka";
            static string leki_raw = "Abaktal,ABE – płyn do usuwania odcisków,Abelcet,Abilify,Abiofem,Abra,Absenor,Acard,Acatar,Acatar Acti-Tabs,Acatar Fast,Acatar Zatoki,Acatarick Allergy,ACC,ACC 600,ACC 600 hot,ACC Hot,ACC Mini,ACC optima,Accolate,Accu-Chek Active,Accu-Chek Go,Accu-Chek Performa,Accupro 5,Accupro 10,Accupro 20,Accupro 40,Accuzide,Accuzide 20,Acenocumarol WZF,Acenol,Acenol forte,Acerin,Acerola Plus,A-cerumen,Acesan,Acespargin,Acetylcysteine Sandoz,Aciclovir Jelfa,Acidolac,Acidolac Baby,Acidolac Junior,Acidolit bezsmakowy dla niemowląt,Acidolit smak jabłkowy,Acidolit smak malinowy,Acidum Folicum Hasco,Acidum Folicum Polfarmex 5,Acidum Folicum Polfarmex 15,Acidum Folicum Richter,Acifolik,Acifungin,Acifungin forte,Aciprex,Acitren,Aclasta,Aclotin,Acne-derm,Acnex,Acno,Acnosan Max,Acnosan Soft,Acnosan T,Acodin,Acodin 150 Junior,Acodin 300,Actelsar,Act-HiB,Actibion,Acticoat Flex,Actifed,Actiferol Fe,Actilyse 10,Actilyse 20,Actilyse 50,Actisept,Actistav,ACTI-trin,Activ Angidin,Activelle,ActivKrill,Actrapid Penfill,Acular,Acurenal,Acviscin,Adacel,Adamon SR 50,Adamon SR 100,Adamon SR 150,Adamon SR 200,Adartrel,Adavin,Adcirca,Addamel N,Addiphos,Adeksa,Adenocor,Adenuric,Adepend,A-DERMA Dermalibour,A-DERMA Epitheliale A.H.,Adipine,Adolamid,Adrehyll Baby,Adrenalina WZF,Adrenalina WZF 0,1%,Adriblastina PFS,Adriblastina RD,Adrimedac,Advagraf,Advantan,Advate,Aerinaze,Aerius,Aero-OM,Aerrane,Aescin,Aesculan,Aescuven forte,Aethoxysklerol 0,5%,Aethoxysklerol 1%,Aethoxysklerol 2%,Aethoxysklerol 3%,Aethylum Chloratum Filofarm,Afinitor,Aflavic,Aflavic dermokrem,Aflegan,Aflexin,Aflexin Kręgosłup,Afloderm,Aflovag,Afobam,Afrin,Afrin ND,Afrin ND Mentol,Afrin ND Rumianek,Afrin PureSea Baby,Afrin PureSea Higiena Nosa,Afrin PureSea Udrożnianie Nosa,Agapurin,Agapurin SR 400,Agapurin SR 600,Agastin,Agelimit,Agen 5,Agen 10,Aggrastat,Agiolax,Aglan,Aglan 7,5,Aglan 15,Agregex,Akineton,Akistan,Aknemycin,Aknemycin Plus,Aknenormin 10 mg,Aknenormin 20 mg,Akneroxid 5,Akneroxid 10,Aksoderm,Aksoderm Forte,ALAnerv,Alantan,Alantan plus,Alantan Plus Altek,Alantan Plus Balsam do ciała,Alantandermoline Krem ochronny półtłusty z witaminami A + E,Alantandermoline Krem ochronny z witaminą A,Alantandermoline Lekki krem,Alantandermoline Maść pielęgnacyjna z witaminą F,Alantavit,Alaskan Max,Alax,Albiomin 20%,Albothyl,Alcaine,Alcep,Alcepal,Alchinal,Aldactone,Aldan 5,Aldan 10,Aldara 5% Krem,Aldurazyme,Alenato,Alendran 70,Alendrogen,Alendronat Bluefish,Alendronate Arrow,Alendronat-ratiopharm 70,Alendronatum 123ratio (Alendronatum Farmacom),Alercal Zdrovit,Aleric,Alermed,AlerTon,Alerzina,Aleve,Alexan,Alfa & Omega Junior,Alfabax,Alfadiol,Alfaferone,Alfarin,AlfuLEK 10,Alfuzostad 10 mg,Alimta,Aliovital,Alitol,Alkala N,Alkala T,Alka-Prim,Alka-Seltzer,Alkeran,All For Nails,Allegra,Allergocaps,Allergo-COMOD,Allergocrom,Allergodil,Allergovit A,B,Allergovit B,Allerin,Allertec,Allertec WZF,Allevyn,Allevyn Adhesive,Allevyn Ag Adhesive,Allevyn Ag Heel,Allevyn Ag Non Adhesive,Allevyn Ag Sacrum,Allevyn Heel,Allevyn Sacrum,Alliofil,Alliogal,Alliomint,Allupol,Alomide,Aloxi,Alpan Balsam z sadła świstaka,Alphagan,Alphol omega plus,Alpicort,Alpicort E,Alpragen,Alprox,Altacet,Altacet Ice,Altacet Junior,Altargo,Altaziaja,Alterutin C,Althamel,Althan,Alugastrin,Alugen 10 mg,Alumag,Alusal,Alutard SQ (alergeny roztoczy kurzu domowego) leczenie podstawowe,Alutard SQ (alergeny roztoczy kurzu domowego) leczenie podtrzymujące,Alutard SQ Brzoza leczenie podstawowe,Alutard SQ Brzoza leczenie podtrzymujące,Alutard SQ Osa leczenie podstawowe,Alutard SQ Osa leczenie podtrzymujące,Alutard SQ Pszczoła leczenie podstawowe,Alutard SQ Pszczoła leczenie podtrzymujące,Alutard SQ Roztocza mieszane leczenie podstawowe,Alutard SQ Roztocza mieszane leczenie podtrzymujące,Alutard SQ Sierść kota leczenie podstawowe,Alutard SQ Sierść kota leczenie podtrzymujące,Alutard SQ Tymotka leczenie podstawowe,Alutard SQ Tymotka leczenie podtrzymujące,Alventa,Alvenus Balsam z kasztanowca,Alvesco 80,Alvesco 160,Alzdone,Alzepezil,Amantix 100 mg,Amantix 200 mg/500 ml,Amarin,Amarosal,Amaryl 1,Amaryl 2,Amaryl 3,Amaryl 4,Ambilan,Ambiovit D,Ambiovit K,Ambiovit K + D,AmBisome,Ambrohexal,Ambroksol Takeda,Ambrosan,Ambrosol PLIVA,Ambrosol Teva,Ambrotaxer,Ambroxol Aflofarm,Amertil,Amertil Bio,Amertil Biotabs,Amidrop,Amigrenex,Aminodral,Aminomix 1 Novum,Aminoplasmal 15% E,Aminoplasmal B. Braun 10% E,Aminoplasmal Hepa 10%,Aminosteril KE 10% bez węglowodanów z elektrolitami,Aminosteril N-Hepa 8%,Aminoven infant 10%,Amiokordin,Amisan,Amitriptylinum VP,Amizepin,Amlator,Amlaxopin,Amlessa,Amlodipine Arrow 5 mg,Amlodipine Arrow 10 mg,Amlodipine Bluefish,Amlodipine Teva,Amlomyl,Amlonor,Amlopin,Amloratio 5,Amloratio 10,Amlozek,Amoclan,Amoksiklav,Amoksiklav Quicktab,Amol,Amolowe na gardło,Amorecaps,Amorolak,Amotaks,Amotaks Dis,Ampicillin TZF,Ampril 2,5 mg,Ampril 5 mg,Ampril 10 mg,Ampril HD,Ampril HL,Anafranil,Anafranil SR,Analgol,Ananas Naturkaps,Anapen,Anapen Junior,Anapran,Anapran EC,Anapran neo,Anastralan,Anastrozol Bluefish,Anastrozol medac,Anastrozol Teva,Anastrozole Accord,Anastrozole Orion,Ancotil,Andepin,Androcur,Androster,Androtop,AndroVit,Aneptinex,Anesteloc,Anesteloc Max,Anesteloc Zgagin,Anexate,Angeliq,Angiolip,Angiox,Ansepin,Ansyn,AntiCholesteran,Anticol,Antidol 15,Antidral,Antipres,Antiprost,Antithrombin III Immuno,Antivir,Antotalgin Natural,Antygrypin,Antypot,Antytoksyna botulinowa ABE,Antytoksyna jadu żmij,Antyzgaga,Anzorin,Apap,Apap C Plus,Apap Direct,Apap Extra,Apap Ice chłodzący plaster żelowy,Apap Junior,Apap Noc,Apap Przeziębienie CAPS,Apap Przeziębienie Hot,Apap Thermal plaster rozgrzewający,Aparxon PR,Apatinac,Aperisan,Apetizer,Apetizer Senior,Apetyt Stop,Apetyt Stop Max,Aphtigel 0,1%,Aphtigel Max 0,3%,Aphtin,Aphtin Aflofarm,Apichrom,Apidra,Apidra SoloStar,Apipulmol,Apirectum,Apisen,Apitussic,ApiUrin,Apivaginum,Apiżel,Aplefit,Apo-Amlo 5,Apo-Amlo 10,Apo-Atorva,Apo-Clodin,Apo-Doperil,Apo-Doxan 1,Apo-Doxan 2,Apo-Doxan 4,Apo-Feno 100,Apo-Feno 200M,Apo-Fina,Apo-Flutam,Apo-Indap,Apo-Lataprox,Apo-Letro,Apo-Lozart,Apo-Napro,Apo-Nastrol,ApoPatram,Apo-Pentox 400 SR,Apo-Perindox,Apo-Rami,Apo-Risperid,Apo-Selin,Apo-Simva 10,Apo-Simva 20,Apo-Simva 40,ApoSuprid,Apo-Tamis,ApoTiapina,ApoTrimet PR,Apo-Uro Plus,Apo-Valsart,Apo-Zolpin,Apptrim,AprilGen 5 mg,AprilGen 10 mg,AprilGen 20 mg,AprilGen 40 mg,Aprofen,Aprokam,Aprovel,Apselan,Aptivus,Aqua pro Injectione,Aqua pro Injectione Kabi,Aqua pro Injectione Polpharma,Aquacel,Aquacel Ag,Aquacel Foam,AquADEKs,Aqua-Femin,Aqua-Gel,Aquastop krem dla noworodków,Aquastop Radioterapia,Aranesp,Arava,Arcalen,Arduan,Arechin,Areplex,Argosulfan,Aricept,Arilin rapid,Arimidex,Arixtra,Arketis 20 mg,Armolipid,Arnisol,Arogen,Aromactiv,Aromasin,Aromatol,Aromatol Hot żel,Aromek,Aronia,Aronox,Aronox Serce,Aropilo,Aropilo SR,Aropix,Artecholin N,Artelac,Artelac Uno CL,Artemisol,Arteoptic,Arthron Complex,Arthrostop,Arthrostop Classic,Arthrostop Lady,Arthrostop Plus z imbirem,Arthrostop Rapid,Arthrotec,Arthrotec Forte,Arthrozamina Polfa-Łódź,Arthryl,Artizia,Artresan,Artresan 1 a day,Artresan Active,Artretcaps,Artreum,Artrocol,Artrostav,Arucom,Arulatan,Arutin,Arutin Complex,Arutin Noc,Arzerra,Asaltec 325,Asamax 250,Asamax 500,Asaris,Ascalcin,Ascalcin Plus o smaku cytrynowym,Ascalcin Plus o smaku grejpfrutowym,Ascalcin Plus o smaku malinowym,Ascensia Entrust,Ascodan,Ascofer,Ascorgem,Ascorutical,Ascorutical forte,Ascorvita,Asecurin,Asentra,Asept,Asepta,Asequrella,Asertin 50,Asertin 100,Asmag,Asmag B,Asmag forte,Asmanex Twisthaler,Asmenol,Aspafar Farmapol,Aspar Espefa,Asparaginase 5000 medac,Asparaginase 10 000 medac,Asparaginian Max vita,Aspargin,Aspicam,Aspicam Bio,Aspifox,Aspimag,Aspirin,Aspirin 300,Aspirin Cardio,Aspirin Complex,Aspirin Effect,Aspirin Extra,Aspirin Ultra Fast,Aspirin-C,Asprocol,Astmirex,Astmodil,Astres Forte,Asubtela,Asystor Slim,Atacand,Atarax,Atecortin,Atenolol Sanofi 25,Atenolol Sanofi 50,Atenolol Sanofi 100,Atimos,Atoperal,Atoperal Baby,Atopin,Atopra,Atopra Med,Atorgamma 10,Atorgamma 20,Atorgamma 40,Atoris,Atorvastatin 123ratio (Atorvastatin Teva Pharma),Atorvastatin Arrow,Atorvastatin Bluefish,Atorvastatin Ranbaxy,Atorvasterol,Atorvox,Atossa,Atractin,Atram 6,25 mg,Atram 12,5 mg,Atram 25 mg,Atrauman Ag,Atrederm 0,025%,Atrederm 0,05%,Atriance,Atropinum Sulfuricum,Atropinum Sulfuricum 1%,Atrovent,Atrovent N,Atrox 10,Atrox 20,Atrox 40,Atrozol,Atussan,Atussan Mite,Atywia,Audi Spray,Augmentin,Augmentin ES,Augmentin SR,Aulin,Aurex 20,Aurex 40,Aurorix,Avamina,Avamys,Avaron,Avasart,Avastin,AVAXIM 160 U,Avedol,Avelox,Aviomarin,Avioplant 250,Avodart,Avonex,Axanum,Axolan,Axotret,Axtil,Axudan,Axudan HCT,Axura,Axyven,Azalia,Azarga,Azathioprine VIS,Azelastin-POS,Azibiot,Azigen,Azilect,Azimycin,Azithromycin Genoptim,Azithromycinum 123ratio (AziTeva),Azitrin,AzitroLEK,AzitroLEK 250,AzitroLEK 500,Azitrox 250,Azitrox 500,Azopt,Azucalen,Azulan,Azulan Herbapol Pruszków,Azuseptol,Azycyna,Azyter,Azzalure";
            static string imie_nazwisko_raw = "Rae Allison,Bryar Orr,Bert Kennedy,Jennifer Albert,Kermit Pugh,Alma Pugh,Yael Ewing,Craig Hancock,Christen Nieves,Amena Jackson,Zenia Roman,Halee Parks,Tallulah Stein,Garrett Robbins,Shellie Davenport,Elliott Kline,Chaney Townsend,Quinlan Nolan,Gay Hardy,Jonas Downs,Darius Moran,Breanna Graves,Rebekah Wilcox,Tanek Brady,Quinn Shaffer,Eugenia Murray,Astra Newton,Kirk Estes,Sylvester Vega,Mechelle Buchanan,Marshall Ballard,Lewis Cannon,Brennan Dawson,Kadeem Lawson,Blythe Mccray,Imani Fulton,Keaton Sears,Dorian Waters,Brent Farley,Zelenia Richard,Anastasia Gentry,Merritt Howe,Petra Mcpherson,Vivien Lester,Magee Munoz,Slade Evans,Micah Larson,Angela Holder,Brian Gutierrez,Regina Roth,Ruby Peck,Martena Parrish,Ignatius Peterson,Sydnee White,Porter Bolton,Hermione Sharpe,Daquan Compton,Halla Adams,Karly Douglas,Heidi Lee,Urielle Levine,Eliana Bell,Armando Ewing,Tobias Buck,Bethany Lopez,Luke Mueller,Phelan Tucker,Tallulah Meadows,Damon Patrick,Holmes Lindsey,Noble Mccullough,Berk Hays,Zena Morris,September Espinoza,Uma Dale,Daphne Henson,Kennan Lawson,Tad Mcclure,Ryan Key,Haviva Salazar,Chloe Gay,Price Burnett,Hyacinth Holmes,Robin Townsend,Brynne Patrick,Kelsey Farley,Simone Pena,William Noble,Akeem Campos,Nehru Moon,Hedda Holloway,Donovan Reynolds,Gareth Slater,Hadassah Mcfadden,Yuri Delgado,Veronica Estrada,Kylynn Underwood,Merrill Davis,Rebekah Mcknight,Aquila Massey";
            string[] leki_typ = { "krople", "antybiotyk", "przeciwalergiczne" };
            string[] leki_spec = { "lekarz rodzinny", "okulista" };
            //Dictionary<string, Tuple<string, string>> leki_dic = new Dictionary<string , Tuple<string, string>>();
            string[] apteki;
            string[] leki;
            string[] imie_nazw;

            public System.IO.StreamWriter writer;

            public generator()
            {
                //COSNTS
                startDate = new DateTime(2012, 1, 1);
                lek_max_ilosc = 25;
                lek_cena_min = 2.00f;
                lek_cena_max = 99.99f;

                //PRACOWNICY
                imie_nazw = imie_nazwisko_raw.Split(',');
                List<pracownik_tuple> plist = new List<pracownik_tuple>();
                /*foreach (var i_n in imie_nazw)
                {
                    var i_n_ = i_n.split(' ');
                    pracownik_tuple pt = new pracownik_tuple(i_n_[0], i_n_[1]);
                    plist.add(pt);
                } */
                foreach (var item in kolekcja )
                {
                    var tuple = new pracownik_tuple(item.imie, item.nazwisko, Int64.Parse(item.pesel));
                    plist.Add(tuple);
                }
                pracownik_helper = new helper<pracownik_tuple>(plist, true);

                //APTEKi
                apteki = apteki_raw.Split(',');
                helper<string> w_r = new helper<string>(wojewodztwa_rejony_raw.Split(','), false);
                List<apteki_tuple> alist = new List<apteki_tuple>();
                foreach (var name in apteki)
                {
                    var wr = w_r.get().Split(';');
                    apteki_tuple nwr = new apteki_tuple(name, wr[0], wr[1]);
                    alist.Add(nwr);
                }
                apteki_helper = new helper<apteki_tuple>(alist, true);



                //LEKI
                leki = leki_raw.Replace(" ", "").Split(',');
                helper<string> l_typ = new helper<string>(leki_typ, false);
                helper<string> l_spec = new helper<string>(leki_spec, false);

                //Dictionary<string, Tuple<string, string>> leki_dic = new Dictionary<string, Tuple<string, string>>();

                List<tuple_type> llist = new List<tuple_type>();
                foreach (var lek_name in leki)
                {
                    //leki_dic.Add(lek_name, new Tuple<string, string>(l_typ.get(),l_spec.get()));
                    var tle = new tuple_type
                        (
                        lek_name,
                        l_typ.get(),
                        l_spec.get(),
                        (gen.NextDouble() * (lek_cena_max / lek_cena_min)) + lek_cena_min
                        );
                    llist.Add(tle);
                }
                leki_helper = new helper<tuple_type>(llist, true);

                //FAKTURY

                //FILE
                //string path = ("C:\\Users\\mareczek\\Documents\\SQL Server Management Studio\\hurtownie_danych\\insert.sql");
                string path = "insert.sql";
                writer = new System.IO.StreamWriter(path, false, Encoding.Unicode);

            }
            long apteka_last_id = 0;
            long lek_last_id = 0;
            long pracownik_last_id = 0;

            //generator helpers
            helper<apteki_tuple> apteki_helper;
            //nazwa, typ, spec, cena
            helper<tuple_type> leki_helper;
            //imie, nazw
            helper<pracownik_tuple> pracownik_helper;

            //TODO
            helper<Pracownik_Marek> pracownik_gen;

            //generated values
            helper<Apteka> apteka_gen;
            helper<Lek> lek_gen;

            Pracownik_Marek rand_pracownik()
            {
                Pracownik_Marek p = new Pracownik_Marek();
                p.id = ++pracownik_last_id;
                var i_n = pracownik_helper.get();
                p.imie = i_n.Item1;
                p.nazwisko = i_n.Item2;
                p.data_zatrudnienia = RandomDate();
                p.pesel = i_n.Item3;
                return p;
            }

            public void rand_pracownicy(int number)
            {
                List<Pracownik_Marek> pList = new List<Pracownik_Marek>();
                write_begin("PRACOWNIK");
                if (number >= imie_nazw.Length)
                    throw new Exception("ZA MALO IMION I NAZWISK W BAZIE");
                //TO JEST NAWET SPOKO :D:
                Func<string> next = () =>
                {
                    var p = rand_pracownik();
                    pList.Add(p);
                    return p.ToString();
                };
                for (int i = 0; i < number - 1; i++)
                {
                    write_middle(next());
                }
                write_last(next());
                pracownik_gen = new helper<Pracownik_Marek>(pList, false);
            }


            Apteka rand_apteka()
            {
                Apteka a = new Apteka();
                a.id = ++apteka_last_id;
                var nwr = apteki_helper.get();
                a.nazwa = nwr.Item1;
                a.wojewodztwo = nwr.Item2;
                a.rejon = nwr.Item3;
                a.pracownik = pracownik_gen.get();
                return a;
            }
            public void rand_apteki(int number)
            {
                List<Apteka> list = new List<Apteka>();
                write_begin("APTEKA");
                if (number >= apteki.Length)
                    throw new Exception("za duzo aptek, brak wystarczajacej ilosci nazw");
                Func<string> next = () =>
                {
                    var apteka = rand_apteka();
                    list.Add(apteka);
                    return apteka.ToString();
                };
                for (int i = 0; i < number - 1; i++)
                    write_middle(next());
                write_last(next());
                //list.Add(rand_apteka());
                apteka_gen = new helper<Apteka>(list, false);
                //return list;
            }

            Lek rand_lek()
            {
                Lek lek = new Lek();
                lek.id = ++lek_last_id;
                var tsss = leki_helper.get();
                lek.nazwa = tsss.Item1;
                lek.typ = tsss.Item2;
                lek.cena = tsss.Item4;
                return lek;
            }
            public void rand_leki(int number)
            {
                write_begin("LEK");

                List<Lek> list = new List<Lek>();
                if (number >= leki.Length)
                    throw new Exception("za duzo lekow, brak wystarczajacej ilosci nazw");

                Func<string> next = () =>
                {
                    var lek = rand_lek();
                    list.Add(lek);
                    return lek.ToString();
                };

                for (int i = 0; i < number - 1; i++)
                    write_middle(next());
                write_last(next());

                lek_gen = new helper<Lek>(list, false);
                //return list;
            }

            Faktura rand_faktura(DateTime date)
            {
                Faktura f = new Faktura();
                var l = lek_gen.get();
                f.lek = l;
                f.apteka = apteka_gen.get();
                //////////////////////////////////////////////////
                f.data = RandomDate();
                //f.data = date;
                double d = gen.NextDouble() * 0.1; //0 - 0.1
                d += 0.95; // 0.95 - 1.05
                f.cena = l.cena * d; // +/- 5% ceny
                f.ilosc = gen.Next(1, lek_max_ilosc);
                return f;
            }

            //number shouldnt be too big
            public void rand_faktury(int number, DateTime date)
            {
                write_begin("FAKTURA");
                //List<Faktura> list = new List<Faktura>();
                for (int i = 0; i < number - 1; i++)
                {
                    write_middle(rand_faktura(date).ToString());
                }
                write_last(rand_faktura(date).ToString());
                // return list;
            }

            class helper<T>
            {
                List<T> mList;
                bool delete;
                Random random = new Random();
                public helper(T[] list, bool del)
                    : this(list.ToList(), del)
                {
                }
                public helper(List<T> list, bool del)
                {
                    mList = list;
                    delete = del;
                }
                public T get()
                {
                    int i = random.Next(0, mList.Count);
                    T ret = mList[i];
                    if (delete)
                        mList.RemoveAt(i);
                    return ret;
                }
            }

            void write_begin(string table)
            {
                writer.WriteLine(String.Concat("INSERT INTO ", table, " VALUES"));
            }
            void write_middle(string values)
            {
                writer.WriteLine(String.Concat("('", values, "'),"));
            }
            void write_last(string values)
            {
                writer.WriteLine(String.Concat("('", values, "');"));
            }
        }

        public static BindingList<pracownik> kolekcja = new BindingList<pracownik>();
        public string path = @"test.xml";
        public List<ArrayList> imionaNazwiska = new List<ArrayList>();
        public Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            od_roku.Text = ConfigurationManager.AppSettings["od_roku"];
            miesiecy.Text = ConfigurationManager.AppSettings["max_miesiecy"];
            lekarzy_min.Text = ConfigurationManager.AppSettings["min_lekarzy"];
            lekarzy_max.Text = ConfigurationManager.AppSettings["max_lekarzy"];

            
            ArrayList imionaMeskie = new ArrayList();
            ArrayList imionaZenskie = new ArrayList();
            ArrayList nazwiskaMeskie = new ArrayList();
            ArrayList nazwiskaZenskie = new ArrayList();

            StreamReader objReader = new StreamReader("imiona_meskie.txt");
            string sLine = "";
            while(sLine != null)
            {
                sLine = objReader.ReadLine();
	            if (sLine != null)
		            imionaMeskie.Add(sLine);
            }
            objReader.Close();
            objReader = new StreamReader("imiona_zenskie.txt");
            sLine = "";
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    imionaZenskie.Add(sLine);
            }
            objReader.Close();
            objReader = new StreamReader("nazwiska_meskie.txt");
            sLine = "";
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    nazwiskaMeskie.Add(sLine);
            }
            objReader.Close();
            objReader = new StreamReader("nazwiska_zenskie.txt");
            sLine = "";
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    nazwiskaZenskie.Add(sLine);
            }
            objReader.Close();
            imionaNazwiska.Add(imionaMeskie);
            imionaNazwiska.Add(imionaZenskie);
            imionaNazwiska.Add(nazwiskaMeskie);
            imionaNazwiska.Add(nazwiskaZenskie);
            foreach (string sOutput in imionaNazwiska.ElementAt(0))
                //foreach(string Output in sOutput)
                    Console.WriteLine(sOutput);
            Console.ReadLine();

        }

        /*public void find(string name)
        {
            XPathDocument doc = new XPathDocument(path);
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator iterator = nav.Select(name);

            while (iterator.MoveNext())
                Console.WriteLine(iterator.Current.Value);
        }*/

        private void Serializacja(object sender, EventArgs e)
        {
            kolekcja.Clear();
            int worker;
            if (int.TryParse(workers.Text, out worker))
            {
                generate_status.Text = "generating";
                for (int i = 0; i < worker; ++i)
                {
                    kolekcja.Add(new pracownik(imionaNazwiska, rnd));
                }
                XmlRootAttribute rootAttr = new XmlRootAttribute();
                rootAttr.ElementName = "pracownicy";
                rootAttr.IsNullable = true;
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<pracownik>), rootAttr);

                if (!File.Exists(path))
                {
                    try
                    {
                        TextWriter writer = new StreamWriter(path);
                        FileStream fs = File.Create(path);
                        serializer.Serialize(writer, kolekcja);
                        writer.Close();
                        fs.Close();
                    }
                    catch (IOException ioe)
                    {
                    }
                }
                else
                {
                    TextWriter writer = new StreamWriter(path);
                    serializer.Serialize(writer, kolekcja);
                    writer.Close();
                }
                generate_status.Text = "generated";
                generator g = new generator();
                //var a = g.rand_apteki(5);
                g.rand_pracownicy(worker);
                g.rand_leki(int.Parse(lekiTextBox.Text));
                g.rand_apteki(int.Parse(aptekiTextBox.Text));
                g.rand_faktury(int.Parse(FaktoryTextBox.Text), new DateTime(2002, 12, 20));


                //SO UGLY xD
                g.writer.Close();
            }
            else
                generate_status.Text = "bledne dane";

        }

        public void SetDefaultConfiguration(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings["od_roku"] = "2004";
            ConfigurationManager.AppSettings["max_miesiecy"] = "108";
            ConfigurationManager.AppSettings["min_lekarzy"] = "5";
            ConfigurationManager.AppSettings["max_lekarzy"] = "10";

            od_roku.Text = ConfigurationManager.AppSettings["od_roku"];
            miesiecy.Text = ConfigurationManager.AppSettings["max_miesiecy"];
            lekarzy_min.Text = ConfigurationManager.AppSettings["min_lekarzy"];
            lekarzy_max.Text = ConfigurationManager.AppSettings["max_lekarzy"];

            generate_status.Text = "zresetowano";
        }

        private void Deserialize(object sender, EventArgs e)
        {
            XmlSerializer reader = new XmlSerializer(typeof(BindingList<pracownik>));
            if (File.Exists(path))
            {
                try
                {
                    TextReader file = new StreamReader(path);
                    kolekcja = (BindingList<pracownik>)reader.Deserialize(file);
                    file.Close();
                }
                catch (IOException ioe)
                {
                    Console.WriteLine("exception {0}", ioe);
                }
            }
        }

        private void zapisz_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (int.TryParse(od_roku.Text, out tmp) && 
                int.TryParse(miesiecy.Text, out tmp) && 
                int.TryParse(lekarzy_min.Text, out tmp) && 
                int.TryParse(lekarzy_max.Text, out tmp))
            {
                ConfigurationManager.AppSettings["od_roku"] = od_roku.Text;
                ConfigurationManager.AppSettings["max_miesiecy"] = miesiecy.Text;
                ConfigurationManager.AppSettings["min_lekarzy"] = lekarzy_min.Text;
                ConfigurationManager.AppSettings["max_lekarzy"] = lekarzy_max.Text;
                generate_status.Text = "zapisano";
            }
            else
                generate_status.Text = "bledne dane";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}