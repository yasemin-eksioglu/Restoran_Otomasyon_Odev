using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_Otomasyon_Odev
{
    internal class MasaSecim

    {
        public int MasaNo { get; set; }
        public bool BosMu { get; set; } = true;
        public List<MenuYiyecek> siparisYiyecek { get; set; } = new List<MenuYiyecek>();
        public List<MenuIcecek> siparisIcecek { get; set; } = new List<MenuIcecek>();
        public static List<MasaSecim> Masalar { get; set; }
        
        public MasaSecim(int masaNo)
        {
            MasaNo = masaNo;
        }
        public static void MasaListesiOlustur(int masaSayisi)
        {
            Masalar = new List<MasaSecim>();
            for (int i = 1; i <= masaSayisi; i++)
            {
                Masalar.Add(new MasaSecim(i));
            }
        }

        public static MasaSecim BosMasaBul()
        {
            return Masalar.FirstOrDefault(m => m.BosMu);
        }

        public static void MusteriEkle()
        {
            MasaSecim bosMasa = BosMasaBul();
            if (bosMasa != null)
            {
                bosMasa.BosMu = false; // masa artık dolu
                Console.WriteLine($" {bosMasa.MasaNo} Numaralı Masaya Oturabilirsiniz.");
            }
            else
            {
                Console.WriteLine("Üzgünüz Şuan Tüm Masalar Dolu");
            }
        }

        public double YiyecekHesap()
        {
            return siparisYiyecek.Sum(y => y.Fiyat);
        }
        public double IcecekHesap()
        {
            return siparisIcecek.Sum(i => i.Fiyat);
        }
        public double ToplamHesap()
        {
            return YiyecekHesap() + IcecekHesap();
        }

    }

}
