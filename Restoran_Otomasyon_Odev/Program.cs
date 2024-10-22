namespace Restoran_Otomasyon_Odev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********** Restorana Hoş Geldiniz ***********");
            MasaSecim.MasaListesiOlustur(5);
            HosGeldiniz();


            static void HosGeldiniz()
            {
                while (true)
                {
                    Console.WriteLine("1-Sipariş Ver\n2-Hesap Öde\n3-Çıkış");
                    try
                    {
                        int secim = Convert.ToInt32(Console.ReadLine());
                        if (secim == 1)
                        {
                            MasaSecim.MusteriEkle(); //Boş Masaya Yönlendirildi
                            Thread.Sleep(2000);
                            Console.Clear();
                            var bosMasa = MasaSecim.BosMasaBul();
                            if (bosMasa != null)
                            {
                                Console.WriteLine("Kaç Kişi Olacaksınız?"); //Kişi Sayısı Kadar Sipariş Sor
                                int kisiSayisi = Convert.ToInt32(Console.ReadLine());
                                for (int i = 1; i <= kisiSayisi; i++)
                                {
                                    Menu.SiparisAl(bosMasa);
                                }
                            }
                            Console.Clear();
                        }
                        else if (secim == 2)
                        {
                            HesapOde();
                        }
                        else if (secim == 3)
                        {
                            Console.WriteLine("Çıkış Yapılıyor..");
                            Thread.Sleep(2000);
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Hatalı Tuşlama Yaptınız");
                            HosGeldiniz();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Lütfen Rakam Tuşlayınız!");
                        HosGeldiniz();
                    }
                }
            }
            static void HesapOde()
            {
                Console.WriteLine("Lütfen Hesabını Ödemek İstediğiniz Masa Numarasını Giriniz. (1-5)");
                int masaNoSecim = Convert.ToInt32(Console.ReadLine());
                MasaSecim masa = MasaSecim.Masalar.FirstOrDefault(m => m.MasaNo == masaNoSecim);
                if (masa != null && !masa.BosMu) // Masa Doluysa
                {
                    double toplamHesap = masa.ToplamHesap();
                    Console.WriteLine($"Masa{masa.MasaNo} İçin Toplam Hesap : {toplamHesap} Tl");
                    Console.WriteLine("Hesabı Şimdi Ödemek İster Misiniz? (E/H)");
                    string odeme = Console.ReadLine().ToUpper();
                    if (odeme == "E")
                    {
                        masa.BosMu = true;
                        masa.siparisIcecek.Clear();
                        masa.siparisYiyecek.Clear();
                        Console.WriteLine("Hesabınız Başarıyla Ödendi.Yine Bekleriz :)");
                        Thread.Sleep(2000);
                    }
                    else
                    { Console.WriteLine("Hesap Ödenmedi"); }
                    HosGeldiniz();
                }
                else
                {
                    Console.WriteLine("Geçersiz Masa Numarası veya Boş Masa Seçimi");
                    HesapOde();
                }
            }
        }
    }
}
