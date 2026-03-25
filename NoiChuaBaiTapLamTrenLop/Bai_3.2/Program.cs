using System;

namespace Bài_3._2
{
    class NhanVien
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public double Luong { get; set; }

        public NhanVien(string hoTen, DateTime ngaySinh)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
        }

        public virtual void TinhLuong() { }

        public virtual void Xuat()
        {
            Console.WriteLine($"Ho ten: {HoTen}, Ngay sinh: {NgaySinh}, Luong: {Luong:C} VNĐ");
        }
    }

    class NhanVienVanPhong : NhanVien
    {
        public int SoNgayLamViec { get; set; }

        public NhanVienVanPhong(string hoTen, DateTime ngaySinh, int soNgayLamViec) : base(hoTen, ngaySinh)
        {
            SoNgayLamViec = soNgayLamViec;
        }

        public override void TinhLuong()
        {
            Luong = SoNgayLamViec * 100000;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"So ngay lam viec: {SoNgayLamViec}");
        }
    }

    class NhanVienSanXuat : NhanVien
    {
        public int SoSanPham { get; set; }

        public NhanVienSanXuat(string hoTen, DateTime ngaySinh, int soSanPham) : base(hoTen, ngaySinh)
        {
            SoSanPham = soSanPham;
        }

        public override void TinhLuong()
        {
            Luong = SoSanPham * 5000;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"So san pham: {SoSanPham}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so luong nhan vien: ");
            int n = int.Parse(Console.ReadLine());

            NhanVien[] danhSachNhanVien = new NhanVien[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin nhan vien thu {i + 1}:");
                Console.Write("Ho va ten: ");
                string hoTen = Console.ReadLine();
                Console.Write("Ngay sinh: ");
                DateTime ngaySinh = DateTime.Parse(Console.ReadLine());
                Console.Write("Loai nhan vien (0 - Van phong, 1 - San xuat): ");
                int loaiNhanVien = int.Parse(Console.ReadLine());

                if (loaiNhanVien == 0)
                {
                    Console.Write("So ngay lam viec: ");
                    int soNgayLam = int.Parse(Console.ReadLine());
                    danhSachNhanVien[i] = new NhanVienVanPhong(hoTen, ngaySinh, soNgayLam);
                }
                else if (loaiNhanVien == 1)
                {
                    Console.Write("So san pham: ");
                    int soSanPham = int.Parse(Console.ReadLine());
                    danhSachNhanVien[i] = new NhanVienSanXuat(hoTen, ngaySinh, soSanPham);
                }
                else
                {
                    Console.WriteLine("Loai nhan vien khong hop le.");
                    i--;
                }
            }

            foreach (NhanVien nv in danhSachNhanVien)
            {
                nv.TinhLuong();
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (danhSachNhanVien[i].Luong < danhSachNhanVien[j].Luong)
                    {
                        NhanVien temp = danhSachNhanVien[i];
                        danhSachNhanVien[i] = danhSachNhanVien[j];
                        danhSachNhanVien[j] = temp;
                    }
                }
            }

            Console.WriteLine("\nDanh sach nhan vien kem thong tin chi tiet:");
            foreach (NhanVien nv in danhSachNhanVien)
            {
                nv.Xuat();
            }
        }
    }
}
