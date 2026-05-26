`using System;

public class Produk
{
    // Properti dasar yang dimiliki semua jenis produk.
    public string NamaBarang { get; set; }
    public double HargaBarang { get; set; }

    // Constructor untuk mengisi nama dan harga awal produk.
    public Produk(string namaBarang, double hargaBarang)
    {
        NamaBarang = namaBarang;
        HargaBarang = hargaBarang;
    }

    // Method virtual agar class turunan bisa mengubah cara menghitung harga akhir.
    public virtual double HitungHarga()
    {
        return HargaBarang;
    }
}

// Class Elektronik mewarisi Produk dan memberi diskon khusus elektronik.
public class Elektronik : Produk
{
    public Elektronik(string namaBarang, double hargaBarang) : base(namaBarang, hargaBarang) { }

    // Override method dari Produk untuk menghitung harga setelah diskon 10%.
    public override double HitungHarga()
    {
        double diskon = HargaBarang * 0.10; // diskon 10%
        return HargaBarang - diskon;
    }
}

// Class Makanan mewarisi Produk dan memberi diskon khusus makanan.
public class Makanan : Produk
{
    public Makanan(string namaBarang, double hargaBarang) : base(namaBarang, hargaBarang) { }

    // Override method dari Produk untuk menghitung harga setelah diskon 5%.
    public override double HitungHarga()
    {
        double diskon = HargaBarang * 0.05; // diskon 5%
        return HargaBarang - diskon;
    }
}

// Class Minuman mewarisi Produk dan memberi diskon khusus minuman.
public class Minuman : Produk
{
    public Minuman(string namaBarang, double hargaBarang) : base(namaBarang, hargaBarang) { }

    // Override method dari Produk untuk menghitung harga setelah diskon 2%.
    public override double HitungHarga()
    {
        double diskon = HargaBarang * 0.02; // diskon 2%
        return HargaBarang - diskon;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Membuat beberapa objek produk dengan jenis yang berbeda.
        Produk barang1 = new Elektronik("TV", 1000000);
        Produk barang2 = new Makanan("POP Mie", 10000);
        Produk barang3 = new Minuman("CocaCola", 5000);

        // Semua produk disimpan dalam array bertipe Produk.
        // Ini menunjukkan polymorphism: tiap objek memanggil HitungHarga() versinya sendiri.
        Produk[] daftarProduk = { barang1, barang2, barang3 };

        Console.WriteLine("=== Struk Pembayaran ===");

        // Variabel untuk menampung total harga akhir semua barang.
        double totalSemua = 0;

        // Menampilkan detail setiap barang sekaligus menjumlahkan harga akhirnya.
        foreach (Produk barang in daftarProduk)
        {
            double hargaAkhir = barang.HitungHarga();
            totalSemua += hargaAkhir;

            Console.WriteLine($"Nama Barang : {barang.NamaBarang}");
            Console.WriteLine($"Harga Awal  : Rp {barang.HargaBarang:N0}");
            Console.WriteLine($"Harga Akhir : Rp {hargaAkhir:N0}");
            Console.WriteLine();
        }

        Console.WriteLine($"------------------------------");
        Console.WriteLine($"Total Bayar : Rp {totalSemua:N0}");
        Console.WriteLine("==============================");

        // Menahan layar console agar hasil struk bisa dibaca sebelum program ditutup.
        Console.ReadLine();
    }
}
