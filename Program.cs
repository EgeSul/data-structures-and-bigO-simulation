using System;
using System.Collections.Generic;

namespace Vize_Denemeleri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool ProgramCalisiyor = true;

            while (ProgramCalisiyor)
            {
                Console.WriteLine("\n<*> Vize Denemeleri Ana Menüsüne Hoşgeldiniz <*>\n" +
                                  "1 -> Zaman Karmaşıklığı (Gauss vs Döngü)\n" +
                                  "2 -> Dizilerin (Arrays) Sınırları / Listeler\n" +
                                  "3 -> Bağlı Listeler (Linked Lists)\n" +
                                  "4 -> Yığın (Stack) — LIFO Mantığı (Cümle Ters Çevirme)\n" +
                                  "5 -> Kuyruk (Queue) — FIFO Mantığı (Sinema Sırası)\n" +
                                  "6 -> Sözlük (Dictionary) — Kelime Frekansı\n" +
                                  "7 -> Programdan Çıkış");
                Console.Write("Yapmak istediğiniz işlemi seçiniz: ");

                if (int.TryParse(Console.ReadLine(), out int secim))
                {
                    switch (secim)
                    {
                        case 1:
                            Console.WriteLine("\nBİG(O) zaman karmaşıklığı sistemi seçim yapınız:\n1-> Amele yöntemi (O(N))\n2-> Mühendis yöntemi (O(1))");
                            long n = 100000000; // Taşma (overflow) riskine karşı 

                            if (int.TryParse(Console.ReadLine(), out int secim2))
                            {
                                switch (secim2)
                                {
                                    case 1:
                                        long toplam = 0;
                                        for (int i = 0; i <= n; i++)
                                        {
                                            toplam += i;
                                        }
                                        Console.WriteLine("Amele Toplam: " + toplam);
                                        break;

                                    case 2:
                                        long gaussToplam = (n * (n + 1)) / 2;
                                        Console.WriteLine("Mühendis Toplam: " + gaussToplam);
                                        break;

                                    default:
                                        Console.WriteLine("Lütfen sadece 1 veya 2 değerini giriniz.");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sayısal bir değer giriniz.");
                            }
                            break;

                        case 2:
                            bool ProgramCalisiyor2 = true;
                            List<string> liste = new List<string>();

                            while (ProgramCalisiyor2)
                            {
                                Console.WriteLine("\n--- Kütüphane Yönetimi ---");
                                Console.WriteLine("İşlemler: [ekle] | [sil] | [listele] | [çıkış]");
                                Console.Write("Yapmak istediğiniz işlem: ");

                                string secim3 = Console.ReadLine().ToLower().Trim();

                                if (secim3 == "ekle")
                                {
                                    Console.Write("Eklemek istediğiniz Kitap ismini giriniz: ");
                                    string kitapI = Console.ReadLine();
                                    liste.Add(kitapI);
                                    Console.WriteLine($"{kitapI} başarılı bir şekilde eklendi.");
                                }
                                else if (secim3 == "sil")
                                {
                                    Console.Write("Silmek istediğiniz kitap ismini giriniz: ");
                                    string kitapS = Console.ReadLine();

                                    // Büyük/küçük harf duyarlılığını azaltmak için arama mantığı
                                    string bulunan = liste.Find(k => k.Equals(kitapS, StringComparison.OrdinalIgnoreCase));
                                    if (bulunan != null)
                                    {
                                        liste.Remove(bulunan);
                                        Console.WriteLine($"{kitapS} başarıyla silindi.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{kitapS} bulunamadı.");
                                    }
                                }
                                else if (secim3 == "listele")
                                {
                                    if (liste.Count > 0)
                                    {
                                        Console.WriteLine($"Listedeki kitap adedi: {liste.Count}");
                                        foreach (var l in liste)
                                        {
                                            Console.WriteLine("-> " + l);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Kitap listesi boş!");
                                    }
                                }
                                else if (secim3 == "çıkış")
                                {
                                    ProgramCalisiyor2 = false;
                                    Console.WriteLine("Kütüphane yönetiminden çıkılıyor...");
                                }
                                else
                                {
                                    Console.WriteLine("Hatalı seçim yapılmıştır.");
                                }
                            }
                            break;

                        case 3:
                            Console.WriteLine("\n--- Linked List Örneği ---");
                            LinkedList<string> trenVagonlari = new LinkedList<string>();
                            trenVagonlari.AddLast("Lokomotif");
                            trenVagonlari.AddLast("Yolcu Vagonu 1");
                            trenVagonlari.AddLast("Kömür Vagonu");

                            Console.WriteLine("Bağlı liste elemanları ardışık adreslerde olmak zorunda değildir, birbirini gösterir:");
                            foreach (var vagon in trenVagonlari)
                            {
                                Console.Write($"[{vagon}] -> ");
                            }
                            Console.WriteLine("NULL");
                            break;

                        case 4:
                            Console.WriteLine("\n--- Cümle Ters Çevirici (Stack) ---");
                            bool ProgramCalisiyor3 = true;
                            while (ProgramCalisiyor3)
                            {
                                Console.WriteLine("Çıkış yapmak için 'çıkış' yazınız.");
                                Console.Write("Kelime veya cümle giriniz: ");
                                string input = Console.ReadLine();

                                if (input.Equals("çıkış", StringComparison.OrdinalIgnoreCase))
                                {
                                    ProgramCalisiyor3 = false;
                                    Console.WriteLine("Bu modülden çıkılıyor...");
                                }
                                else
                                {
                                    string[] kelimeler = input.Split(' ');
                                    Stack<string> yigin = new Stack<string>();

                                    foreach (string kelime in kelimeler)
                                    {
                                        if (!string.IsNullOrEmpty(kelime)) yigin.Push(kelime);
                                    }

                                    Console.Write("Ters Çevrilmiş Hali: ");
                                    while (yigin.Count > 0)
                                    {
                                        Console.Write(yigin.Pop() + " ");
                                    }
                                    Console.WriteLine("\n");
                                }
                            }
                            break;

                        case 5:
                            Console.WriteLine("\n<*> Sinema Bilet Sistemi (Queue) <*>");
                            bool ProgramCalisiyor4 = true;
                            Queue<string> Sira = new Queue<string>();

                            while (ProgramCalisiyor4)
                            {
                                Console.WriteLine("\nİşlemler: [kayıt] (Sıraya gir) | [gişe] (Bilet al ve çık) | [çıkış]");
                                Console.Write("Seçiminiz: ");
                                string secim5 = Console.ReadLine().ToLower().Trim();

                                if (secim5 == "çıkış")
                                {
                                    ProgramCalisiyor4 = false;
                                    Console.WriteLine("Sinema sisteminden çıkılıyor...");
                                }
                                else if (secim5 == "kayıt")
                                {
                                    Console.Write("Sıraya girmek için isminizi giriniz: ");
                                    string isim = Console.ReadLine();
                                    Sira.Enqueue(isim);
                                    Console.WriteLine($"{isim} sıraya eklendi. Önünüzde {Sira.Count - 1} kişi var.");
                                }
                                else if (secim5 == "gişe")
                                {
                                    if (Sira.Count > 0)
                                    {
                                        string biletAlan = Sira.Dequeue();
                                        Console.WriteLine($"{biletAlan} biletini aldı ve sıradan ayrıldı.");

                                        if (Sira.Count > 0)
                                        {
                                            Console.WriteLine($"Sıradaki yeni kişi: {Sira.Peek()}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sırada kimse yok, gişe boş!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Hatalı seçim.");
                                }
                            }
                            break;

                        case 6:
                            Console.WriteLine("\n--- <*> Kelime Frekansı Sayacı (Dictionary) <*> ---");
                            Console.Write("Lütfen analiz edilecek metni giriniz: ");
                            string inputMetin = Console.ReadLine();

                            var kelimeSayaci = new Dictionary<string, int>();
                            string[] kelimelerDizisi = inputMetin.ToLower().Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (var kelime in kelimelerDizisi)
                            {
                                if (kelimeSayaci.ContainsKey(kelime))
                                {
                                    kelimeSayaci[kelime]++;
                                }
                                else
                                {
                                    kelimeSayaci.Add(kelime, 1);
                                }
                            }

                            Console.WriteLine("\n-----------------------------");
                            Console.WriteLine("KELİME\t\t\tADET");
                            Console.WriteLine("-----------------------------");

                            foreach (var cift in kelimeSayaci)
                            {
                                Console.WriteLine($"{cift.Key}\t\t\t{cift.Value} kez");
                            }

                            Console.WriteLine("-----------------------------");
                            Console.WriteLine($"Toplam Farklı Kelime Sayısı: {kelimeSayaci.Count}");
                            break;

                        case 7:
                            ProgramCalisiyor = false;
                            Console.WriteLine("Ana program sonlandırılıyor. İyi günler!");
                            break;

                        default:
                            Console.WriteLine("Lütfen 1-7 arasında geçerli bir menü numarası giriniz.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen sayısal bir değer giriniz.");
                }
            }
        }
    }
}