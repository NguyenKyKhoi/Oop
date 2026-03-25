using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bai_3._4
{

    class Printer
    {
        public string NhaSanXuat { get; set; }
        public double GiaBan { get; set; }

        public Printer() { }

        public Printer(string nsx, double gia)
        {
            NhaSanXuat = nsx;
            GiaBan = gia;
        }

        public virtual void Nhap()
        {
            Console.Write("Nhập nhà sản xuất (vd: Canon, HP): ");
            NhaSanXuat = Console.ReadLine();
            Console.Write("Nhập giá bán: ");
            GiaBan = double.Parse(Console.ReadLine());
        }

        public virtual void Xuat()
        {
            Console.Write($"{NhaSanXuat,-15} | {GiaBan,-10:N0}");
        }
    }
    class LaserPrinter : Printer
    {
        public string DoPhanGiai { get; set; } 

        public LaserPrinter() : base() { }

        public LaserPrinter(string nsx, double gia, string dpi) : base(nsx, gia)
        {
            DoPhanGiai = dpi;
        }

        public override void Nhap()
        {
            base.Nhap(); 
            Console.Write("Nhập độ phân giải (dpi): ");
            DoPhanGiai = Console.ReadLine();
        }

        public override void Xuat()
        {
            base.Xuat(); 
            Console.WriteLine($" | {DoPhanGiai}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<LaserPrinter> dsMayIn = new List<LaserPrinter>();

            Console.Write("Nhập số lượng máy in laser: ");
            int n = int.Parse(Console.ReadLine());

           
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhập máy in thứ {i + 1} ---");
                LaserPrinter lp = new LaserPrinter();
                lp.Nhap();
                dsMayIn.Add(lp);
            }

            
            Console.WriteLine("\n--- DANH SÁCH MÁY IN LASER ---");
            InTieuDe();
            dsMayIn.ForEach(p => p.Xuat());

            if (dsMayIn.Count > 0)
            {
                double maxGia = dsMayIn.Max(p => p.GiaBan);
                double minGia = dsMayIn.Min(p => p.GiaBan);

                Console.WriteLine($"\n=> Máy in giá cao nhất ({maxGia:N0}):");
                dsMayIn.Where(p => p.GiaBan == maxGia).ToList().ForEach(p => p.Xuat());

                Console.WriteLine($"=> Máy in giá thấp nhất ({minGia:N0}):");
                dsMayIn.Where(p => p.GiaBan == minGia).ToList().ForEach(p => p.Xuat());

                Console.Write("\nNhập tên hãng cần lọc (vd: Canon): ");
                string hang = Console.ReadLine();
                var dsLoc = dsMayIn.Where(p => p.NhaSanXuat.Equals(hang, StringComparison.OrdinalIgnoreCase)).ToList();

                if (dsLoc.Any())
                {
                    Console.WriteLine($"--- Các máy in thuộc hãng {hang} ---");
                    dsLoc.ForEach(p => p.Xuat());
                }
                else Console.WriteLine("Không tìm thấy hãng này.");

                Console.WriteLine("\n--- DANH SÁCH SẮP XẾP TĂNG DẦN THEO GIÁ ---");
                var dsSapXep = dsMayIn.OrderBy(p => p.GiaBan).ToList();
                InTieuDe();
                dsSapXep.ForEach(p => p.Xuat());
            }

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }

        static void InTieuDe()
        {
            Console.WriteLine($"{"Nhà sản xuất",-15} | {"Giá bán",-10} | Độ phân giải");
            Console.WriteLine(new string('-', 45));
        }
    }
}