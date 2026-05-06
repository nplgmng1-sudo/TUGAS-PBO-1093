using System;

namespace TUGAS_PBO_1093
{
    public class Kendaraan
    {
        public string nama;
        public int kecepatan;

        public Kendaraan(string nama, int kecepatan)
        {
            this.nama = nama;
            this.kecepatan = kecepatan;
        }

        public virtual void Bergerak()
        {
            Console.WriteLine($"{nama} sedang bergerak dengan kecepatan {kecepatan} km/jam");
        }

        public void InfoKendaraan()
        {
            Console.WriteLine($"Nama: {nama}, Kecepatan: {kecepatan}");
        }
    }

    class Darat : Kendaraan
    {
        public int jumlahRoda;

        public Darat(string nama, int kecepatan, int jumlahRoda) : base(nama, kecepatan)
        {
            this.jumlahRoda = jumlahRoda;
        }

        public void HitungRoda()
        {
            Console.WriteLine($"{nama} memiliki {jumlahRoda} roda");
        }

        public override void Bergerak()
        {
            Console.WriteLine($"{nama} bergerak di darat");
        }
    }

    class Air : Kendaraan
    {
        public string jenisAir;

        public Air(string nama, int kecepatan, string jenisAir) : base(nama, kecepatan)
        {
            this.jenisAir = jenisAir;
        }

        public void CekKondisiAir()
        {
            Console.WriteLine($"{nama} berada di air {jenisAir}");
        }

        public override void Bergerak()
        {
            Console.WriteLine($"{nama} berjalan di air");
        }
    }

    class Mobil : Darat
    {
        public Mobil(string nama, int kecepatan, int jumlahRoda)
            : base(nama, kecepatan, jumlahRoda) { }

        public void Klakson()
        {
            Console.WriteLine($"{nama} mengklakson TINNN TINNN!!");
        }
        public override void Bergerak()
        {
            Console.WriteLine($"{nama} berjalan di jalan tol");
        }
    }

    class Motor : Darat
    {
        public Motor(string nama, int kecepatan, int jumlahRoda) : base(nama, kecepatan, jumlahRoda) { }

        public void GasPol()
        {
            Console.WriteLine($"{nama} ngegaspol dangak dangak BRUM BRUM NGENGGGG");
        }
        public override void Bergerak()
        {
            Console.WriteLine($"{nama} berjalan di sirkuit mandalika");
        }
    }

    class Kapal : Air
    {
        public Kapal(string nama, int kecepatan, string jenisAir) : base(nama, kecepatan, jenisAir) { }

        public void Berlayar()
        {
            Console.WriteLine($"{nama} sedang berlayar");
        }
        public override void Bergerak()
        {
            Console.WriteLine($"{nama} berjalan di air melintasi samudera pasifik");
        }
    }

    class Perahu : Air
    {
        public Perahu(string nama, int kecepatan, string jenisAir) : base(nama, kecepatan, jenisAir) { }

        public void Dayung()
        {
            Console.WriteLine($"{nama} sedang didayung ");
        }
        public override void Bergerak()
        {
            Console.WriteLine($"{nama} berjalan di air melintasi sungai amazon");
        }
    }

    class Garasi
    {
        private List<Kendaraan> daftarKendaraan = new List<Kendaraan>();

        public void TambahKendaraan(Kendaraan kendaraan)
        {
            daftarKendaraan.Add(kendaraan);
        }

        public void DaftarKendaraan()
        {
            Console.WriteLine("\n=== Daftar Kendaraan di Garasi ===");
            foreach (var k in daftarKendaraan)
            {
                k.InfoKendaraan();
                k.Bergerak(); // polymorphism
            }

        }
        public List<Kendaraan> GetAll()
        {
            return daftarKendaraan;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Garasi garasi = new Garasi();
            Mobil mobil = new Mobil("Avanza", 120, 4);
            Motor motor = new Motor("Vario", 100, 2);
            Kapal kapal = new Kapal("Kapal Lawd", 50, "Laut");
            Perahu perahu = new Perahu("Perahu bebek", 20, "Sungai");
            Kendaraan motor2 = new Motor("Supra", 200, 2);

            mobil.Bergerak();
            kapal.Bergerak();
            mobil.Klakson();
            mobil.InfoKendaraan();
            mobil.HitungRoda();
            perahu.Dayung();
            motor2.Bergerak();

            garasi.TambahKendaraan(mobil);
            garasi.TambahKendaraan(motor);
            garasi.TambahKendaraan(kapal);
            garasi.TambahKendaraan(perahu);
            garasi.TambahKendaraan(motor2);

            garasi.DaftarKendaraan();

            Console.WriteLine("\n=== Polymorphism ===");
            foreach (var k in garasi.GetAll())
            {
                k.Bergerak();
            }

            Console.WriteLine("\n=== Method Khusus ===");
            mobil.Klakson();
            motor.GasPol();
            kapal.Berlayar();
            perahu.Dayung();
            mobil.Bergerak();
            mobil.InfoKendaraan();
            mobil.HitungRoda();
        }
    }

}


