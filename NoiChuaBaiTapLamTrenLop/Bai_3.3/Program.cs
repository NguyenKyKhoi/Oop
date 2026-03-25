using System;

namespace Bai_3._2
{
    class HinhVe
    {
        public string TenHinh { get; set; }

        public HinhVe(string ten)
        {
            TenHinh = ten;
        }

        public virtual double DienTich()
        {
            return 0;
        }
    }

    class HinhChuNhat : HinhVe
    {
        public double ChieuDai { get; set; }
        public double ChieuRong { get; set; }

        public HinhChuNhat(double dai, double rong) : base("Hình Chữ Nhật")
        {
            ChieuDai = dai;
            ChieuRong = rong;
        }

        public override double DienTich()
        {
            return ChieuDai * ChieuRong;
        }
    }

    class HinhTron : HinhVe
    {
        public double BanKinh { get; set; }

        public HinhTron(double r) : base("Hình Tròn")
        {
            BanKinh = r;
        }

        public override double DienTich()
        {
            return Math.PI * BanKinh * BanKinh;
        }
    }

    class HinhVuong : HinhChuNhat
    {
        public HinhVuong(double canh) : base(canh, canh)
        {
            TenHinh = "Hình Vuông";
        }
       
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Chọn loại hình để tính diện tích:");
            Console.WriteLine("1. Hình Chữ Nhật");
            Console.WriteLine("2. Hình Tròn");
            Console.WriteLine("3. Hình Vuông");
            Console.Write("Lựa chọn của bạn (1-3): ");
            int loai = int.Parse(Console.ReadLine());

            HinhVe hinh = null; 
            switch (loai)
            {
                case 1:
                    Console.Write("Nhập chiều dài: ");
                    double d = double.Parse(Console.ReadLine());
                    Console.Write("Nhập chiều rộng: ");
                    double r = double.Parse(Console.ReadLine());
                    hinh = new HinhChuNhat(d, r);
                    break;
                case 2:
                    Console.Write("Nhập bán kính: ");
                    double bk = double.Parse(Console.ReadLine());
                    hinh = new HinhTron(bk);
                    break;
                case 3:
                    Console.Write("Nhập cạnh hình vuông: ");
                    double canh = double.Parse(Console.ReadLine());
                    hinh = new HinhVuong(canh);
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    return;
            }

  
            if (hinh != null)
            {
                Console.WriteLine($"\nLoại hình: {hinh.TenHinh}");
                Console.WriteLine($"Diện tích: {hinh.DienTich():N2}");
            }

            Console.ReadKey();
        }
    }
}