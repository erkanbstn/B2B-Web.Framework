using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTicari.Models
{
    public class Degerler
    {
        public IEnumerable<Urun> UrunDeger { get; set; }
        public IEnumerable<UrunDetay> UrunDetayDeger { get; set; }
        public IEnumerable<Fatura> FaturaDeger { get; set; }
        public IEnumerable<FaturaKalem> FaturaKalemDeger { get; set; }
        public string Sehir { get; set; }
        public int Sayi { get; set; }
        public string Departman { get; set; }
        public int Sayi2 { get; set; }
        public string Marka { get; set; }
        public int Sayi3 { get; set; }


    }
}