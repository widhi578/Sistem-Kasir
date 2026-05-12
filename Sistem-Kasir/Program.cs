using System;

public class Produk
{
    // property
    public string NamaBarang { get; set; }
    public double HargaBarang { get; set; }

    public Produk(string namaBarang, double hargaBarang)
    {
        NamaBarang = namaBarang;
        HargaBarang = hargaBarang;
    }

    public virtual double HitungHarga()
    {
        return HargaBarang;
    }
}

public class Elektronik : Produk
{
    public Elektronik(string namaBarang, double hargaBarang) : base(namaBarang, hargaBarang) { }

    public override double HitungHarga()
    {
        double diskon = HargaBarang * 0.10; // diskon 10%
        return HargaBarang - diskon;
    }
}

public class Makanan : Produk
{
    public Makanan(string namaBarang, double hargaBarang) : base(namaBarang, hargaBarang) { }

    public override double HitungHarga()
    {
        double diskon = HargaBarang * 0.05; // diskon 5%
        return HargaBarang - diskon;
    }
}

public class Minuman : Produk
{
    public Minuman(string namaBarang, double hargaBarang) : base(namaBarang, hargaBarang) { }

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
        Produk barang1 = new Elektronik("TV", 1000000);
        Produk barang2 = new Makanan("POP Mie", 10000);
        Produk barang3 = new Minuman("CocaCola", 5000);

        Produk[] daftarProduk = { barang1, barang2, barang3 };

        Console.WriteLine("=== Struk Pembayaran ===");

        double totalSemua = 0;

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

        Console.ReadLine();
    }
}